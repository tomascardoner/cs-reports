namespace CardonerSistemas.Reports.Net.WinformsViewer
{
    partial class FormPdfViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPdfViewer));
            AxAcroPdfMain = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)AxAcroPdfMain).BeginInit();
            SuspendLayout();
            // 
            // AxAcroPdfMain
            // 
            AxAcroPdfMain.Dock = DockStyle.Fill;
            AxAcroPdfMain.Enabled = true;
            AxAcroPdfMain.Location = new Point(0, 0);
            AxAcroPdfMain.Name = "AxAcroPdfMain";
            AxAcroPdfMain.OcxState = (AxHost.State)resources.GetObject("AxAcroPdfMain.OcxState");
            AxAcroPdfMain.Size = new Size(612, 566);
            AxAcroPdfMain.TabIndex = 0;
            // 
            // FormPdfViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 566);
            Controls.Add(AxAcroPdfMain);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPdfViewer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF viewer";
            ((System.ComponentModel.ISupportInitialize)AxAcroPdfMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF AxAcroPdfMain;
    }
}