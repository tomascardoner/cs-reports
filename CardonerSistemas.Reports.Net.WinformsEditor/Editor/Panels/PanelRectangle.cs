namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelRectangle : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Rectangle? _rectangle;
        private readonly string _applicationTitle;

        public delegate void RectangleHandler(object sender, short rectangleId, short section1Id);

        public event RectangleHandler? RectangleUpdated;
        public event RectangleHandler? RectangleDeleted;

        #endregion Declarations

        #region Initialization

        public PanelRectangle(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Common.InitializeNumericUpDownControlForPoints(numericUpDownBorderThickness);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionX1);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionY1);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionX2);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionY2);

            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;
            buttonDelete.Text = Properties.Resources.StringRectanglesDelete;

            Common.FillComboBoxBrushes(comboBoxBrush, _report, true);
            Common.FillComboBoxSections(comboBoxSection1, _report);
            Common.FillComboBoxSections(comboBoxSection2, _report);
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
                textBoxBorderColor.Tag = colorDialog.Color;
                textBoxBorderColor.Text = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_rectangle is null)
            {
                return;
            }
            textBoxBorderColor.Text = _rectangle.BorderColorHex;
            textBoxBorderColor.Tag = Color.FromArgb(_rectangle.BorderColorRed, _rectangle.BorderColorGreen, _rectangle.BorderColorBlue);
            numericUpDownBorderThickness.Value = _rectangle.BorderThickness;
            comboBoxBrush.SelectedValue = _rectangle.BrushId ?? 0;
            comboBoxSection1.SelectedValue = _rectangle.SectionId1;
            numericUpDownPositionX1.Value = _rectangle.PositionX1;
            numericUpDownPositionY1.Value = _rectangle.PositionY1;
            comboBoxSection2.SelectedValue = _rectangle.SectionId2;
            numericUpDownPositionX2.Value = _rectangle.PositionX2;
            numericUpDownPositionY2.Value = _rectangle.PositionY2;
        }

        internal void ShowProperties(short rectangleId)
        {
            _rectangle = _report.Rectangles.FirstOrDefault(l => l.RectangleId == rectangleId);
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_rectangle is null)
            {
                return;
            }
            if (textBoxBorderColor.Tag is null)
            {
                MessageBox.Show(Properties.Resources.StringRectangleBorderColorRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonBorderColor.Focus();
                return;
            }
            if (comboBoxBrush.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringRectangleBrushRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection1.Focus();
                return;
            }
            if (comboBoxSection1.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringRectangleSectionRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection1.Focus();
                return;
            }
            if (comboBoxSection2.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringRectangleSectionRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSection2.Focus();
                return;
            }
            Color color = (Color)textBoxBorderColor.Tag;
            _rectangle.BorderColorRed = color.R;
            _rectangle.BorderColorGreen = color.G;
            _rectangle.BorderColorBlue = color.B;
            _rectangle.BorderThickness = numericUpDownBorderThickness.Value;
            _rectangle.BrushId = (short)comboBoxBrush.SelectedValue == 0 ? null : (short)comboBoxBrush.SelectedValue;
            _rectangle.SectionId1 = (short)comboBoxSection1.SelectedValue;
            _rectangle.PositionX1 = numericUpDownPositionX1.Value;
            _rectangle.PositionY1 = numericUpDownPositionY1.Value;
            _rectangle.SectionId2 = (short)comboBoxSection2.SelectedValue;
            _rectangle.PositionX2 = numericUpDownPositionX2.Value;
            _rectangle.PositionY2 = numericUpDownPositionY2.Value;

            if (RectangleUpdated is not null)
            {
                RectangleUpdated(this, _rectangle.RectangleId, _rectangle.SectionId1);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_rectangle is null || MessageBox.Show(string.Format(Properties.Resources.StringRectangleDeleteConfirmation, _rectangle.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Rectangles.Remove(_rectangle);
            if (RectangleDeleted is not null)
            {
                RectangleDeleted(this, _rectangle.RectangleId, _rectangle.SectionId1);
            }
        }

        #endregion Methods

    }
}
