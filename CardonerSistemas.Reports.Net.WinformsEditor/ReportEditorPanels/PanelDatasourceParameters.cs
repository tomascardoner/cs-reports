namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceParameters : UserControl
    {
        private Model.Datasource? mDatasource;

        public PanelDatasourceParameters(Model.Datasource? datasource)
        {
            InitializeComponent();
            mDatasource = datasource;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringDatasourceParametersAdd;
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
            labelCounter.Text = mDatasource.Parameters.Count switch
            {
                0 => Properties.Resources.StringDatasourceParametersCounterEmpty,
                1 => Properties.Resources.StringDatasourceParametersCounterOne,
                _ => string.Format(Properties.Resources.StringDatasourceParametersCounter, mDatasource.Parameters.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            mDatasource ??= new();
            mDatasource.Parameters.Add(new() { Name = Properties.Resources.StringDatasourceParameterNameNew });
        }
    }
}
