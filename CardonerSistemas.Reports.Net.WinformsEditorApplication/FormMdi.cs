namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    public partial class FormMdi : Form
    {
        public FormMdi()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            WinformsEditor.Editor.For_reportEditor for_reportEditor = new(Program.s_applicationInfo.Title, new(), string.Empty)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            for_reportEditor.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = Properties.Resources.StringFileDialogFilter,
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckFileExists = true,
                ValidateNames = true
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK && Storage.FileSystem.Load(openFileDialog.FileName, out Model.Report? report) && report is not null)
            {
                WinformsEditor.Editor.For_reportEditor for_reportEditor = new(Program.s_applicationInfo.Title, report, openFileDialog.FileName)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                for_reportEditor.Show();
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is null)
            {
                return;
            }
            WinformsEditor.Editor.For_reportEditor for_reportEditor = (WinformsEditor.Editor.For_reportEditor)ActiveMdiChild;
            saveToolStripButton.Enabled = !for_reportEditor.SaveReport();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is null)
            {
                return;
            }
            WinformsEditor.Editor.For_reportEditor for_reportEditor = (WinformsEditor.Editor.For_reportEditor)ActiveMdiChild;
            saveToolStripButton.Enabled = !for_reportEditor.SaveReportAs();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is under construction
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is under construction
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is under construction
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

    }
}
