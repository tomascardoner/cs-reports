namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    public partial class PanelReport : UserControl
    {
        private Model.Report mReport;
        private readonly string mApplicationTitle;

        public PanelReport(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            mReport = report;
            mApplicationTitle = applicationTitle;
            InitializeForm();

            ShowProperties();
        }

        private void InitializeForm()
        {
            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;

            FillPageSizes();
            FillPageOrientations();
        }

        public void SetReport(Model.Report report)
        {
            mReport = report;
            ShowProperties();
        }

        private void FillPageSizes()
        {
            comboBoxPageSize.ValueMember = "Key";
            comboBoxPageSize.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> items = [];
            foreach (Model.Report.PageSizes pageSize in Enum.GetValues<Model.Report.PageSizes>())
            {
                items.Add(new KeyValuePair<byte, string>((byte)pageSize, FriendlyNames.GetPageSize(pageSize)));
            }
            comboBoxPageSize.DataSource = items;
        }

        private void FillPageOrientations()
        {
            comboBoxPageOrientation.ValueMember = "Key";
            comboBoxPageOrientation.DisplayMember = "Value";
            ICollection<KeyValuePair<byte, string>> items = [];
            foreach (Model.Report.PageOrientations pageOrientation in Enum.GetValues<Model.Report.PageOrientations>())
            {
                items.Add(new KeyValuePair<byte, string>((byte)pageOrientation, FriendlyNames.GetPageOrientation(pageOrientation)));
            }
            comboBoxPageOrientation.DataSource = items;
        }

        private void TextBoxs_Enter(object sender, EventArgs e)
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

        private void ShowProperties()
        {
            textBoxReportId.Text = mReport.ReportId.ToString();
            textBoxName.Text = mReport.Name;
            textBoxTemplateFileName.Text = mReport.TemplateFileName;
            comboBoxPageSize.SelectedValue = (byte)mReport.PageSize;
            comboBoxPageOrientation.SelectedValue = (byte)mReport.PageOrientation;
            numericUpDownPageMarginTop.Value = mReport.PageMarginTop;
            numericUpDownPageMarginLeft.Value = mReport.PageMarginLeft;
            numericUpDownPageMarginRight.Value = mReport.PageMarginRight;
            numericUpDownPageMarginBottom.Value = mReport.PageMarginBottom;
            numericUpDownDetailSectionMaxRowCount.Value = mReport.DetailSectionMaxRowCount;
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringReportNameRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxPageSize.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringReportPageSizeRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxPageOrientation.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringReportPageOrientationRequired, mApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            mReport.Name = textBoxName.Text;
            mReport.TemplateFileName = textBoxTemplateFileName.Text;
            mReport.PageSize = (Model.Report.PageSizes)(comboBoxPageSize.SelectedValue ?? Model.Report.PageSizes.Undefined);
            mReport.PageOrientation = (Model.Report.PageOrientations)(comboBoxPageOrientation.SelectedValue ?? Model.Report.PageOrientations.Portrait);
            mReport.PageMarginTop = numericUpDownPageMarginTop.Value;
            mReport.PageMarginLeft = numericUpDownPageMarginLeft.Value;
            mReport.PageMarginRight = numericUpDownPageMarginRight.Value;
            mReport.PageMarginBottom = numericUpDownPageMarginBottom.Value;
            mReport.DetailSectionMaxRowCount = (short)numericUpDownDetailSectionMaxRowCount.Value;
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }
    }
}