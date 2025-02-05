namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelReport : UserControl
    {
        public PanelReport()
        {
            InitializeComponent();

            FillReportPageSizes();
            FillReportPageOrientations();
        }

        private void FillReportPageSizes()
        {
            comboBoxPageSize.ValueMember = "Key";
            comboBoxPageSize.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> reportPageSizes = [];
            foreach (Model.Report.PageSizes pageSize in Enum.GetValues<Model.Report.PageSizes>())
            {
                reportPageSizes.Add(new KeyValuePair<byte, string>((byte)pageSize, FriendlyNames.GetPageSize(pageSize)));
            }
            comboBoxPageSize.DataSource = reportPageSizes;
        }

        private void FillReportPageOrientations()
        {
            comboBoxPageOrientation.ValueMember = "Key";
            comboBoxPageOrientation.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> reportPageOrientations = [];
            foreach (Model.Report.PageOrientations pageOrientation in Enum.GetValues<Model.Report.PageOrientations>())
            {
                reportPageOrientations.Add(new KeyValuePair<byte, string>((byte)pageOrientation, FriendlyNames.GetPageOrientation(pageOrientation)));
            }
            comboBoxPageOrientation.DataSource = reportPageOrientations;
        }

        internal void ShowProperties(Model.Report report)
        {
            textBoxReportId.Text = report.ReportId.ToString();
            textBoxName.Text = report.Name;
            textBoxTemplateFileName.Text = report.TemplateFileName;
            comboBoxPageSize.SelectedValue = (byte)report.PageSize;
            comboBoxPageOrientation.SelectedValue = (byte)report.PageOrientation;
            numericUpDownPageMarginTop.Value = report.PageMarginTop;
            numericUpDownPageMarginLeft.Value = report.PageMarginLeft;
            numericUpDownPageMarginRight.Value = report.PageMarginRight;
            numericUpDownPageMarginBottom.Value = report.PageMarginBottom;
            numericUpDownDetailSectionMaxRowCount.Value = report.DetailSectionMaxRowCount;
        }

        internal void SetProperties(Model.Report report)
        {
            report.Name = textBoxName.Text;
            report.TemplateFileName = textBoxTemplateFileName.Text;
            report.PageSize = (Model.Report.PageSizes)(comboBoxPageSize.SelectedValue ?? Model.Report.PageSizes.Undefined);
            report.PageOrientation = (Model.Report.PageOrientations)(comboBoxPageOrientation.SelectedValue ?? Model.Report.PageOrientations.Portrait);
            report.PageMarginTop = numericUpDownPageMarginTop.Value;
            report.PageMarginLeft = numericUpDownPageMarginLeft.Value;
            report.PageMarginRight = numericUpDownPageMarginRight.Value;
            report.PageMarginBottom = numericUpDownPageMarginBottom.Value;
            report.DetailSectionMaxRowCount = (short)numericUpDownDetailSectionMaxRowCount.Value;
        }
    }
}