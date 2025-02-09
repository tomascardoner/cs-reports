﻿namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    public partial class FormMdi : Form
    {
        public FormMdi()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            WinformsEditor.FormReportEditor formReportEditor = new(Program.ApplicationInfo.Title, new(), string.Empty)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            formReportEditor.Show();
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
                WinformsEditor.FormReportEditor formReportEditor = new(Program.ApplicationInfo.Title, report, openFileDialog.FileName)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                formReportEditor.Show();
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
            {
                return;
            }
            WinformsEditor.FormReportEditor formReportEditor = (WinformsEditor.FormReportEditor)this.ActiveMdiChild;
            saveToolStripButton.Enabled = !formReportEditor.SaveReport();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
            {
                return;
            }
            WinformsEditor.FormReportEditor formReportEditor = (WinformsEditor.FormReportEditor)this.ActiveMdiChild;
            saveToolStripButton.Enabled = !formReportEditor.SaveReportAs();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is null || ActiveMdiChild.ActiveControl is null)
            {
                return;
            }
            if (ActiveMdiChild.ActiveControl is SplitContainer splitContainer)
            {
                
            }
            if (ActiveMdiChild.ActiveControl is TextBox textBox && Clipboard.ContainsText())
            {
                textBox.Paste();
            }
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
