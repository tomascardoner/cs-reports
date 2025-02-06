namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelDatasourceParameter : UserControl
    {
        private Model.DatasourceParameter mDatasourceParameter;
        private readonly string mApplicationTitle;

        public PanelDatasourceParameter(Model.DatasourceParameter datasourceParameter, string applicationTitle)
        {
            InitializeComponent();
            mDatasourceParameter = datasourceParameter;
            mApplicationTitle = applicationTitle;

            FillTypes();
            ShowProperties();
        }

        public void SetDatasourceParameter(Model.DatasourceParameter datasourceParameter)
        {
            mDatasourceParameter = datasourceParameter;
            ShowProperties();
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

        private void TextBoxs_Enter(object sender, EventArgs e)
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

        private void ShowProperties()
        {
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

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterNameRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringDatasourceParameterTypeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mDatasourceParameter.Name = textBoxName.Text;
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
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }
    }
}