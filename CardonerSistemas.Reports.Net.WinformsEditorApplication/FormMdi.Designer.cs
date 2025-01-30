namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    partial class FormMdi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMdi));
            ToolStripMain = new ToolStrip();
            ToolStripButtonNew = new ToolStripButton();
            ToolStripButtonOpen = new ToolStripButton();
            ToolStripButtonSave = new ToolStripButton();
            ToolStripButtonSaveAs = new ToolStripButton();
            ToolStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // ToolStripMain
            // 
            ToolStripMain.GripStyle = ToolStripGripStyle.Hidden;
            ToolStripMain.ImageScalingSize = new Size(20, 20);
            ToolStripMain.Items.AddRange(new ToolStripItem[] { ToolStripButtonNew, ToolStripButtonOpen, ToolStripButtonSave, ToolStripButtonSaveAs });
            ToolStripMain.Location = new Point(0, 0);
            ToolStripMain.Name = "ToolStripMain";
            ToolStripMain.Size = new Size(667, 47);
            ToolStripMain.TabIndex = 2;
            // 
            // ToolStripButtonNew
            // 
            ToolStripButtonNew.Image = (Image)resources.GetObject("ToolStripButtonNew.Image");
            ToolStripButtonNew.ImageTransparentColor = Color.Magenta;
            ToolStripButtonNew.Name = "ToolStripButtonNew";
            ToolStripButtonNew.Size = new Size(43, 44);
            ToolStripButtonNew.Text = "New";
            ToolStripButtonNew.TextImageRelation = TextImageRelation.ImageAboveText;
            ToolStripButtonNew.Click += ToolStripButtonNew_Click;
            // 
            // ToolStripButtonOpen
            // 
            ToolStripButtonOpen.Image = (Image)resources.GetObject("ToolStripButtonOpen.Image");
            ToolStripButtonOpen.ImageTransparentColor = Color.Magenta;
            ToolStripButtonOpen.Name = "ToolStripButtonOpen";
            ToolStripButtonOpen.Size = new Size(49, 44);
            ToolStripButtonOpen.Text = "Open";
            ToolStripButtonOpen.TextImageRelation = TextImageRelation.ImageAboveText;
            ToolStripButtonOpen.Click += ToolStripButtonOpen_Click;
            // 
            // ToolStripButtonSave
            // 
            ToolStripButtonSave.Image = (Image)resources.GetObject("ToolStripButtonSave.Image");
            ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
            ToolStripButtonSave.Name = "ToolStripButtonSave";
            ToolStripButtonSave.Size = new Size(44, 44);
            ToolStripButtonSave.Text = "Save";
            ToolStripButtonSave.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // ToolStripButtonSaveAs
            // 
            ToolStripButtonSaveAs.Image = (Image)resources.GetObject("ToolStripButtonSaveAs.Image");
            ToolStripButtonSaveAs.ImageTransparentColor = Color.Magenta;
            ToolStripButtonSaveAs.Name = "ToolStripButtonSaveAs";
            ToolStripButtonSaveAs.Size = new Size(71, 44);
            ToolStripButtonSaveAs.Text = "Save as...";
            ToolStripButtonSaveAs.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // FormMdi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 560);
            Controls.Add(ToolStripMain);
            IsMdiContainer = true;
            Name = "FormMdi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CS-Reports editor";
            WindowState = FormWindowState.Maximized;
            ToolStripMain.ResumeLayout(false);
            ToolStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip ToolStripMain;
        private ToolStripButton ToolStripButtonNew;
        private ToolStripButton ToolStripButtonOpen;
        private ToolStripButton ToolStripButtonSave;
        private ToolStripButton ToolStripButtonSaveAs;
    }
}
