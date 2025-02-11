namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    partial class PanelDatasourceParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMain = new TableLayoutPanel();
            labelCounter = new Label();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonAdd = new Button();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 3;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 1, 2);
            tableLayoutPanelMain.Controls.Add(labelCounter, 1, 1);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 4;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 1;
            // 
            // labelCounter
            // 
            labelCounter.AutoSize = true;
            labelCounter.Dock = DockStyle.Fill;
            labelCounter.Location = new Point(318, 217);
            labelCounter.Name = "labelCounter";
            labelCounter.Size = new Size(64, 20);
            labelCounter.TabIndex = 0;
            labelCounter.Text = "Counter.";
            labelCounter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 1;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonAdd, 0, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(318, 240);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(57, 40);
            tableLayoutPanelButtons.TabIndex = 10;
            // 
            // buttonAdd
            // 
            buttonAdd.AutoSize = true;
            buttonAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAdd.Location = new Point(5, 5);
            buttonAdd.Margin = new Padding(5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(47, 30);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += Add;
            // 
            // PanelDatasourceParameters
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelDatasourceParameters";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelCounter;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonAdd;
    }
}
