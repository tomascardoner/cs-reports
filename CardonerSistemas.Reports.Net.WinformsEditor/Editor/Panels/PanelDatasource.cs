using System.Data.Common;
using System.Text.RegularExpressions;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasource : UserControl
    {

        #region Declarations

        private readonly string _applicationTitle;
        private readonly Model.Report _report;

        public event EventHandler? DatasourceUpdated;
        public event EventHandler? DatasourceDeleted;
        public event EventHandler? FieldsUpdated;

        #endregion Declarations

        #region Initialization

        public PanelDatasource(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;

            FillProviders();
            FillTypes();
        }

        private void FillProviders()
        {
            comboBoxProvider.ValueMember = "Key";
            comboBoxProvider.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Datasource.Providers provider in Enum.GetValues<Model.Datasource.Providers>())
            {
                items.Add(new KeyValuePair<int, string>((int)provider, FriendlyNames.GetDatasourceProvider(provider)));
            }
            comboBoxProvider.DataSource = items;
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (System.Data.CommandType datasourceType in Enum.GetValues<System.Data.CommandType>())
            {
                items.Add(new KeyValuePair<int, string>((int)datasourceType, FriendlyNames.GetDatasourceType(datasourceType)));
            }
            comboBoxType.DataSource = items;
        }

        #endregion Initialization

        #region Events

        private void ControlFocusEnter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void SavePasswordChanged(object sender, EventArgs e)
        {
            checkBoxConnectionStringSavePassword.Enabled = checkBoxConnectionStringSave.Checked;
        }

        #endregion Events

        #region Methods

        internal void ShowProperties()
        {
            if (_report.Datasource is null)
            {
                comboBoxProvider.SelectedIndex = -1;
                textBoxConnectionString.Text = string.Empty;
                comboBoxType.SelectedIndex = -1;
                textBoxText.Text = string.Empty;
                buttonDelete.Enabled = false;
                buttonGetFields.Enabled = false;
            }
            else
            {
                comboBoxProvider.SelectedValue = (int)_report.Datasource.Provider;
                textBoxConnectionString.Text = _report.Datasource.ConnectionString;
                comboBoxType.SelectedValue = (int)_report.Datasource.Type;
                textBoxText.Text = _report.Datasource.Text;
                buttonDelete.Enabled = true;
                buttonGetFields.Enabled = true;
            }
        }

        private bool VerifyRequired()
        {
            if (comboBoxProvider.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceProviderRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxProvider.Focus();
                return false;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTextRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxText.Focus();
                return false;
            }
            return true;
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (!VerifyRequired())
            {
                return;
            }
            _report.Datasource ??= new();
#pragma warning disable CS8605 // Unboxing a possibly null value.
            _report.Datasource.Provider = (Model.Datasource.Providers)comboBoxProvider.SelectedValue;
#pragma warning restore CS8605 // Unboxing a possibly null value.
            if (checkBoxConnectionStringSave.Checked)
            {
                if (checkBoxConnectionStringSavePassword.Checked)
                {
                    _report.Datasource.ConnectionString = textBoxConnectionString.Text;
                }
                else
                {
                    _report.Datasource.ConnectionString = PasswordRegex().Replace(textBoxConnectionString.Text, string.Empty);
                }
            }
            else
            {
                _report.Datasource.ConnectionString = string.Empty;
            }
            _report.Datasource.Type = (System.Data.CommandType)(int)(comboBoxType.SelectedValue ?? System.Data.CommandType.Text);
            _report.Datasource.Text = textBoxText.Text;
            buttonDelete.Enabled = true;
            buttonGetFields.Enabled = true;
            if (DatasourceUpdated is not null)
            {
                DatasourceUpdated(this, EventArgs.Empty);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_report.Datasource is null || MessageBox.Show(Properties.Resources.StringDatasourceDeleteConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _report.Datasource.Parameters.Clear();
            _report.Datasource.Fields.Clear();
            _report.Datasource = null;
            ShowProperties();
            comboBoxProvider.Focus();
            if (DatasourceDeleted is not null)
            {
                DatasourceDeleted(this, EventArgs.Empty);
            }
        }

        private void GetFields(object sender, EventArgs e)
        {
            if (!VerifyRequired())
            {
                return;
            }
            if (string.IsNullOrEmpty(_report.Datasource?.ConnectionString) && string.IsNullOrEmpty(textBoxConnectionString.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxConnectionString.Focus();
                return;
            }
            if (_report.Datasource is null || (_report.Datasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceFieldsGetWithNullParametersConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No))
            {
                return;
            }
            if (MessageBox.Show(Properties.Resources.StringDatasourceFieldsGetConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            // Open the datasource
            DbDataReader? dbDataReader = null;
            if (string.IsNullOrEmpty(_report.Datasource?.ConnectionString))
            {
                Data.Datasource.GetDatasource(_report.Datasource, ref dbDataReader, textBoxConnectionString.Text.Trim());
            }
            else
            {
                Data.Datasource.GetDatasource(_report.Datasource, ref dbDataReader);
            }
            dbDataReader?.Close();
            if (FieldsUpdated is not null)
            {
                FieldsUpdated(this, EventArgs.Empty);
            }
        }

        [GeneratedRegex(";?Password=([^;]*)", RegexOptions.IgnoreCase)]
        private static partial Regex PasswordRegex();

        #endregion Methods

    }
}
