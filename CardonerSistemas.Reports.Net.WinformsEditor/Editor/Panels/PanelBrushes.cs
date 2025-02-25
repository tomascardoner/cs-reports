namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelBrushes : UserControl
    {

        #region Declarations

#pragma warning disable S4487 // Unread "private" fields should be removed
        private readonly string _applicationTitle;
#pragma warning restore S4487 // Unread "private" fields should be removed
        private readonly Model.Report _report;

        public delegate void BrushHandler(object sender, short brushId);

        public event BrushHandler? BrushAdded;

        #endregion Declarations

        #region Initialization

        public PanelBrushes(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonAdd.Text = Properties.Resources.StringBrushesAdd;
        }

        #endregion Initialization

        #region Methods

        public void ShowProperties()
        {
            labelCounter.Text = _report.Brushes.Count switch
            {
                0 => Properties.Resources.StringBrushesCounterEmpty,
                1 => Properties.Resources.StringBrushesCounterOne,
                _ => string.Format(Properties.Resources.StringBrushesCounter, _report.Brushes.Count)
            };
        }

        private void Add(object sender, EventArgs e)
        {
            Model.Brush brush = new(_report);
            _report.Brushes.Add(brush);
            if (BrushAdded is not null)
            {
                BrushAdded(this, brush.BrushId);
            }
        }

        #endregion Methods

    }
}
