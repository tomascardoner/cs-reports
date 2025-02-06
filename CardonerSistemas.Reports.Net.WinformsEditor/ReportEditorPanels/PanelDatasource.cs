using System.Data.Common;

namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasource : UserControl
    {
        private Model.Datasource? mDatasource;
        private readonly string mApplicationTitle;

        public PanelDatasource(Model.Datasource? datasource, string applicationTitle)
        {
            InitializeComponent();
            mDatasource = datasource;
            mApplicationTitle = applicationTitle;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;

            FillProviders();
            FillTypes();
        }

        public void SetDatasource(Model.Datasource? datasource)
        {
            mDatasource = datasource;
            ShowProperties();
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

        private void TextBoxs_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void ShowProperties()
        {
            if (mDatasource is null)
            {
                comboBoxProvider.SelectedIndex = -1;
                textBoxConnectionString.Text = string.Empty;
                comboBoxType.SelectedIndex = -1;
                textBoxText.Text = string.Empty;
            }
            else
            {
                comboBoxProvider.SelectedValue = (byte)mDatasource.Provider;
                textBoxConnectionString.Text = mDatasource.ConnectionString;
                comboBoxType.SelectedValue = (short)mDatasource.Type;
                textBoxText.Text = mDatasource.Text;
            }
        }

        private bool VerifyRequired()
        {
            if (comboBoxProvider.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceProviderRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(textBoxConnectionString.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTypeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceTextRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            mDatasource ??= new();
            mDatasource.Provider = (Model.Datasource.Providers)(comboBoxProvider.SelectedValue ?? Model.Datasource.Providers.None);
            mDatasource.ConnectionString = textBoxConnectionString.Text;
            mDatasource.Type = (System.Data.CommandType)(short)(comboBoxType.SelectedValue ?? System.Data.CommandType.Text);
            mDatasource.Text = textBoxText.Text;
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void AddParameter(object sender, EventArgs e)
        {
            mDatasource ??= new();
            mDatasource.Parameters.Add(new() { Name = Properties.Resources.StringDatasourceParameterNameNew });
        }

        private void GetFields(object sender, EventArgs e)
        {
            if (!VerifyRequired())
            {
                return;
            }
            if (mDatasource is null || (mDatasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceGetFieldsWithNullParametersConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No))
            {
                return;
            }
            buttonApply.PerformClick();

            // Open the datasource
            DbDataReader? dbDataReader = null;
            Data.Datasource.GetDatasource(mDatasource, ref dbDataReader);
            dbDataReader?.Close();
        }
    }
}