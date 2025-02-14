namespace CardonerSistemas.Reports.Net.WinformsViewer
{
    public partial class FormPdfViewer : Form
    {
#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable IDE0051 // Remove unused private members
        private const string ViewFitPage = "Fit";
        private const string ViewFitHorizontally = "FitH";
        private const string ViewFitVertically = "FitV";
        private const string ViewFitBoundingBox = "FitB";
        private const string ViewFitBoundingBoxHorizontally = "FitBH";
        private const string ViewFitBoundingBoxVertically = "FitBV";

        private const string LayoutModeCurrentUserPreference = "DontCare";
        private const string LayoutModeSinglePage = "SinglePage";
        private const string LayoutModeOneColumn = "OneColumn";
        private const string LayoutModeTwoColumnLeft = "TwoColumnLeft";
        private const string LayoutModeTwoColumnRight = "TwoColumnRight";
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore S1144 // Unused private types or members should be removed

        public FormPdfViewer(Form mdiForm, Model.Report report, string windowTitle)
        {
            InitializeComponent();

            IntPtr pointerIcon = Properties.Resources.Printer32.GetHicon();
            Icon icon = Icon.FromHandle(pointerIcon);
            Icon = icon;
            MdiParent = mdiForm;
            WindowState = FormWindowState.Normal;
            Dock = DockStyle.Fill;
            Text = windowTitle;

            string filename = Engine.Pdf.CreateAndSaveTemp(report, string.Empty);
            if (filename != string.Empty)
            {
                AxAcroPdfMain.setShowToolbar(true);
                AxAcroPdfMain.src = filename;
                AxAcroPdfMain.setLayoutMode(LayoutModeSinglePage);
                AxAcroPdfMain.setView(ViewFitPage);
                AxAcroPdfMain.Show();
            }
        }
    }
}