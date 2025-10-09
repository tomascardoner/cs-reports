namespace CardonerSistemas.Reports.Net.WinformsEditorApplication;

public partial class FormMdi : Form
{
    public FormMdi()
    {
        InitializeComponent();
    }

    private void ShowNewForm(object sender, EventArgs e)
    {
        WinformsEditor.Editor.FormReportEditor formReportEditor = new(Program.ApplicationInfo.Title, new(), string.Empty, Program.s_options.TreeIconSize, Program.s_options.TreeFont)
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
            WinformsEditor.Editor.FormReportEditor formReportEditor = new(Program.ApplicationInfo.Title, report, openFileDialog.FileName, Program.s_options.TreeIconSize, Program.s_options.TreeFont)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            formReportEditor.Show();
        }
    }

    private void SaveToolStripButton_Click(object sender, EventArgs e)
    {
        if (ActiveMdiChild is null)
        {
            return;
        }

        WinformsEditor.Editor.FormReportEditor formReportEditor = (WinformsEditor.Editor.FormReportEditor)ActiveMdiChild;
        formReportEditor.SaveReport();
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ActiveMdiChild is null)
        {
            return;
        }

        WinformsEditor.Editor.FormReportEditor formReportEditor = (WinformsEditor.Editor.FormReportEditor)ActiveMdiChild;
        formReportEditor.SaveReportAs();
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

    private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FormOptions formOptions = new();
        if (formOptions.ShowDialog(this) == DialogResult.OK)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
