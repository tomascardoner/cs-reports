using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelBrush : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Brush? _brush;
        private readonly string _applicationTitle;

        public delegate void BrushHandler(object sender, short brushId);

        public event BrushHandler? BrushUpdated;
        public event BrushHandler? BrushDeleted;

        #endregion Declarations

        #region Initialization

        public PanelBrush(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionX1);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionY1);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionX2);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownPositionY2);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownRadiusStart);
            Common.InitializeNumericUpDownControlForCentimeters(numericUpDownRadiusEnd);

            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;
            buttonDelete.Text = Properties.Resources.StringBrushesDelete;

            FillTypes();
            FillLinearGradientModes();
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Brush.BrushTypes type in Enum.GetValues<Model.Brush.BrushTypes>())
            {
                items.Add(new KeyValuePair<int, string>((int)type, FriendlyNames.GetBrushType(type)));
            }
            comboBoxType.DataSource = items;
        }

        private void FillLinearGradientModes()
        {
            comboBoxLinearGradientMode.ValueMember = "Key";
            comboBoxLinearGradientMode.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (XLinearGradientMode mode in Enum.GetValues<XLinearGradientMode>())
            {
                items.Add(new KeyValuePair<int, string>((int)mode, FriendlyNames.GetBrushLinearGradientMode(mode)));
            }
            comboBoxLinearGradientMode.DataSource = items;
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

        private void TypeChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedValue is null)
            {
                return;
            }

            Model.Brush.BrushTypes brushType = (Model.Brush.BrushTypes)comboBoxType.SelectedValue;

            labelColor2.Visible = brushType != Model.Brush.BrushTypes.Solid;
            tableLayoutPanelColor2.Visible = brushType != Model.Brush.BrushTypes.Solid;

            labelPositionX1.Visible = brushType != Model.Brush.BrushTypes.Solid;
            numericUpDownPositionX1.Visible = brushType != Model.Brush.BrushTypes.Solid;
            labelPositionY1.Visible = brushType != Model.Brush.BrushTypes.Solid;
            numericUpDownPositionY1.Visible = brushType != Model.Brush.BrushTypes.Solid;
            labelPositionX2.Visible = brushType != Model.Brush.BrushTypes.Solid;
            numericUpDownPositionX2.Visible = brushType != Model.Brush.BrushTypes.Solid;
            labelPositionY2.Visible = brushType != Model.Brush.BrushTypes.Solid;
            numericUpDownPositionY2.Visible = brushType != Model.Brush.BrushTypes.Solid;

            labelLinearGradientMode.Visible = brushType == Model.Brush.BrushTypes.LinealGradient;
            comboBoxLinearGradientMode.Visible = brushType == Model.Brush.BrushTypes.LinealGradient;

            labelRadiusStart.Visible = brushType == Model.Brush.BrushTypes.RadialGradient;
            numericUpDownRadiusStart.Visible = brushType == Model.Brush.BrushTypes.RadialGradient;
            labelRadiusEnd.Visible = brushType == Model.Brush.BrushTypes.RadialGradient;
            numericUpDownRadiusEnd.Visible = brushType == Model.Brush.BrushTypes.RadialGradient;
        }

        private void Color1Change(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxColor1.Tag = colorDialog.Color;
                textBoxColor1.Text = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
            }
        }

        private void Color2Change(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxColor2.Tag = colorDialog.Color;
                textBoxColor2.Text = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_brush is null)
            {
                return;
            }
            comboBoxType.SelectedValue = (int)_brush.Type;
            textBoxColor1.Text = _brush.Color1Hex;
            textBoxColor1.Tag = Color.FromArgb(_brush.Color1Red, _brush.Color1Green, _brush.Color1Blue);
            textBoxColor2.Text = _brush.Color2Hex;
            textBoxColor2.Tag = _brush.Color2Red.HasValue && _brush.Color2Green.HasValue && _brush.Color2Blue.HasValue ? Color.FromArgb(_brush.Color2Red.Value, _brush.Color2Green.Value, _brush.Color2Blue.Value) : null;
            numericUpDownPositionX1.Value = _brush.PositionX1 ?? 0;
            numericUpDownPositionY1.Value = _brush.PositionY1 ?? 0;
            numericUpDownPositionX2.Value = _brush.PositionX2 ?? 0;
            numericUpDownPositionY2.Value = _brush.PositionY2 ?? 0;
            comboBoxLinearGradientMode.SelectedValue = (int)_brush.LinearGradientMode;
            numericUpDownRadiusStart.Value = _brush.RadiusStart ?? 0;
            numericUpDownRadiusEnd.Value = _brush.RadiusEnd ?? 0;
        }

        internal void ShowProperties(short brushId)
        {
            _brush = _report.Brushes.FirstOrDefault(b => b.BrushId == brushId);
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_brush is null)
            {
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringBrushTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (textBoxColor1.Tag is null)
            {
                MessageBox.Show(Properties.Resources.StringLineColorRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonColor1.Focus();
                return;
            }
            if (((Model.Brush.BrushTypes)comboBoxType.SelectedValue) != Model.Brush.BrushTypes.Solid && textBoxColor2.Tag is null)
            {
                MessageBox.Show(Properties.Resources.StringBrushColor2Required, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonColor2.Focus();
                return;
            }
            if (((Model.Brush.BrushTypes)comboBoxType.SelectedValue) == Model.Brush.BrushTypes.LinealGradient && comboBoxLinearGradientMode.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringBrushLiearGradientModeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonColor2.Focus();
                return;
            }
            _brush.Type = (Model.Brush.BrushTypes)comboBoxType.SelectedValue;

            Color color1 = (Color)textBoxColor1.Tag;
            _brush.Color1Red = color1.R;
            _brush.Color1Green = color1.G;
            _brush.Color1Blue = color1.B;

            if (((Model.Brush.BrushTypes)comboBoxType.SelectedValue) != Model.Brush.BrushTypes.Solid)
            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                Color color2 = (Color)textBoxColor2.Tag;
#pragma warning restore CS8605 // Unboxing a possibly null value.
                _brush.Color2Red = color2.R;
                _brush.Color2Green = color2.G;
                _brush.Color2Blue = color2.B;

                _brush.PositionX1 = numericUpDownPositionX1.Value;
                _brush.PositionY1 = numericUpDownPositionY1.Value;
                _brush.PositionX2 = numericUpDownPositionX2.Value;
                _brush.PositionY2 = numericUpDownPositionY2.Value;
            }

            if (((Model.Brush.BrushTypes)comboBoxType.SelectedValue) == Model.Brush.BrushTypes.LinealGradient)
            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                _brush.LinearGradientMode = (XLinearGradientMode)comboBoxLinearGradientMode.SelectedValue;
#pragma warning restore CS8605 // Unboxing a possibly null value.
            }

            if (((Model.Brush.BrushTypes)comboBoxType.SelectedValue) == Model.Brush.BrushTypes.RadialGradient)
            {
                _brush.RadiusStart = numericUpDownRadiusStart.Value;
                _brush.RadiusEnd = numericUpDownRadiusEnd.Value;
            }

            if (BrushUpdated is not null)
            {
                BrushUpdated(this, _brush.BrushId);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_brush is null || MessageBox.Show(string.Format(Properties.Resources.StringBrushDeleteConfirmation, _brush.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Brushes.Remove(_brush);
            if (BrushDeleted is not null)
            {
                BrushDeleted(this, _brush.BrushId);
            }
        }

        #endregion Methods

    }
}
