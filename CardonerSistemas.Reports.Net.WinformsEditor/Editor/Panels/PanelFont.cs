namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelFont : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Font? _font;
        private readonly string _applicationTitle;

        public delegate void FontHandler(object sender, short fontId);

        public event FontHandler? FontUpdated;
        public event FontHandler? FontDeleted;

        #endregion Declarations

        #region Initialization

        public PanelFont(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
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

        private void SelectFont(object sender, EventArgs e)
        {
            using FontDialog fontDialog = new();
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxFont.Tag = fontDialog.Font;
                textBoxFont.Text = $"{fontDialog.Font.Name} {fontDialog.Font.Size}pt {fontDialog.Font.Style}";
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_font is null)
            {
                return;
            }
            textBoxFont.Text = _font.DisplayNameShort;
        }

        internal void ShowProperties(short fontId)
        {
            if (_report.Datasource is null)
            {
                return;
            }
            _font = _report.Fonts.FirstOrDefault(f => f.FontId == fontId);
            if (_font is null)
            {
                return;
            }
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_font is null || textBoxFont.Tag is null)
            {
                return;
            }
            Font font = (Font)textBoxFont.Tag;
            _font.Name = font.Name;
            _font.Size = (decimal)font.Size;
            _font.Bold = font.Bold;
            _font.Italic = font.Italic;
            _font.Underline = font.Underline;
            _font.Strikethrough = font.Strikeout;
            if (FontUpdated is not null)
            {
                FontUpdated(this, _font.FontId);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_font is null || MessageBox.Show(string.Format(Properties.Resources.StringFontDeleteConfirmation, _font.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Fonts.Remove(_font);
            if (FontDeleted is not null)
            {
                FontDeleted(this, _font.FontId);
            }
        }

        #endregion Methods

    }
}
