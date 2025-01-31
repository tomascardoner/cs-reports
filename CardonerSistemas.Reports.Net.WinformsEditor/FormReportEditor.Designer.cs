namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    partial class FormReportEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportEditor));
            SplitContainerMain = new SplitContainer();
            TreeViewReport = new TreeView();
            PanelSection = new Panel();
            ImageListMain = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)SplitContainerMain).BeginInit();
            SplitContainerMain.Panel1.SuspendLayout();
            SplitContainerMain.Panel2.SuspendLayout();
            SplitContainerMain.SuspendLayout();
            SuspendLayout();
            // 
            // SplitContainerMain
            // 
            SplitContainerMain.Dock = DockStyle.Fill;
            SplitContainerMain.Location = new Point(0, 0);
            SplitContainerMain.Name = "SplitContainerMain";
            // 
            // SplitContainerMain.Panel1
            // 
            SplitContainerMain.Panel1.Controls.Add(TreeViewReport);
            // 
            // SplitContainerMain.Panel2
            // 
            SplitContainerMain.Panel2.Controls.Add(PanelSection);
            SplitContainerMain.Size = new Size(1062, 661);
            SplitContainerMain.SplitterDistance = 250;
            SplitContainerMain.TabIndex = 0;
            // 
            // TreeViewReport
            // 
            TreeViewReport.Dock = DockStyle.Fill;
            TreeViewReport.ItemHeight = 55;
            TreeViewReport.Location = new Point(0, 0);
            TreeViewReport.Name = "TreeViewReport";
            TreeViewReport.ShowRootLines = false;
            TreeViewReport.Size = new Size(250, 661);
            TreeViewReport.TabIndex = 0;
            // 
            // PanelSection
            // 
            PanelSection.Dock = DockStyle.Fill;
            PanelSection.Location = new Point(0, 0);
            PanelSection.Name = "PanelSection";
            PanelSection.Size = new Size(808, 661);
            PanelSection.TabIndex = 0;
            // 
            // ImageListMain
            // 
            ImageListMain.ColorDepth = ColorDepth.Depth32Bit;
            ImageListMain.ImageStream = (ImageListStreamer)resources.GetObject("ImageListMain.ImageStream");
            ImageListMain.TransparentColor = Color.Transparent;
            ImageListMain.Images.SetKeyName(0, "Report");
            ImageListMain.Images.SetKeyName(1, "Datasource");
            ImageListMain.Images.SetKeyName(2, "DatasourceParameter");
            ImageListMain.Images.SetKeyName(3, "FontsFolder");
            ImageListMain.Images.SetKeyName(4, "Font");
            ImageListMain.Images.SetKeyName(5, "BrushesFolder");
            ImageListMain.Images.SetKeyName(6, "Brush");
            ImageListMain.Images.SetKeyName(7, "SectionsFolder");
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 661);
            Controls.Add(SplitContainerMain);
            Name = "FormReportEditor";
            Text = "Report editor";
            SplitContainerMain.Panel1.ResumeLayout(false);
            SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainerMain).EndInit();
            SplitContainerMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer SplitContainerMain;
        private TreeView TreeViewReport;
        private Panel PanelSection;
        private ImageList ImageListMain;
    }
}