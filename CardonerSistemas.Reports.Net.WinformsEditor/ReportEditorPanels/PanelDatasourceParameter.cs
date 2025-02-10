﻿namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceParameter : UserControl
    {

        #region Declarations

        private readonly Model.Report mReport;
        private Model.DatasourceParameter? mDatasourceParameter;
        private readonly string mApplicationTitle;

        public class ParameterEventArgs : EventArgs
        {
            public string NameOld { get; set; } = string.Empty;
            public string NameNew { get; set; } = string.Empty;
            public System.Data.DbType TypeOld { get; set; }
            public System.Data.DbType TypeNew { get; set; }
            public object? ValueOld { get; set; }
            public object? ValueNew { get; set; }
        }

        public delegate void DatasourceParameterHandler(object sender, ParameterEventArgs e);

        public event DatasourceParameterHandler? ParameterUpdated;
        public event DatasourceParameterHandler? ParameterDeleted;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceParameter(Model.Report report, string applicationTitle)
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
            else if (sender is NumericUpDown numericUpDown)
            {
                numericUpDown.Select(0, numericUpDown.Text.Length);
            }
        }

        private static Model.Value.Types GetValueTypeFromType(System.Data.DbType type)
        {
            return type switch
            {
                System.Data.DbType.String or System.Data.DbType.AnsiString or System.Data.DbType.AnsiStringFixedLength or System.Data.DbType.StringFixedLength or System.Data.DbType.Xml => Model.Value.Types.Text,
                System.Data.DbType.Boolean => Model.Value.Types.YesNo,
                System.Data.DbType.Byte or System.Data.DbType.SByte or System.Data.DbType.Int16 or System.Data.DbType.UInt16 or System.Data.DbType.Int32 or System.Data.DbType.UInt32 or System.Data.DbType.Int64 or System.Data.DbType.UInt64 or System.Data.DbType.VarNumeric => Model.Value.Types.Integer,
                System.Data.DbType.Single or System.Data.DbType.Double or System.Data.DbType.Decimal or System.Data.DbType.Currency => Model.Value.Types.Decimal,
                System.Data.DbType.Date or System.Data.DbType.Time or System.Data.DbType.DateTime or System.Data.DbType.DateTime2 or System.Data.DbType.DateTimeOffset => Model.Value.Types.DateTime,
                System.Data.DbType.Binary or System.Data.DbType.Guid or System.Data.DbType.Object => throw new NotImplementedException("The DbType is not supported."),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "The DbType is not supported."),
            };
        }

        private void TypeChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedValue is null)
            {
                return;
            }

            Model.Value.Types valueType = GetValueTypeFromType((System.Data.DbType)comboBoxType.SelectedValue);

            labelValueText.Visible = valueType == Model.Value.Types.Text;
            textBoxValueText.Visible = valueType == Model.Value.Types.Text;
            labelValueNumeric.Visible = valueType == Model.Value.Types.Integer || valueType == Model.Value.Types.Decimal;
            numericUpDownValueNumeric.Visible = valueType == Model.Value.Types.Integer || valueType == Model.Value.Types.Decimal;
            numericUpDownValueNumeric.DecimalPlaces = valueType == Model.Value.Types.Decimal ? 2 : 0;
            labelValueDateTime.Visible = valueType == Model.Value.Types.DateTime;
            dateTimePickerValueDateTime.Visible = valueType == Model.Value.Types.DateTime;
            labelValueYesNo.Visible = valueType == Model.Value.Types.YesNo;
            checkBoxValueYesNo.Visible = valueType == Model.Value.Types.YesNo;
        }

        private void ValueNullChanged(object sender, EventArgs e)
        {
            textBoxValueText.Enabled = !checkBoxValueNull.Checked;
            numericUpDownValueNumeric.Enabled = !checkBoxValueNull.Checked;
            dateTimePickerValueDateTime.Enabled = !checkBoxValueNull.Checked;
            checkBoxValueYesNo.Enabled = !checkBoxValueNull.Checked;
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (mDatasourceParameter is null)
            {
                return;
            }
            textBoxName.Text = mDatasourceParameter.Name;
            comboBoxType.SelectedValue = (int)mDatasourceParameter.Type;
            checkBoxValueNull.Checked = mDatasourceParameter.Value is null;
            if (mDatasourceParameter.Value is null)
            {
                textBoxValueText.Text = string.Empty;
                numericUpDownValueNumeric.Value = 0;
                dateTimePickerValueDateTime.Value = DateTime.Today;
                checkBoxValueYesNo.Checked = false;
            }
            else
            {
                switch (GetValueTypeFromType((System.Data.DbType)comboBoxType.SelectedValue))
                {
                    case Model.Value.Types.Text:
                        textBoxValueText.Text = (string)mDatasourceParameter.Value;
                        break;
                    case Model.Value.Types.Integer:
                        numericUpDownValueNumeric.Value = (int)mDatasourceParameter.Value;
                        break;
                    case Model.Value.Types.Decimal:
                        numericUpDownValueNumeric.Value = (decimal)mDatasourceParameter.Value;
                        break;
                    case Model.Value.Types.DateTime:
                        dateTimePickerValueDateTime.Value = (DateTime)mDatasourceParameter.Value;
                        break;
                    case Model.Value.Types.YesNo:
                        checkBoxValueYesNo.Checked = (bool)mDatasourceParameter.Value;
                        break;
                }
            }
        }

        internal void ShowProperties(string parameterName)
        {
            if (mReport.Datasource is null)
            {
                return;
            }
            mDatasourceParameter = mReport.Datasource.Parameters.FirstOrDefault(p => p.Name == parameterName);
            if (mDatasourceParameter is null)
            {
                return;
            }
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (mDatasourceParameter is null)
            {
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNameRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterTypeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (mReport.Datasource is not null && mReport.Datasource.Parameters.Any(p => p.Name == textBoxName.Text.Trim()))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNameAlreadyExists, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
            ParameterEventArgs parameterEventArgs = new()
            {
                NameOld = mDatasourceParameter.Name,
                TypeOld = mDatasourceParameter.Type,
                ValueOld = mDatasourceParameter.Value
            };
            mDatasourceParameter.Name = textBoxName.Text.Trim();
            mDatasourceParameter.Type = (System.Data.DbType)comboBoxType.SelectedValue;
            if (checkBoxValueNull.Checked)
            {
                mDatasourceParameter.Value = null;
            }
            else
            {
                switch (GetValueTypeFromType((System.Data.DbType)comboBoxType.SelectedValue))
                {
                    case Model.Value.Types.Text:
                        mDatasourceParameter.Value = textBoxValueText.Text;
                        break;
                    case Model.Value.Types.Integer:
                        mDatasourceParameter.Value = (int)numericUpDownValueNumeric.Value;
                        break;
                    case Model.Value.Types.Decimal:
                        mDatasourceParameter.Value = numericUpDownValueNumeric.Value;
                        break;
                    case Model.Value.Types.DateTime:
                        mDatasourceParameter.Value = dateTimePickerValueDateTime.Value;
                        break;
                    case Model.Value.Types.YesNo:
                        mDatasourceParameter.Value = checkBoxValueYesNo.Checked;
                        break;
                }
            }
            if (ParameterUpdated is not null)
            {
                parameterEventArgs.NameNew = mDatasourceParameter.Name;
                parameterEventArgs.TypeNew = mDatasourceParameter.Type;
                parameterEventArgs.ValueNew = mDatasourceParameter.Value;
                ParameterUpdated(this, parameterEventArgs);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (mReport.Datasource is null || mDatasourceParameter is null || MessageBox.Show(Properties.Resources.StringDatasourceParameterDeleteConfirmation, mApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            mReport.Datasource.Parameters.Remove(mDatasourceParameter);
            if (ParameterDeleted is not null)
            {
                ParameterEventArgs parameterEventArgs = new()
                {
                    NameOld = mDatasourceParameter.Name,
                    TypeOld = mDatasourceParameter.Type,
                    ValueOld = mDatasourceParameter.Value
                };
                ParameterDeleted(this, parameterEventArgs);
            }
        }

        #endregion Methods

    }
}