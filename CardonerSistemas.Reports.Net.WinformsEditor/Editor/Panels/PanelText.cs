namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelText : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Text? _text;
        private readonly string _applicationTitle;

        public delegate void TextHandler(object sender, short textId, short section1Id);

        public event TextHandler? TextUpdated;
        public event TextHandler? TextDeleted;

        #endregion Declarations

        #region Initialization

        public PanelText(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Common.InitializeNumericUpDownControlForPoints(numericUpDownBorderThickness);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionX);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionY);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownWidth);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownHeight);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownCharacterSpacing);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownWordSpacing);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownLineSpacing);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownParagraphIndent);

            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;
            buttonDelete.Text = Properties.Resources.StringTextsDelete;

            FillComboBoxTextTypes();
            FillComboBoxFonts();
            Common.FillComboBoxBrushes(comboBoxBrush, _report, false);
            Common.FillComboBoxSections(comboBoxSection, _report);
            FillComboBoxHorizontalAlignments();
            FillComboBoxVerticalAlignments();
            FillComboBoxWordWrapTypes();
            FillComboBoxSubSuperScript();
        }

        private void FillComboBoxTextTypes()
        {
            comboBoxTextType.DisplayMember = "Value";
            comboBoxTextType.ValueMember = "Key";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Text.TextTypes type in Enum.GetValues<Model.Text.TextTypes>())
            {
                items.Add(new KeyValuePair<int, string>((int)type, FriendlyNames.GetTextType(type)));
            }
            comboBoxTextType.DataSource = items;
        }

        private void FillComboBoxDatasourceFields()
        {
            if (_report.Datasource is null)
            {
                comboBoxFieldOrParameter.Items.Clear();
                return;
            }
            comboBoxFieldOrParameter.DisplayMember = "Value";
            comboBoxFieldOrParameter.ValueMember = "Key";
            ICollection<KeyValuePair<short, string>> items = [];
            foreach (Model.DatasourceField datasourceField in _report.Datasource.Fields.OrderBy(f => f.Name))
            {
                items.Add(new KeyValuePair<short, string>(datasourceField.FieldId, datasourceField.Name));
            }
            comboBoxFieldOrParameter.DataSource = items;
        }

        private void FillComboBoxDatasourceParameters()
        {
            if (_report.Datasource is null)
            {
                comboBoxFieldOrParameter.Items.Clear();
                return;
            }
            comboBoxFieldOrParameter.DisplayMember = "Value";
            comboBoxFieldOrParameter.ValueMember = "Key";
            ICollection<KeyValuePair<string, string>> items = [];
            foreach (string datasourceParameterName in _report.Datasource.Parameters.OrderBy(p => p.Name).Select(p => p.Name))
            {
                items.Add(new KeyValuePair<string, string>(datasourceParameterName, datasourceParameterName));
            }
            comboBoxFieldOrParameter.DataSource = items;
        }

        private void FillComboBoxReportParameters()
        {
            comboBoxFieldOrParameter.DisplayMember = "Value";
            comboBoxFieldOrParameter.ValueMember = "Key";
            ICollection<KeyValuePair<string, string>> items = [];
            foreach (string reportParameterName in _report.Parameters.OrderBy(p => p.Name).Select(p => p.Name))
            {
                items.Add(new KeyValuePair<string, string>(reportParameterName, reportParameterName));
            }
            comboBoxFieldOrParameter.DataSource = items;
        }

        private void FillComboBoxFonts()
        {
            comboBoxFont.DisplayMember = "Value";
            comboBoxFont.ValueMember = "Key";
            ICollection<KeyValuePair<short, string>> items = [];
            foreach (Model.Font font in _report.Fonts.OrderBy(f => f.DisplayNameShort))
            {
                items.Add(new KeyValuePair<short, string>(font.FontId, font.DisplayNameShort));
            }
            comboBoxFont.DataSource = items;
        }

        private void FillComboBoxHorizontalAlignments()
        {
            comboBoxHorizontalAlignment.DisplayMember = "Value";
            comboBoxHorizontalAlignment.ValueMember = "Key";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Text.HorizontalAlignments horizontalAlignment in Enum.GetValues<Model.Text.HorizontalAlignments>())
            {
                items.Add(new KeyValuePair<int, string>((int)horizontalAlignment, FriendlyNames.GetTextHorizontalAlignment(horizontalAlignment)));
            }
            comboBoxHorizontalAlignment.DataSource = items;
        }

        private void FillComboBoxVerticalAlignments()
        {
            comboBoxVerticalAlignment.DisplayMember = "Value";
            comboBoxVerticalAlignment.ValueMember = "Key";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Text.VerticalAlignments verticalAlignment in Enum.GetValues<Model.Text.VerticalAlignments>())
            {
                items.Add(new KeyValuePair<int, string>((int)verticalAlignment, FriendlyNames.GetTextVerticalAlignment(verticalAlignment)));
            }
            comboBoxVerticalAlignment.DataSource = items;
        }

        private void FillComboBoxWordWrapTypes()
        {
            comboBoxWordWrapType.DisplayMember = "Value";
            comboBoxWordWrapType.ValueMember = "Key";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Text.WordWrapTypes type in Enum.GetValues<Model.Text.WordWrapTypes>())
            {
                items.Add(new KeyValuePair<int, string>((int)type, FriendlyNames.GetTextWordWrapType(type)));
            }
            comboBoxWordWrapType.DataSource = items;
        }

        private void FillComboBoxSubSuperScript()
        {
            comboBoxSubSuperScript.DisplayMember = "Value";
            comboBoxSubSuperScript.ValueMember = "Key";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Text.SubSuperScripts subSuperScript in Enum.GetValues<Model.Text.SubSuperScripts>())
            {
                items.Add(new KeyValuePair<int, string>((int)subSuperScript, FriendlyNames.GetTextSubSuperScript(subSuperScript)));
            }
            comboBoxSubSuperScript.DataSource = items;
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

        private void TextTypeChanged(object sender, EventArgs e)
        {
            if (comboBoxTextType.SelectedValue is null)
            {
                return;
            }
            Model.Text.TextTypes textType = (Model.Text.TextTypes)comboBoxTextType.SelectedValue;
            labelFieldOrParameter.Visible = textType != Model.Text.TextTypes.Static && textType != Model.Text.TextTypes.Formula;
            comboBoxFieldOrParameter.Visible = textType != Model.Text.TextTypes.Static && textType != Model.Text.TextTypes.Formula;
            labelValue.Visible = textType == Model.Text.TextTypes.Static || textType == Model.Text.TextTypes.Formula;
            textBoxValue.Visible = textType == Model.Text.TextTypes.Static || textType == Model.Text.TextTypes.Formula;
            labelFormat.Visible = textType != Model.Text.TextTypes.Static && textType != Model.Text.TextTypes.Formula;
            textBoxFormat.Visible = textType != Model.Text.TextTypes.Static && textType != Model.Text.TextTypes.Formula;

            switch (textType)
            {
                case Model.Text.TextTypes.DatasourceField:
                    labelFieldOrParameter.Text = "Field:";
                    FillComboBoxDatasourceFields();
                    break;
                case Model.Text.TextTypes.DatasourceParameter:
                    labelFieldOrParameter.Text = "Parameter:";
                    FillComboBoxDatasourceParameters();
                    break;
                case Model.Text.TextTypes.ReportParameter:
                    labelFieldOrParameter.Text = "Parameter:";
                    FillComboBoxReportParameters();
                    break;
                default:
                    break;
            }
        }

        private void ColorChange(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBorderColor.Tag = colorDialog.Color;
                textBoxBorderColor.Text = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_text is null)
            {
                return;
            }
            comboBoxTextType.SelectedValue = (int)_text.TextType;
            switch ((Model.Text.TextTypes)comboBoxTextType.SelectedValue)
            {
                case Model.Text.TextTypes.DatasourceField:
                    comboBoxFieldOrParameter.SelectedValue = _text.DatasourceFieldId;
                    textBoxFormat.Text = _text.Format;
                    break;
                case Model.Text.TextTypes.DatasourceParameter:
                case Model.Text.TextTypes.ReportParameter:
                    comboBoxFieldOrParameter.SelectedValue = _text.Value;
                    textBoxFormat.Text = _text.Format;
                    break;
                default:
                    textBoxValue.Text = _text.Value;
                    break;
            }
            comboBoxFont.SelectedValue = _text.FontId;
            textBoxBorderColor.Text = _text.BorderColorHex;
            textBoxBorderColor.Tag = Color.FromArgb(_text.BorderColorRed, _text.BorderColorGreen, _text.BorderColorBlue);
            numericUpDownBorderThickness.Value = _text.BorderThickness;
            comboBoxBrush.SelectedValue = _text.BrushId;
            comboBoxSection.SelectedValue = _text.SectionId;
            numericUpDownPositionX.Value = _text.PositionX;
            numericUpDownPositionY.Value = _text.PositionY;
            numericUpDownWidth.Value = _text.Width;
            numericUpDownHeight.Value = _text.Height;
            comboBoxHorizontalAlignment.SelectedValue = (int)_text.HorizontalAlignment;
            comboBoxVerticalAlignment.SelectedValue = (int)_text.VerticalAlignment;
            comboBoxWordWrapType.SelectedValue= (int)_text.WordWrapType;
            numericUpDownCharacterSpacing.Value = _text.CharacterSpacing;
            numericUpDownWordSpacing.Value = _text.WordSpacing;
            numericUpDownLineSpacing.Value = _text.LineSpacing;
            comboBoxSubSuperScript.SelectedValue = (int)_text.SubSuperScript;
            numericUpDownParagraphIndent.Value = _text.ParagraphIndent;
        }

        internal void ShowProperties(short textId)
        {
            _text = _report.Texts.FirstOrDefault(t => t.TextId == textId);
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_text is null)
            {
                return;
            }
            if (comboBoxTextType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTextType.Focus();
                return;
            }
            Model.Text.TextTypes textType = (Model.Text.TextTypes)comboBoxTextType.SelectedValue;
            if ((textType == Model.Text.TextTypes.DatasourceField || textType == Model.Text.TextTypes.DatasourceParameter || textType == Model.Text.TextTypes.ReportParameter) && comboBoxFieldOrParameter.SelectedValue is null)
            {
                MessageBox.Show(textType == Model.Text.TextTypes.DatasourceField ? Properties.Resources.StringTextFieldRequired : Properties.Resources.StringTextParameterRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxFieldOrParameter.Focus();
                return;
            }
            if (comboBoxFont.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextFontRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxFont.Focus();
                return;
            }
            if (textBoxBorderColor.Tag is null)
            {
                MessageBox.Show(Properties.Resources.StringTextBorderColorRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonBorderColor.Focus();
                return;
            }
            if (comboBoxBrush.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextBrushRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxBrush.Focus();
                return;
            }
            if (comboBoxSection.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextSectionRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection.Focus();
                return;
            }
            if (comboBoxHorizontalAlignment.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextHorizontalAlignmentRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxHorizontalAlignment.Focus();
                return;
            }
            if (comboBoxVerticalAlignment.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextVerticalAlignmentRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxVerticalAlignment.Focus();
                return;
            }
            if (comboBoxWordWrapType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextWordWrapTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxWordWrapType.Focus();
                return;
            }
            if (comboBoxSubSuperScript.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringTextSubSuperScriptRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSubSuperScript.Focus();
                return;
            }

            _text.TextType = textType;

#pragma warning disable CS8605 // Unboxing a possibly null value.
            switch (textType)
            {
                case Model.Text.TextTypes.DatasourceField:
                    _text.DatasourceFieldId = (short)comboBoxFieldOrParameter.SelectedValue;
                    _text.Value = comboBoxFieldOrParameter.Text;
                    _text.Format = textBoxFormat.Text.Trim();
                    break;
                case Model.Text.TextTypes.DatasourceParameter:
                case Model.Text.TextTypes.ReportParameter:
                    _text.Value = comboBoxFieldOrParameter.Text;
                    _text.Format = textBoxFormat.Text.Trim();
                    break;
                default:
                    textBoxValue.Text = _text.Value;
                    break;
            }
#pragma warning restore CS8605 // Unboxing a possibly null value.

            _text.FontId = (short)comboBoxFont.SelectedValue;
            Color color = (Color)textBoxBorderColor.Tag;
            _text.BorderColorRed = color.R;
            _text.BorderColorGreen = color.G;
            _text.BorderColorBlue = color.B;
            _text.BorderThickness = numericUpDownBorderThickness.Value;
            _text.BrushId = (short)comboBoxBrush.SelectedValue;
            _text.SectionId = (short)comboBoxSection.SelectedValue;
            _text.PositionX = numericUpDownPositionX.Value;
            _text.PositionY = numericUpDownPositionY.Value;
            _text.Width = numericUpDownWidth.Value;
            _text.Height = numericUpDownHeight.Value;
            _text.HorizontalAlignment = (Model.Text.HorizontalAlignments)comboBoxHorizontalAlignment.SelectedValue;
            _text.VerticalAlignment = (Model.Text.VerticalAlignments)comboBoxVerticalAlignment.SelectedValue;
            _text.WordWrapType = (Model.Text.WordWrapTypes)comboBoxWordWrapType.SelectedValue;
            _text.CharacterSpacing = numericUpDownCharacterSpacing.Value;
            _text.WordSpacing = numericUpDownWordSpacing.Value;
            _text.LineSpacing = numericUpDownLineSpacing.Value;
            _text.SubSuperScript = (Model.Text.SubSuperScripts)comboBoxSubSuperScript.SelectedValue;
            _text.ParagraphIndent = numericUpDownParagraphIndent.Value;

            if (TextUpdated is not null)
            {
                TextUpdated(this, _text.TextId, _text.SectionId);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_text is null || MessageBox.Show(string.Format(Properties.Resources.StringTextDeleteConfirmation, _text.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Texts.Remove(_text);
            if (TextDeleted is not null)
            {
                TextDeleted(this, _text.TextId, _text.SectionId);
            }
        }

        #endregion Methods

    }
}
