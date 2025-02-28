namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    partial class PanelFont
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
            tableLayoutPanelName = new TableLayoutPanel();
            textBoxFont = new TextBox();
            buttonFont = new Button();
            labelFont = new Label();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            buttonDelete = new Button();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelName.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 4;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(labelFont, 1, 1);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelName, 2, 1);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 2);
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
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelName
            // 
            tableLayoutPanelName.AutoSize = true;
            tableLayoutPanelName.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelName.ColumnCount = 2;
            tableLayoutPanelName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelName.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelName.Controls.Add(textBoxFont, 0, 0);
            tableLayoutPanelName.Controls.Add(buttonFont, 1, 0);
            tableLayoutPanelName.Dock = DockStyle.Fill;
            tableLayoutPanelName.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelName.Location = new Point(147, 209);
            tableLayoutPanelName.Margin = new Padding(0);
            tableLayoutPanelName.Name = "tableLayoutPanelName";
            tableLayoutPanelName.RowCount = 1;
            tableLayoutPanelName.RowStyles.Add(new RowStyle());
            tableLayoutPanelName.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelName.Size = new Size(452, 36);
            tableLayoutPanelName.TabIndex = 1;
            // 
            // textBoxFont
            // 
            textBoxFont.Dock = DockStyle.Fill;
            textBoxFont.Location = new Point(3, 3);
            textBoxFont.Name = "textBoxFont";
            textBoxFont.ReadOnly = true;
            textBoxFont.Size = new Size(410, 27);
            textBoxFont.TabIndex = 0;
            textBoxFont.Enter += ControlFocusEnter;
            // 
            // buttonFont
            // 
            buttonFont.AutoSize = true;
            buttonFont.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonFont.Location = new Point(419, 3);
            buttonFont.Name = "buttonFont";
            buttonFont.Size = new Size(30, 30);
            buttonFont.TabIndex = 1;
            buttonFont.Text = "…";
            buttonFont.UseVisualStyleBackColor = true;
            buttonFont.Click += SelectFont;
            // 
            // labelFont
            // 
            labelFont.AutoSize = true;
            labelFont.Dock = DockStyle.Fill;
            labelFont.Location = new Point(103, 209);
            labelFont.Name = "labelFont";
            labelFont.Size = new Size(41, 36);
            labelFont.TabIndex = 0;
            labelFont.Text = "Font:";
            labelFont.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 3;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonApply, 0, 0);
            tableLayoutPanelButtons.Controls.Add(buttonReset, 1, 0);
            tableLayoutPanelButtons.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(150, 248);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(206, 40);
            tableLayoutPanelButtons.TabIndex = 2;
            // 
            // buttonApply
            // 
            buttonApply.AutoSize = true;
            buttonApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonApply.Location = new Point(5, 5);
            buttonApply.Margin = new Padding(5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(58, 30);
            buttonApply.TabIndex = 0;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += ApplyChanges;
            // 
            // buttonReset
            // 
            buttonReset.AutoSize = true;
            buttonReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonReset.Location = new Point(73, 5);
            buttonReset.Margin = new Padding(5);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(55, 30);
            buttonReset.TabIndex = 1;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ResetChanges;
            // 
            // buttonDelete
            // 
            buttonDelete.AutoSize = true;
            buttonDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDelete.Location = new Point(138, 5);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(63, 30);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += Delete;
            // 
            // PanelFont
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelFont";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tableLayoutPanelName.ResumeLayout(false);
            tableLayoutPanelName.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelFont;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonApply;
        private Button buttonReset;
        private Button buttonDelete;
        private TableLayoutPanel tableLayoutPanelName;
        private TextBox textBoxFont;
        private Button buttonFont;
    }
}
