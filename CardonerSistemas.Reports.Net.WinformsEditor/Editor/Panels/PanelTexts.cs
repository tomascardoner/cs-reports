namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelTexts : UserControl
    {

        #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
        private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
        private readonly Model.Report _report;

        public delegate void TextHandler(object sender, short textId, short sectionId);

        public event TextHandler? TextAdded;

        #endregion Declarations

        #region Initialization

        public PanelTexts(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringTextsAdd;
        }

        #endregion Initialization

        #region Methods

        public void ShowProperties(int count)
        {
            labelCounter.Text = count switch
            {
                0 => Properties.Resources.StringTextsCounterEmpty,
                1 => Properties.Resources.StringTextsCounterOne,
                _ => string.Format(Properties.Resources.StringTextsCounter, count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            Model.Text? text = new(_report);
            _report.Texts.Add(text);
            if (TextAdded is not null)
            {
                TextAdded(this, text.TextId, text.SectionId);
            }
        }

        #endregion Methods

    }
}
