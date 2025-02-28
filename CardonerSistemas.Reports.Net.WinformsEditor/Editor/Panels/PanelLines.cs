namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelLines : UserControl
    {

        #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
        private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
        private readonly Model.Report _report;

        public delegate void LineHandler(object sender, short lineId, short section1Id);

        public event LineHandler? LineAdded;

        #endregion Declarations

        #region Initialization

        public PanelLines(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringLinesAdd;
        }

        #endregion Initialization

        #region Methods

        public void ShowProperties(int count)
        {
            labelCounter.Text = count switch
            {
                0 => Properties.Resources.StringLinesCounterEmpty,
                1 => Properties.Resources.StringLinesCounterOne,
                _ => string.Format(Properties.Resources.StringLinesCounter, count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            Model.Line? line = new(_report);
            _report.Lines.Add(line);
            if (LineAdded is not null)
            {
                LineAdded(this, line.LineId, line.SectionId1);
            }
        }

        #endregion Methods

    }
}
