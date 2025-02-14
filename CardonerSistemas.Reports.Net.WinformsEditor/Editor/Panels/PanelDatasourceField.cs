namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceField : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.DatasourceField? _datasourceField;
        private readonly string _applicationTitle;

        public class FieldEventArgs : EventArgs
        {
            public short FieldId { get; set; }
            public string NameOld { get; set; } = string.Empty;
            public string NameNew { get; set; } = string.Empty;
            public System.Data.DbType TypeOld { get; set; } = System.Data.DbType.Object;
            public System.Data.DbType TypeNew { get; set; } = System.Data.DbType.Object;
            public object? ValueOld { get; set; }
            public object? ValueNew { get; set; }
        }

        public delegate void FieldHandler(object sender, FieldEventArgs e);

        public event FieldHandler? FieldUpdated;
        public event FieldHandler? FieldDeleted;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceField(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;

            FillTypes();
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (System.Data.DbType dbType in Enum.GetValues<System.Data.DbType>())
            {
                items.Add(new KeyValuePair<int, string>((int)dbType, dbType.ToString()));
            }
            comboBoxType.DataSource = items;
        }

        #endregion Initialization

        #region Events

        private void ControlFocusEnter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_datasourceField is null)
            {
                return;
            }
            textBoxName.Text = _datasourceField.Name;
            comboBoxType.SelectedValue = (int)_datasourceField.Type;
        }

        internal void ShowProperties(short fieldId)
        {
            if (_report.Datasource is null)
            {
                return;
            }
            _datasourceField = _report.Datasource.Fields.FirstOrDefault(f => f.FieldId == fieldId);
            if (_datasourceField is null)
            {
                return;
            }
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_datasourceField is null)
            {
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNameRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (_report.Datasource is not null && _report.Datasource.Fields.Any(f => f.Name == textBoxName.Text.Trim() && f.FieldId != _datasourceField.FieldId))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
            FieldEventArgs fieldEventArgs = new()
            {
                FieldId = _datasourceField.FieldId,
                NameOld = _datasourceField.Name,
                TypeOld = _datasourceField.Type
            };
            _datasourceField.Name = textBoxName.Text.Trim();
            _datasourceField.Type = (System.Data.DbType)comboBoxType.SelectedValue;
            if (FieldUpdated is not null)
            {
                fieldEventArgs.NameNew = _datasourceField.Name;
                fieldEventArgs.TypeNew = _datasourceField.Type;
                FieldUpdated(this, fieldEventArgs);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_report.Datasource is null || _datasourceField is null || MessageBox.Show(string.Format(Properties.Resources.StringDatasourceFieldDeleteConfirmation, _datasourceField.Name), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Datasource.Fields.Remove(_datasourceField);
            if (FieldDeleted is not null)
            {
                FieldEventArgs fieldEventArgs = new()
                {
                    FieldId = _datasourceField.FieldId,
                    NameOld = _datasourceField.Name,
                    TypeOld = _datasourceField.Type
                };
                FieldDeleted(this, fieldEventArgs);
            }
        }

        #endregion Methods

    }
}
