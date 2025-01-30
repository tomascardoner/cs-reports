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
            SplitContainerMain = new SplitContainer();
            TreeViewReport = new TreeView();
            PanelSection = new Panel();
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
            SplitContainerMain.SplitterDistance = 354;
            SplitContainerMain.TabIndex = 0;
            // 
            // TreeViewReport
            // 
            TreeViewReport.Dock = DockStyle.Fill;
            TreeViewReport.Location = new Point(0, 0);
            TreeViewReport.Name = "TreeViewReport";
            TreeViewReport.Size = new Size(354, 661);
            TreeViewReport.TabIndex = 0;
            // 
            // PanelSection
            // 
            PanelSection.Dock = DockStyle.Fill;
            PanelSection.Location = new Point(0, 0);
            PanelSection.Name = "PanelSection";
            PanelSection.Size = new Size(704, 661);
            PanelSection.TabIndex = 0;
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 661);
            Controls.Add(SplitContainerMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
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
    }
}