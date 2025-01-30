namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    public partial class FormMdi : Form
    {
        public FormMdi()
        {
            InitializeComponent();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            WinformsEditor.FormReportEditor formReportEditor = new(new())
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            formReportEditor.Show();
        }

        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Report files (*.csrpt)|*.csrpt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK && Storage.FileSystem.Load(openFileDialog.FileName, out Model.Report report))
            {
                WinformsEditor.FormReportEditor formReportEditor = new(report)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                formReportEditor.Show();
            }
        }

        private static bool SaveReport()
        {
            // Save the report
            return true;
        }

    }
}
