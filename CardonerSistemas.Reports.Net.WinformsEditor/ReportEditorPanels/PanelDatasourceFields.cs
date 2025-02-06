namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceFields : UserControl
    {
        private Model.Datasource? mDatasource;

        public PanelDatasourceFields(Model.Datasource? datasource)
        {
            InitializeComponent();
            mDatasource = datasource;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringDatasourceFieldsAdd;
        }

        public void SetDatasource(Model.Datasource? datasource)
        {
            mDatasource = datasource;
            ShowProperties();
        }

        private void ShowProperties()
        {
            if (mDatasource is null)
            {
                return;
            }
            labelCounter.Text = mDatasource.Fields.Count switch
            {
                0 => Properties.Resources.StringDatasourceFieldsCounterEmpty,
                1 => Properties.Resources.StringDatasourceFieldsCounterOne,
                _ => string.Format(Properties.Resources.StringDatasourceFieldsCounter, mDatasource.Fields.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            mDatasource ??= new();
            mDatasource.Fields.Add(new(mDatasource) { Name = Properties.Resources.StringDatasourceFieldNameNew });
        }
    }
}
