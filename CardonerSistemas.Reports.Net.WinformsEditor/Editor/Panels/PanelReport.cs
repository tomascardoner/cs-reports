using static CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels.PanelFont;

namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelReport : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private readonly string _applicationTitle;

        public event EventHandler? ReportUpdated;

        #endregion Declarations

        #region Initialization

        public PanelReport(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;

            FillPageSizes();
            FillPageOrientations();
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

        #endregion Events

        #region Methods

        internal void ShowProperties()
        {
            textBoxReportId.Text = _report.ReportId.ToString();
            textBoxName.Text = _report.Name;
            textBoxTemplateFileName.Text = _report.TemplateFileName;
            comboBoxPageSize.SelectedValue = (byte)_report.PageSize;
            comboBoxPageOrientation.SelectedValue = (byte)_report.PageOrientation;
            numericUpDownPageMarginTop.Value = _report.PageMarginTop;
            numericUpDownPageMarginLeft.Value = _report.PageMarginLeft;
            numericUpDownPageMarginRight.Value = _report.PageMarginRight;
            numericUpDownPageMarginBottom.Value = _report.PageMarginBottom;
            numericUpDownDetailSectionMaxRowCount.Value = _report.DetailSectionMaxRowCount;
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show(Properties.Resources.StringReportNameRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxPageSize.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringReportPageSizeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxPageOrientation.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringReportPageOrientationRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _report.Name = textBoxName.Text;
            _report.TemplateFileName = textBoxTemplateFileName.Text;
            _report.PageSize = (Model.Report.PageSizes)(comboBoxPageSize.SelectedValue ?? Model.Report.PageSizes.Undefined);
            _report.PageOrientation = (Model.Report.PageOrientations)(comboBoxPageOrientation.SelectedValue ?? Model.Report.PageOrientations.Portrait);
            _report.PageMarginTop = numericUpDownPageMarginTop.Value;
            _report.PageMarginLeft = numericUpDownPageMarginLeft.Value;
            _report.PageMarginRight = numericUpDownPageMarginRight.Value;
            _report.PageMarginBottom = numericUpDownPageMarginBottom.Value;
            _report.DetailSectionMaxRowCount = (short)numericUpDownDetailSectionMaxRowCount.Value;

            if (ReportUpdated is not null)
            {
                ReportUpdated(this, EventArgs.Empty);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        #endregion Methods

    }
}
