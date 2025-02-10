namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceParameters : UserControl
    {

        #region Declarations

        private readonly string mApplicationTitle;
        private readonly Model.Report mReport;

        public event EventHandler? ParameterAdded;

        #endregion Declarations

        #region Initialization

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public PanelDatasourceParameters(Model.Report report, string applicationTitle)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            InitializeComponent();
            mApplicationTitle = applicationTitle;
            mReport = report;
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
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNewAlreadyExists, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mReport.Datasource.Parameters.Add(new() { Name = Properties.Resources.StringDatasourceParameterNameNew });
            }
            if (ParameterAdded is not null)
            {
                ParameterAdded(this, EventArgs.Empty);
            }
        }

        #endregion Methods

    }
}