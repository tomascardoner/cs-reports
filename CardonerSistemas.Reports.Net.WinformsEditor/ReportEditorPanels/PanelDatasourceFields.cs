using System.Data.Common;

namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceFields : UserControl
    {
        private Model.Datasource? mDatasource;
        private string mApplicationTitle;

        public PanelDatasourceFields(Model.Datasource? datasource, string applicationTitle)
        {
            InitializeComponent();
            mDatasource = datasource;
            mApplicationTitle = applicationTitle;
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

        private void GetFields(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mDatasource?.ConnectionString))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (mDatasource is null || (mDatasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceGetFieldsWithNullParametersConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No))
            {
                return;
            }

            // Open the datasource
            DbDataReader? dbDataReader = null;
            Data.Datasource.GetDatasource(mDatasource, ref dbDataReader);
            dbDataReader?.Close();
        }
    }
}