namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelDatasourceParameter : UserControl
    {

        #region Declarations

        private const int DecimalPlaces = 4;

        private readonly Model.Report _report;
        private Model.DatasourceParameter? mDatasourceParameter;
        private readonly string _applicationTitle;

        public delegate void ParameterHandler(object sender, string parameterName);

        public event ParameterHandler? ParameterUpdated;
        public event ParameterHandler? ParameterDeleted;

        #endregion Declarations

        #region Initialization

        public PanelDatasourceParameter(Model.Report report, string applicationTitle)
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

            // Text value
            labelValueText.Visible = valueType == Model.Value.Types.Text;
            textBoxValueText.Visible = valueType == Model.Value.Types.Text;

            // Numeric value
            labelValueNumeric.Visible = valueType == Model.Value.Types.Integer || valueType == Model.Value.Types.Decimal;
            numericUpDownValueNumeric.Visible = valueType == Model.Value.Types.Integer || valueType == Model.Value.Types.Decimal;
            if (valueType == Model.Value.Types.Integer || valueType == Model.Value.Types.Decimal)
            {
                numericUpDownValueNumeric.DecimalPlaces = valueType == Model.Value.Types.Decimal ? DecimalPlaces : 0;
                switch ((System.Data.DbType)comboBoxType.SelectedValue)
                {
                    case System.Data.DbType.Byte:
                        numericUpDownValueNumeric.Minimum = Byte.MinValue;
                        numericUpDownValueNumeric.Maximum = Byte.MaxValue;
                        break;
                    case System.Data.DbType.Currency:
                    case System.Data.DbType.Decimal:
                    case System.Data.DbType.Double:
                    case System.Data.DbType.Single:
                        numericUpDownValueNumeric.Minimum = Decimal.MinValue;
                        numericUpDownValueNumeric.Maximum = Decimal.MaxValue;
                        break;
                    case System.Data.DbType.Int16:
                        numericUpDownValueNumeric.Minimum = Int16.MinValue;
                        numericUpDownValueNumeric.Maximum = Int16.MaxValue;
                        break;
                    case System.Data.DbType.Int32:
                        numericUpDownValueNumeric.Minimum = Int32.MinValue;
                        numericUpDownValueNumeric.Maximum = Int32.MaxValue;
                        break;
                    case System.Data.DbType.Int64:
                        numericUpDownValueNumeric.Minimum = Int64.MinValue;
                        numericUpDownValueNumeric.Maximum = Int64.MaxValue;
                        break;
                    case System.Data.DbType.SByte:
                        numericUpDownValueNumeric.Minimum = SByte.MinValue;
                        numericUpDownValueNumeric.Maximum = SByte.MaxValue;
                        break;
                    case System.Data.DbType.UInt16:
                        numericUpDownValueNumeric.Minimum = UInt16.MinValue;
                        numericUpDownValueNumeric.Maximum = UInt16.MaxValue;
                        break;
                    case System.Data.DbType.UInt32:
                        numericUpDownValueNumeric.Minimum = UInt32.MinValue;
                        numericUpDownValueNumeric.Maximum = UInt32.MaxValue;
                        break;
                    case System.Data.DbType.UInt64:
                        numericUpDownValueNumeric.Minimum = UInt64.MinValue;
                        numericUpDownValueNumeric.Maximum = UInt64.MaxValue;
                        break;
                    default:
                        break;
                }
            }

            // DateTime value
            labelValueDateTime.Visible = valueType == Model.Value.Types.DateTime;
            dateTimePickerValueDateTime.Visible = valueType == Model.Value.Types.DateTime;

            // Yes-No value
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
            if (_report.Datasource is null)
            {
                return;
            }
            mDatasourceParameter = _report.Datasource.Parameters.FirstOrDefault(p => p.Name == parameterName);
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
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNameRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (mDatasourceParameter.Name != textBoxName.Text.Trim() && _report.Datasource is not null && _report.Datasource.Parameters.Any(p => p.Name == textBoxName.Text.Trim()))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNameAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
            string originalName = mDatasourceParameter.Name;
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
                ParameterUpdated(this, originalName);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_report.Datasource is null || mDatasourceParameter is null || MessageBox.Show(string.Format(Properties.Resources.StringDatasourceParameterDeleteConfirmation, mDatasourceParameter.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Datasource.Parameters.Remove(mDatasourceParameter);
            if (ParameterDeleted is not null)
            {
                ParameterDeleted(this, mDatasourceParameter.Name);
            }
        }

        #endregion Methods

    }
}
