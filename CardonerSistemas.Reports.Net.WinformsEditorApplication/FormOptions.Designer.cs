namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    partial class FormOptions
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
            tableLayoutPanelMain = new TableLayoutPanel();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonOk = new Button();
            buttonCancel = new Button();
            groupBoxTree = new GroupBox();
            tableLayoutPanelTree = new TableLayoutPanel();
            tableLayoutPanelName = new TableLayoutPanel();
            textBoxFont = new TextBox();
            buttonFont = new Button();
            labelTreeFont = new Label();
            labelTreeIconSize = new Label();
            numericUpDownTreeIconSize = new NumericUpDown();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            groupBoxTree.SuspendLayout();
            tableLayoutPanelTree.SuspendLayout();
            tableLayoutPanelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTreeIconSize).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 0, 2);
            tableLayoutPanelMain.Controls.Add(groupBoxTree, 0, 0);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.Size = new Size(543, 171);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 2;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonOk, 0, 0);
            tableLayoutPanelButtons.Controls.Add(buttonCancel, 1, 0);
            tableLayoutPanelButtons.Dock = DockStyle.Right;
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(328, 132);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButtons.Size = new Size(212, 36);
            tableLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.AutoSize = true;
            buttonOk.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Dock = DockStyle.Fill;
            buttonOk.Location = new Point(3, 3);
            buttonOk.MinimumSize = new Size(100, 0);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(100, 30);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += SaveOptions;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.Location = new Point(109, 3);
            buttonCancel.MinimumSize = new Size(100, 0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += Close;
            // 
            // groupBoxTree
            // 
            groupBoxTree.AutoSize = true;
            groupBoxTree.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxTree.Controls.Add(tableLayoutPanelTree);
            groupBoxTree.Dock = DockStyle.Fill;
            groupBoxTree.Location = new Point(3, 3);
            groupBoxTree.Name = "groupBoxTree";
            groupBoxTree.Size = new Size(537, 95);
            groupBoxTree.TabIndex = 1;
            groupBoxTree.TabStop = false;
            groupBoxTree.Text = "Object Tree";
            // 
            // tableLayoutPanelTree
            // 
            tableLayoutPanelTree.AutoSize = true;
            tableLayoutPanelTree.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelTree.ColumnCount = 2;
            tableLayoutPanelTree.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTree.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelTree.Controls.Add(tableLayoutPanelName, 1, 1);
            tableLayoutPanelTree.Controls.Add(labelTreeFont, 0, 1);
            tableLayoutPanelTree.Controls.Add(labelTreeIconSize, 0, 0);
            tableLayoutPanelTree.Controls.Add(numericUpDownTreeIconSize, 1, 0);
            tableLayoutPanelTree.Dock = DockStyle.Fill;
            tableLayoutPanelTree.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelTree.Location = new Point(3, 23);
            tableLayoutPanelTree.Name = "tableLayoutPanelTree";
            tableLayoutPanelTree.RowCount = 2;
            tableLayoutPanelTree.RowStyles.Add(new RowStyle());
            tableLayoutPanelTree.RowStyles.Add(new RowStyle());
            tableLayoutPanelTree.Size = new Size(531, 69);
            tableLayoutPanelTree.TabIndex = 0;
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
            tableLayoutPanelName.Location = new Point(75, 33);
            tableLayoutPanelName.Margin = new Padding(0);
            tableLayoutPanelName.Name = "tableLayoutPanelName";
            tableLayoutPanelName.RowCount = 1;
            tableLayoutPanelName.RowStyles.Add(new RowStyle());
            tableLayoutPanelName.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelName.Size = new Size(456, 36);
            tableLayoutPanelName.TabIndex = 3;
            // 
            // textBoxFont
            // 
            textBoxFont.Dock = DockStyle.Fill;
            textBoxFont.Location = new Point(3, 3);
            textBoxFont.Name = "textBoxFont";
            textBoxFont.ReadOnly = true;
            textBoxFont.Size = new Size(414, 27);
            textBoxFont.TabIndex = 0;
            // 
            // buttonFont
            // 
            buttonFont.AutoSize = true;
            buttonFont.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonFont.Location = new Point(423, 3);
            buttonFont.Name = "buttonFont";
            buttonFont.Size = new Size(30, 30);
            buttonFont.TabIndex = 1;
            buttonFont.Text = "…";
            buttonFont.UseVisualStyleBackColor = true;
            buttonFont.Click += SelectFont;
            // 
            // labelTreeFont
            // 
            labelTreeFont.AutoSize = true;
            labelTreeFont.Dock = DockStyle.Fill;
            labelTreeFont.Location = new Point(3, 33);
            labelTreeFont.Name = "labelTreeFont";
            labelTreeFont.Size = new Size(69, 36);
            labelTreeFont.TabIndex = 2;
            labelTreeFont.Text = "Font:";
            labelTreeFont.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTreeIconSize
            // 
            labelTreeIconSize.AutoSize = true;
            labelTreeIconSize.Dock = DockStyle.Fill;
            labelTreeIconSize.Location = new Point(3, 0);
            labelTreeIconSize.Name = "labelTreeIconSize";
            labelTreeIconSize.Size = new Size(69, 33);
            labelTreeIconSize.TabIndex = 0;
            labelTreeIconSize.Text = "Icon size:";
            labelTreeIconSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTreeIconSize
            // 
            numericUpDownTreeIconSize.Location = new Point(78, 3);
            numericUpDownTreeIconSize.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            numericUpDownTreeIconSize.Minimum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownTreeIconSize.Name = "numericUpDownTreeIconSize";
            numericUpDownTreeIconSize.Size = new Size(68, 27);
            numericUpDownTreeIconSize.TabIndex = 1;
            numericUpDownTreeIconSize.TextAlign = HorizontalAlignment.Center;
            numericUpDownTreeIconSize.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // FormOptions
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(543, 171);
            ControlBox = false;
            Controls.Add(tableLayoutPanelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormOptions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Options";
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            groupBoxTree.ResumeLayout(false);
            groupBoxTree.PerformLayout();
            tableLayoutPanelTree.ResumeLayout(false);
            tableLayoutPanelTree.PerformLayout();
            tableLayoutPanelName.ResumeLayout(false);
            tableLayoutPanelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTreeIconSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonOk;
        private Button buttonCancel;
        private GroupBox groupBoxTree;
        private TableLayoutPanel tableLayoutPanelTree;
        private Label labelTreeIconSize;
        private NumericUpDown numericUpDownTreeIconSize;
        private Label labelTreeFont;
        private TableLayoutPanel tableLayoutPanelName;
        private TextBox textBoxFont;
        private Button buttonFont;
    }
}