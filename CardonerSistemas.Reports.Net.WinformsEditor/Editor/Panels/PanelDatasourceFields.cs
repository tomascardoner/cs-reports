using System.Data.Common;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceFields : UserControl
    {

        #region Declarations

        private string mApplicationTitle;
        private readonly Model.Report mReport;

        public delegate void FieldHandler(object sender, PanelDatasourceField.FieldEventArgs e);

        public event FieldHandler? FieldAdded;
        public event EventHandler? FieldsRefreshed;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceFields(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            mReport = report;
            mApplicationTitle = applicationTitle;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringDatasourceFieldsAdd;
        }

        #endregion Initialization

        #region Methods

        public void ShowProperties()
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            labelCounter.Text = mReport.Datasource.Fields.Count switch
            {
                0 => Properties.Resources.StringDatasourceFieldsCounterEmpty,
                1 => Properties.Resources.StringDatasourceFieldsCounterOne,
                _ => string.Format(Properties.Resources.StringDatasourceFieldsCounter, mReport.Datasource.Fields.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            if (mReport.Datasource.Fields.Any(f => f.Name.Trim() == Properties.Resources.StringDatasourceFieldNameNew))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mReport.Datasource.Fields.Add(new(mReport.Datasource) { Name = Properties.Resources.StringDatasourceFieldNameNew });
            }
            if (FieldAdded is not null)
            {
                FieldAdded(this, new() { NameNew = Properties.Resources.StringDatasourceFieldNameNew });
            }
        }


        private void GetFields(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mReport.Datasource?.ConnectionString))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (mReport.Datasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceGetFieldsWithNullParametersConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

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