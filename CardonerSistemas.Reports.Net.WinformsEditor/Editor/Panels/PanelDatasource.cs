using System.Data.Common;
using System.Text.RegularExpressions;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasource : UserControl
    {

        #region Declarations

        private const string PasswordRegExp = ";?Password=([^;]*)";

        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;

        public event EventHandler? DatasourceUpdated;
        public event EventHandler? DatasourceDeleted;
        public event EventHandler? FieldsRefreshed;

        #endregion Declarations

        #region Initialization

        public PanelDatasource(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            mReport = report;
            mApplicationTitle = applicationTitle;
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
            ICollection<KeyValuePair<byte, string>> items = [];
            foreach (Model.Datasource.Providers provider in Enum.GetValues<Model.Datasource.Providers>())
            {
                items.Add(new KeyValuePair<byte, string>((byte)provider, FriendlyNames.GetDatasourceProvider(provider)));
            }
            comboBoxProvider.DataSource = items;
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<short, string>> items = [];
            foreach (System.Data.CommandType datasourceType in Enum.GetValues<System.Data.CommandType>())
            {
                items.Add(new KeyValuePair<short, string>((short)datasourceType, FriendlyNames.GetDatasourceType(datasourceType)));
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
            if (mReport.Datasource is null)
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
                comboBoxProvider.SelectedValue = (byte)mReport.Datasource.Provider;
                textBoxConnectionString.Text = mReport.Datasource.ConnectionString;
                comboBoxType.SelectedValue = (short)mReport.Datasource.Type;
                textBoxText.Text = mReport.Datasource.Text;
                buttonDelete.Enabled = true;
                buttonGetFields.Enabled = true;
            }
        }

        private bool VerifyRequired()
        {
            if (comboBoxProvider.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceProviderRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxProvider.Focus();
                return false;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTypeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTextRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            mReport.Datasource ??= new();
#pragma warning disable CS8605 // Unboxing a possibly null value.
            mReport.Datasource.Provider = (Model.Datasource.Providers)comboBoxProvider.SelectedValue;
#pragma warning restore CS8605 // Unboxing a possibly null value.
            if (checkBoxConnectionStringSave.Checked)
            {
                if (checkBoxConnectionStringSavePassword.Checked)
                {
                    mReport.Datasource.ConnectionString = textBoxConnectionString.Text;
                }
                else
                {
                    mReport.Datasource.ConnectionString = Regex.Replace(textBoxConnectionString.Text, PasswordRegExp, string.Empty);
                }
            }
            else
            {
                mReport.Datasource.ConnectionString = string.Empty;
            }
            mReport.Datasource.Type = (System.Data.CommandType)(short)(comboBoxType.SelectedValue ?? System.Data.CommandType.Text);
            mReport.Datasource.Text = textBoxText.Text;
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
            if (mReport.Datasource is null || MessageBox.Show(Properties.Resources.StringDatasourceDeleteConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            mReport.Datasource.Parameters.Clear();
            mReport.Datasource.Fields.Clear();
            mReport.Datasource = null;
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
            if (string.IsNullOrEmpty(textBoxConnectionString.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxConnectionString.Focus();
                return;
            }
            if (mReport.Datasource is null || (mReport.Datasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceGetFieldsWithNullParametersConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No))
            {
                return;
            }
            buttonApply.PerformClick();

            // Open the datasource
            DbDataReader? dbDataReader = null;
            Data.Datasource.GetDatasource(mReport.Datasource, ref dbDataReader);
            dbDataReader?.Close();

            if (FieldsRefreshed is not null)
            {
                FieldsRefreshed(this, EventArgs.Empty);
            }
        }

        #endregion Methods

    }
}