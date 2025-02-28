﻿using System.Windows.Forms;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelLine : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Line? _line;
        private readonly string _applicationTitle;

        public delegate void LineHandler(object sender, short lineId, short section1Id);

        public event LineHandler? LineUpdated;
        public event LineHandler? LineDeleted;

        #endregion Declarations

        #region Initialization

        public PanelLine(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            numericUpDownThickness.Maximum = Engine.Pdf.ThicknessMaxValue;
            numericUpDownPositionX1.DecimalPlaces = Engine.Pdf.UnitsDecimalPlaces;
            numericUpDownPositionX1.Maximum = Engine.Pdf.PositionMaxValue;
            numericUpDownPositionY1.DecimalPlaces = Engine.Pdf.UnitsDecimalPlaces;
            numericUpDownPositionY1.Maximum = Engine.Pdf.PositionMaxValue;
            numericUpDownPositionX2.DecimalPlaces = Engine.Pdf.UnitsDecimalPlaces;
            numericUpDownPositionX2.Maximum = Engine.Pdf.PositionMaxValue;
            numericUpDownPositionY2.DecimalPlaces = Engine.Pdf.UnitsDecimalPlaces;
            numericUpDownPositionY2.Maximum = Engine.Pdf.PositionMaxValue;

            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;
            buttonDelete.Text = Properties.Resources.StringLinesDelete;

            FillSections();
        }

        private void FillSections()
        {
            comboBoxSection1.ValueMember = "Key";
            comboBoxSection1.DisplayMember = "Value";
            comboBoxSection2.ValueMember = "Key";
            comboBoxSection2.DisplayMember = "Value";
            ICollection<KeyValuePair<short, string>> items1 = [];
            ICollection<KeyValuePair<short, string>> items2 = [];
            foreach (Model.Section section in _report.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                items1.Add(new KeyValuePair<short, string>(section.SectionId, section.DisplayName));
                items2.Add(new KeyValuePair<short, string>(section.SectionId, section.DisplayName));
            }
            comboBoxSection1.DataSource = items1;
            comboBoxSection2.DataSource = items2;
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

        private void ColorChange(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxColor.Tag = colorDialog.Color;
                textBoxColor.Text = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_line is null)
            {
                return;
            }
            textBoxColor.Text = _line.ColorHex;
            numericUpDownThickness.Value = _line.Thickness;
            comboBoxSection1.SelectedValue = _line.SectionId1;
            numericUpDownPositionX1.Value = _line.PositionX1;
            numericUpDownPositionY1.Value = _line.PositionY1;
            comboBoxSection2.SelectedValue = _line.SectionId2;
            numericUpDownPositionX2.Value = _line.PositionX2;
            numericUpDownPositionY2.Value = _line.PositionY2;
        }

        internal void ShowProperties(short lineId)
        {
            _line = _report.Lines.FirstOrDefault(l => l.LineId == lineId);
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_line is null)
            {
                return;
            }
            if (textBoxColor.Tag is null)
            {
                MessageBox.Show(Properties.Resources.StringLineColorRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonColor.Focus();
                return;
            }
            if (comboBoxSection1.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringLineSectionRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection1.Focus();
                return;
            }
            if (comboBoxSection2.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringLineSectionRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection2.Focus();
                return;
            }
            Color color = (Color)textBoxColor.Tag;
            _line.ColorRed = color.R;
            _line.ColorGreen = color.G;
            _line.ColorBlue = color.B;
            _line.Thickness = numericUpDownThickness.Value;
            _line.SectionId1 = (short)comboBoxSection1.SelectedValue;
            _line.PositionX1 = numericUpDownPositionX1.Value;
            _line.PositionY1 = numericUpDownPositionY1.Value;
            _line.SectionId2 = (short)comboBoxSection2.SelectedValue;
            _line.PositionX2 = numericUpDownPositionX2.Value;
            _line.PositionY2 = numericUpDownPositionY2.Value;

            if (LineUpdated is not null)
            {
                LineUpdated(this, _line.LineId, _line.SectionId1);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_report.Datasource is null || _line is null || MessageBox.Show(string.Format(Properties.Resources.StringLineDeleteConfirmation, _line.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Lines.Remove(_line);
            if (LineDeleted is not null)
            {
                LineDeleted(this, _line.LineId, _line.SectionId1);
            }
        }

        #endregion Methods

    }
}
