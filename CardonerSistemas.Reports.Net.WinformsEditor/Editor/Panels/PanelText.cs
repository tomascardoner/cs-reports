using System.Globalization;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels;

public partial class PanelText : UserControl
{

    #region Declarations

    private readonly Model.Report _report;
    private Model.Text? _text;
    private readonly string _applicationTitle;

    public event EventHandler<EventHandlers.TextEventArgs>? TextUpdated;
    public event EventHandler<EventHandlers.TextEventArgs>? TextDeleted;

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
            comboBoxFieldParameterFormula.Items.Clear();
            return;
        }

        comboBoxFieldParameterFormula.DisplayMember = "Value";
        comboBoxFieldParameterFormula.ValueMember = "Key";
        ICollection<KeyValuePair<short, string>> items = [];
        foreach (Model.DatasourceField datasourceField in _report.Datasource.Fields.OrderBy(f => f.Name))
        {
            items.Add(new KeyValuePair<short, string>(datasourceField.FieldId, datasourceField.Name));
        }

        comboBoxFieldParameterFormula.DataSource = items;
    }

    private void FillComboBoxDatasourceParameters()
    {
        if (_report.Datasource is null)
        {
            comboBoxFieldParameterFormula.Items.Clear();
            return;
        }

        comboBoxFieldParameterFormula.DisplayMember = "Value";
        comboBoxFieldParameterFormula.ValueMember = "Key";
        ICollection<KeyValuePair<short, string>> items = [];
        foreach (Model.DatasourceParameter datasourceParameter in _report.Datasource.Parameters.OrderBy(p => p.Name))
        {
            items.Add(new KeyValuePair<short, string>(datasourceParameter.ParameterId, datasourceParameter.Name));
        }

        comboBoxFieldParameterFormula.DataSource = items;
    }

    private void FillComboBoxReportParameters()
    {
        comboBoxFieldParameterFormula.DisplayMember = "Value";
        comboBoxFieldParameterFormula.ValueMember = "Key";
        ICollection<KeyValuePair<short, string>> items = [];
        foreach (Model.ReportParameter reportParameter in _report.Parameters.OrderBy(p => p.Name))
        {
            items.Add(new KeyValuePair<short, string>(reportParameter.ParameterId, reportParameter.Name));
        }

        comboBoxFieldParameterFormula.DataSource = items;
    }

    private void FillComboBoxFormulas()
    {
        comboBoxFieldParameterFormula.DisplayMember = "Value";
        comboBoxFieldParameterFormula.ValueMember = "Key";
        ICollection<KeyValuePair<short, string>> items = [];
        foreach (Model.Formula formula in _report.Formulas.OrderBy(f => f.Name))
        {
            items.Add(new KeyValuePair<short, string>(formula.FormulaId, formula.Name));
        }

        comboBoxFieldParameterFormula.DataSource = items;
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
        labelFieldParameterFormula.Text = FriendlyNames.GetTextTypeShort(textType) + ":";
        labelFieldParameterFormula.Visible = textType != Model.Text.TextTypes.Static;
        comboBoxFieldParameterFormula.Visible = textType != Model.Text.TextTypes.Static;
        labelStaticText.Visible = textType == Model.Text.TextTypes.Static;
        textBoxStaticText.Visible = textType == Model.Text.TextTypes.Static;
        labelFormat.Visible = textType != Model.Text.TextTypes.Static;
        textBoxFormat.Visible = textType != Model.Text.TextTypes.Static;

        switch (textType)
        {
            case Model.Text.TextTypes.DatasourceField:
                FillComboBoxDatasourceFields();
                break;
            case Model.Text.TextTypes.DatasourceParameter:
                FillComboBoxDatasourceParameters();
                break;
            case Model.Text.TextTypes.ReportParameter:
                FillComboBoxReportParameters();
                break;
            case Model.Text.TextTypes.Formula:
                FillComboBoxFormulas();
                break;
            case Model.Text.TextTypes.Static:
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

        textBoxStaticText.Text = _text.TextType == Model.Text.TextTypes.Static ? _text.StaticText : string.Empty;

        if (_text.TextType == Model.Text.TextTypes.DatasourceField && _text.DatasourceFieldId is not null)
        {
            comboBoxFieldParameterFormula.SelectedValue = _text.DatasourceFieldId;
        }
        else if (_text.TextType == Model.Text.TextTypes.DatasourceParameter && _text.DatasourceParameterId is not null)
        {
            comboBoxFieldParameterFormula.SelectedValue = _text.DatasourceParameterId;
        }
        else if (_text.TextType == Model.Text.TextTypes.ReportParameter && _text.ReportParameterId is not null)
        {
            comboBoxFieldParameterFormula.SelectedValue = _text.ReportParameterId;
        }
        else if (_text.TextType == Model.Text.TextTypes.Formula && _text.FormuladId is not null)
        {
            comboBoxFieldParameterFormula.SelectedValue = _text.FormuladId;
        }
        else
        {
            comboBoxFieldParameterFormula.SelectedIndex = -1;
        }

        textBoxFormat.Text = _text.TextType == Model.Text.TextTypes.Static ? string.Empty : _text.Format;

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
        comboBoxWordWrapType.SelectedValue = (int)_text.WordWrapType;
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
        if ((textType == Model.Text.TextTypes.DatasourceField || textType == Model.Text.TextTypes.DatasourceParameter || textType == Model.Text.TextTypes.ReportParameter || textType == Model.Text.TextTypes.Formula) && comboBoxFieldParameterFormula.SelectedValue is null)
        {
            MessageBox.Show(string.Format(CultureInfo.InvariantCulture, Properties.Resources.StringTextFieldParameterFormulaRequired, FriendlyNames.GetTextTypeShort(textType).ToLower(CultureInfo.CurrentCulture)), _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            comboBoxFieldParameterFormula.Focus();
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
        _text.StaticText = textType == Model.Text.TextTypes.Static ? textBoxStaticText.Text : null!;

        _text.DatasourceFieldId = textType == Model.Text.TextTypes.DatasourceField ? (short)comboBoxFieldParameterFormula.SelectedValue! : null;

        _text.DatasourceParameterId = textType == Model.Text.TextTypes.DatasourceParameter ? (short)comboBoxFieldParameterFormula.SelectedValue! : null;

        _text.ReportParameterId = textType == Model.Text.TextTypes.ReportParameter ? (short)comboBoxFieldParameterFormula.SelectedValue! : null;

        _text.FormuladId = textType == Model.Text.TextTypes.Formula ? (short)comboBoxFieldParameterFormula.SelectedValue! : null;

        _text.Format = textType == Model.Text.TextTypes.Static ? null! : textBoxFormat.Text.Trim();

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
            TextUpdated(this, new EventHandlers.TextEventArgs(_text.TextId, _text.SectionId));
        }
    }

    private void ResetChanges(object sender, EventArgs e)
    {
        ShowProperties();
    }

    private void Delete(object sender, EventArgs e)
    {
        if (_text is null || MessageBox.Show(string.Format(CultureInfo.InvariantCulture, Properties.Resources.StringTextDeleteConfirmation, _text.DisplayName(_report)), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        {
            return;
        }

        _report.Texts.Remove(_text);
        if (TextDeleted is not null)
        {
            TextDeleted(this, new EventHandlers.TextEventArgs(_text.TextId, _text.SectionId));
        }
    }

    #endregion Methods

}
