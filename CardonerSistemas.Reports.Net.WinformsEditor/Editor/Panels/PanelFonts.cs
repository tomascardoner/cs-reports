namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelFonts : UserControl
    {

        #region Declarations

        private readonly string _applicationTitle;
        private readonly Model.Report _report;

        public delegate void FontHandler(object sender, short fontId);

        public event FontHandler? FontAdded;

        #endregion Declarations

        #region Initialization

        public PanelFonts(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringFontsAdd;
        }

        #endregion Initialization

        #region Methods

        public void ShowProperties()
        {
            labelCounter.Text = _report.Fonts.Count switch
            {
                0 => Properties.Resources.StringFontsCounterEmpty,
                1 => Properties.Resources.StringFontsCounterOne,
                _ => string.Format(Properties.Resources.StringFontsCounter, _report.Fonts.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            Model.Font? font = _report.Fonts.FirstOrDefault(f => f.Name.Trim() == Properties.Resources.StringFontNameNew);
            if (font is null)
            {
                font = new Model.Font(_report) { Name = Properties.Resources.StringFontNameNew };
                _report.Fonts.Add(font);
            }
            else
            {
                MessageBox.Show(Properties.Resources.StringFontNewAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (FontAdded is not null)
            {
                FontAdded(this, font.FontId);
            }
        }

        #endregion Methods

    }
}
