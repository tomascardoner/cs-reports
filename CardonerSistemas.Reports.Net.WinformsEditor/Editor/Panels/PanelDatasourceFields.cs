using System.Data.Common;
using System.Globalization;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;

public partial class PanelDatasourceFields : UserControl
{

    #region Declarations

    private readonly string _applicationTitle;
    private readonly Model.Report _report;

    public event EventHandler<EventHandlers.DatasourceFieldEventArgs>? FieldAdded;
    public event EventHandler<EventHandlers.DatasourceFieldEventArgs>? FieldsUpdated;

    #endregion Declarations

    #region Initialization

    public PanelDatasourceFields(Model.Report report, string applicationTitle)
    {
        InitializeComponent();
        _report = report;
        _applicationTitle = applicationTitle;
        InitializeForm();
    }

    private void InitializeForm()
    {
        buttonAdd.Text = Properties.Resources.StringDatasourceFieldsAdd;
    }

    #endregion Initialization

    #region Methods

    public void ShowProperties()
    {
        if (_report.Datasource is null)
        {
            return;
        }

        labelCounter.Text = _report.Datasource.Fields.Count switch
        {
            0 => Properties.Resources.StringDatasourceFieldsCounterEmpty,
            1 => Properties.Resources.StringDatasourceFieldsCounterOne,
            _ => string.Format(CultureInfo.CurrentCulture, Properties.Resources.StringDatasourceFieldsCounter, _report.Datasource.Fields.Count)
        };
    }

    private void Add(object sender, EventArgs e)
    {
        if (_report.Datasource is null)
        {
            return;
        }

        Model.DatasourceField? datasourceField = _report.Datasource.Fields.FirstOrDefault(f => f.Name.Trim() == Properties.Resources.StringDatasourceFieldNameNew);
        if (datasourceField is null)
        {
            datasourceField = new Model.DatasourceField(_report.Datasource) { Name = Properties.Resources.StringDatasourceFieldNameNew };
            _report.Datasource.Fields.Add(datasourceField);
        }
        else
        {
            MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        if (FieldAdded is not null)
        {
            FieldAdded(this, new EventHandlers.DatasourceFieldEventArgs(datasourceField.FieldId));
        }
    }

    private void GetFields(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_report.Datasource?.ConnectionString))
        {
            MessageBox.Show(Properties.Resources.StringDatasourceConnectionStringRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (_report.Datasource.Parameters.Any(p => p.Value is null) && MessageBox.Show(Properties.Resources.StringDatasourceFieldsGetWithNullParametersConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        {
            return;
        }

        if (MessageBox.Show(Properties.Resources.StringDatasourceFieldsGetConfirmation, _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        {
            return;
        }

        // Open the datasource
        DbDataReader? dbDataReader = null;
        Data.Datasource.GetDatasource(_report.Datasource, ref dbDataReader);
        dbDataReader?.Close();
        if (FieldsUpdated is not null)
        {
            FieldsUpdated(this, new EventHandlers.DatasourceFieldEventArgs(0));
        }
    }

    #endregion Methods

}
