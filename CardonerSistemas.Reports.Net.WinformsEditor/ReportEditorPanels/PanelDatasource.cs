namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasource : UserControl
    {
        private readonly string mApplicationTitle;

        public PanelDatasource(string applicationTitle)
        {
            InitializeComponent();
            mApplicationTitle = applicationTitle;

            FillProviders();
            FillTypes();
        }

        private void FillProviders()
        {
            comboBoxProvider.ValueMember = "Key";
            comboBoxProvider.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> datasourceProviders = [];
            foreach (Model.Datasource.Providers provider in Enum.GetValues<Model.Datasource.Providers>())
            {
                datasourceProviders.Add(new KeyValuePair<byte, string>((byte)provider, FriendlyNames.GetDatasourceProvider(provider)));
            }
            comboBoxProvider.DataSource = datasourceProviders;
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<short, string>> datasourceTypes = [];
            foreach (System.Data.CommandType datasourceType in Enum.GetValues<System.Data.CommandType>())
            {
                datasourceTypes.Add(new KeyValuePair<short, string>((short)datasourceType, FriendlyNames.GetDatasourceType(datasourceType)));
            }
            comboBoxType.DataSource = datasourceTypes;
        }

        internal void ShowProperties(Model.Datasource? datasource)
        {
            if (datasource is null)
            {
                comboBoxProvider.SelectedIndex = -1;
                textBoxConnectionString.Text = string.Empty;
                comboBoxType.SelectedIndex = -1;
                textBoxText.Text = string.Empty;
            }
            else
            {
                comboBoxProvider.SelectedValue = (byte)datasource.Provider;
                textBoxConnectionString.Text = datasource.ConnectionString;
                comboBoxType.SelectedValue = (short)datasource.Type;
                textBoxText.Text = datasource.Text;
            }
        }

        internal void SetProperties(Model.Datasource datasource)
        {
            datasource ??= new();
            datasource.Provider = (Model.Datasource.Providers)(comboBoxProvider.SelectedValue ?? Model.Datasource.Providers.None);
            datasource.ConnectionString = textBoxConnectionString.Text;
            datasource.Type = (System.Data.CommandType)(short)(comboBoxType.SelectedValue ?? System.Data.CommandType.Text);
            datasource.Text = textBoxText.Text;
        }

        private void ButtonGetFields_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxConnectionString.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringNotSpecified, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
