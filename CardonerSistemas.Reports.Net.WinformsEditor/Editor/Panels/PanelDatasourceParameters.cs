namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceParameters : UserControl
    {

        #region Declarations

        private readonly string _applicationTitle;
        private readonly Model.Report _report;

        public delegate void ParameterHandler(object sender, short parameterId);

        public event ParameterHandler? ParameterAdded;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceParameters(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringDatasourceParametersAdd;
        }

        #endregion Initialization

        #region Methods

        internal void ShowProperties()
        {
            if (_report.Datasource is null)
            {
                return;
            }
            labelCounter.Text = _report.Datasource.Parameters.Count switch
            {
                0 => Properties.Resources.StringDatasourceParametersCounterEmpty,
                1 => Properties.Resources.StringDatasourceParametersCounterOne,
                _ => string.Format(Properties.Resources.StringDatasourceParametersCounter, _report.Datasource.Parameters.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            if (_report.Datasource is null)
            {
                return;
            }
            Model.DatasourceParameter? datasourceParameter = _report.Datasource.Parameters.FirstOrDefault(p => p.Name.Trim() == Properties.Resources.StringDatasourceParameterNameNew);
            if (datasourceParameter is null)
            {
                datasourceParameter = new Model.DatasourceParameter(_report.Datasource) { Name = Properties.Resources.StringDatasourceParameterNameNew };
                _report.Datasource.Parameters.Add(datasourceParameter);
            }
            else
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (ParameterAdded is not null)
            {
                ParameterAdded(this, datasourceParameter.ParameterId);
            }
        }

        #endregion Methods

    }
}
