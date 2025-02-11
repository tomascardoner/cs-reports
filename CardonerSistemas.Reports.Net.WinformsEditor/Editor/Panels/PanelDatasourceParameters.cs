namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceParameters : UserControl
    {

        #region Declarations

        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;

        public delegate void ParameterHandler(object sender, PanelDatasourceParameter.ParameterEventArgs e);

        public event ParameterHandler? ParameterAdded;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceParameters(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            mReport = report;
            mApplicationTitle = applicationTitle;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringDatasourceParametersAdd;
        }

        #endregion Initialization

        #region Methods

        internal void ShowProperties()
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            labelCounter.Text = mReport.Datasource.Parameters.Count switch
            {
                0 => Properties.Resources.StringDatasourceParametersCounterEmpty,
                1 => Properties.Resources.StringDatasourceParametersCounterOne,
                _ => string.Format(Properties.Resources.StringDatasourceParametersCounter, mReport.Datasource.Parameters.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            if (mReport.Datasource.Parameters.Any(p => p.Name.Trim() == Properties.Resources.StringDatasourceParameterNameNew))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mReport.Datasource.Parameters.Add(new() { Name = Properties.Resources.StringDatasourceParameterNameNew });
            }
            if (ParameterAdded is not null)
            {
                ParameterAdded(this, new() { NameNew = Properties.Resources.StringDatasourceParameterNameNew });
            }
        }

        #endregion Methods

    }
}