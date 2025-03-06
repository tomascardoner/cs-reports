namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor
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
            splitContainerMain = new SplitContainer();
            treeViewReport = new TreeView();
            imageListMain = new ImageList(components);
            toolTipMain = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(treeViewReport);
            splitContainerMain.Size = new Size(1062, 661);
            splitContainerMain.SplitterDistance = 250;
            splitContainerMain.TabIndex = 0;
            // 
            // treeViewReport
            // 
            treeViewReport.Dock = DockStyle.Fill;
            treeViewReport.HideSelection = false;
            treeViewReport.Location = new Point(0, 0);
            treeViewReport.Name = "treeViewReport";
            treeViewReport.ShowRootLines = false;
            treeViewReport.Size = new Size(250, 661);
            treeViewReport.TabIndex = 0;
            treeViewReport.AfterSelect += TreeViewReport_AfterSelect;
            // 
            // imageListMain
            // 
            imageListMain.ColorDepth = ColorDepth.Depth32Bit;
            imageListMain.ImageStream = (ImageListStreamer)resources.GetObject("imageListMain.ImageStream");
            imageListMain.TransparentColor = Color.Transparent;
            imageListMain.Images.SetKeyName(0, "Report");
            imageListMain.Images.SetKeyName(1, "Datasource");
            imageListMain.Images.SetKeyName(2, "DatasourceParameters");
            imageListMain.Images.SetKeyName(3, "DatasourceParameter");
            imageListMain.Images.SetKeyName(4, "DatasourceFields");
            imageListMain.Images.SetKeyName(5, "DatasourceField");
            imageListMain.Images.SetKeyName(6, "Fonts");
            imageListMain.Images.SetKeyName(7, "Font");
            imageListMain.Images.SetKeyName(8, "Brushes");
            imageListMain.Images.SetKeyName(9, "Brush");
            imageListMain.Images.SetKeyName(10, "Sections");
            imageListMain.Images.SetKeyName(11, "Section");
            imageListMain.Images.SetKeyName(12, "Rectangles");
            imageListMain.Images.SetKeyName(13, "Rectangle");
            imageListMain.Images.SetKeyName(14, "Lines");
            imageListMain.Images.SetKeyName(15, "Line");
            imageListMain.Images.SetKeyName(16, "Texts");
            imageListMain.Images.SetKeyName(17, "Text");
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 661);
            Controls.Add(splitContainerMain);
            Name = "FormReportEditor";
            Text = "Report editor";
            FormClosing += This_FormClosing;
            splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private TreeView treeViewReport;
        private ImageList imageListMain;
        private ToolTip toolTipMain;
    }
}
