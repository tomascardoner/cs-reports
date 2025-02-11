using System.Reflection;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceField : UserControl
    {

        #region Declarations

        private readonly Model.Report mReport;
        private Model.DatasourceField? mDatasourceField;
        private readonly string mApplicationTitle;

        public class FieldEventArgs : EventArgs
        {
            public string NameOld { get; set; } = string.Empty;
            public string NameNew { get; set; } = string.Empty;
            public Type TypeOld { get; set; } = typeof(object);
            public Type TypeNew { get; set; } = typeof(object);
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
            mReport = report;
            mApplicationTitle = applicationTitle;

            FillTypes();
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
            {
                items.Add(new KeyValuePair<int, string>(0, item.ToString()));
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
            if (mDatasourceField is null)
            {
                return;
            }
            textBoxName.Text = mDatasourceField.Name;
            //comboBoxType.SelectedValue = (int)mDatasourceField.Type;
        }

        internal void ShowProperties(short fieldId)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            mDatasourceField = mReport.Datasource.Fields.FirstOrDefault(f => f.FieldId == fieldId);
            if (mDatasourceField is null)
            {
                return;
            }
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (mDatasourceField is null)
            {
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNameRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldTypeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (mReport.Datasource is not null && mReport.Datasource.Fields.Any(p => p.Name == textBoxName.Text.Trim()))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceFieldNewAlreadyExists, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
            FieldEventArgs fieldEventArgs = new()
            {
                NameOld = mDatasourceField.Name,
                TypeOld = mDatasourceField.Type
            };
            mDatasourceField.Name = textBoxName.Text.Trim();
            mDatasourceField.Type = (Type)comboBoxType.SelectedValue;
            if (FieldUpdated is not null)
            {
                fieldEventArgs.NameNew = mDatasourceField.Name;
                fieldEventArgs.TypeNew = mDatasourceField.Type;
                FieldUpdated(this, fieldEventArgs);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (mReport.Datasource is null || mDatasourceField is null || MessageBox.Show(Properties.Resources.StringDatasourceFieldDeleteConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            mReport.Datasource.Fields.Remove(mDatasourceField);
            if (FieldDeleted is not null)
            {
                FieldEventArgs fieldEventArgs = new()
                {
                    NameOld = mDatasourceField.Name,
                    TypeOld = mDatasourceField.Type
                };
                FieldDeleted(this, fieldEventArgs);
            }
        }

        #endregion Methods

    }
}