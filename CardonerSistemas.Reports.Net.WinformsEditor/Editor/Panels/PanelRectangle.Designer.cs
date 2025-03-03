namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    partial class PanelRectangle
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
            labelBorderColor = new Label();
            tableLayoutPanelBorderColor = new TableLayoutPanel();
            textBoxBorderColor = new TextBox();
            buttonBorderColor = new Button();
            labelBorderThickness = new Label();
            numericUpDownBorderThickness = new NumericUpDown();
            labelBrush = new Label();
            comboBoxBrush = new ComboBox();
            labelSection1 = new Label();
            comboBoxSection1 = new ComboBox();
            labelPositionX1 = new Label();
            numericUpDownPositionX1 = new NumericUpDown();
            labelPositionY1 = new Label();
            numericUpDownPositionY1 = new NumericUpDown();
            labelSection2 = new Label();
            comboBoxSection2 = new ComboBox();
            labelPositionX2 = new Label();
            numericUpDownPositionX2 = new NumericUpDown();
            labelPositionY2 = new Label();
            numericUpDownPositionY2 = new NumericUpDown();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            buttonDelete = new Button();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelBorderColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBorderThickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionX1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionX2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionY2).BeginInit();
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
            tableLayoutPanelMain.Controls.Add(labelBorderColor, 1, 1);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelBorderColor, 2, 1);
            tableLayoutPanelMain.Controls.Add(labelBorderThickness, 1, 2);
            tableLayoutPanelMain.Controls.Add(numericUpDownBorderThickness, 2, 2);
            tableLayoutPanelMain.Controls.Add(labelBrush, 1, 3);
            tableLayoutPanelMain.Controls.Add(comboBoxBrush, 2, 3);
            tableLayoutPanelMain.Controls.Add(labelSection1, 1, 4);
            tableLayoutPanelMain.Controls.Add(comboBoxSection1, 2, 4);
            tableLayoutPanelMain.Controls.Add(labelPositionX1, 1, 5);
            tableLayoutPanelMain.Controls.Add(numericUpDownPositionX1, 2, 5);
            tableLayoutPanelMain.Controls.Add(labelPositionY1, 1, 6);
            tableLayoutPanelMain.Controls.Add(numericUpDownPositionY1, 2, 6);
            tableLayoutPanelMain.Controls.Add(labelSection2, 1, 7);
            tableLayoutPanelMain.Controls.Add(comboBoxSection2, 2, 7);
            tableLayoutPanelMain.Controls.Add(labelPositionX2, 1, 8);
            tableLayoutPanelMain.Controls.Add(numericUpDownPositionX2, 2, 8);
            tableLayoutPanelMain.Controls.Add(labelPositionY2, 1, 9);
            tableLayoutPanelMain.Controls.Add(numericUpDownPositionY2, 2, 9);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 10);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 12;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelBorderColor
            // 
            labelBorderColor.AutoSize = true;
            labelBorderColor.Dock = DockStyle.Fill;
            labelBorderColor.Location = new Point(162, 75);
            labelBorderColor.Name = "labelBorderColor";
            labelBorderColor.Size = new Size(120, 36);
            labelBorderColor.TabIndex = 0;
            labelBorderColor.Text = "Border color:";
            labelBorderColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelBorderColor
            // 
            tableLayoutPanelBorderColor.AutoSize = true;
            tableLayoutPanelBorderColor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBorderColor.ColumnCount = 2;
            tableLayoutPanelBorderColor.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelBorderColor.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelBorderColor.Controls.Add(textBoxBorderColor, 0, 0);
            tableLayoutPanelBorderColor.Controls.Add(buttonBorderColor, 1, 0);
            tableLayoutPanelBorderColor.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelBorderColor.Location = new Point(285, 75);
            tableLayoutPanelBorderColor.Margin = new Padding(0);
            tableLayoutPanelBorderColor.Name = "tableLayoutPanelBorderColor";
            tableLayoutPanelBorderColor.RowCount = 1;
            tableLayoutPanelBorderColor.RowStyles.Add(new RowStyle());
            tableLayoutPanelBorderColor.Size = new Size(162, 36);
            tableLayoutPanelBorderColor.TabIndex = 1;
            // 
            // textBoxBorderColor
            // 
            textBoxBorderColor.Dock = DockStyle.Fill;
            textBoxBorderColor.Location = new Point(3, 3);
            textBoxBorderColor.Name = "textBoxBorderColor";
            textBoxBorderColor.ReadOnly = true;
            textBoxBorderColor.Size = new Size(120, 27);
            textBoxBorderColor.TabIndex = 0;
            textBoxBorderColor.TabStop = false;
            textBoxBorderColor.Enter += ControlFocusEnter;
            // 
            // buttonBorderColor
            // 
            buttonBorderColor.AutoSize = true;
            buttonBorderColor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonBorderColor.Location = new Point(129, 3);
            buttonBorderColor.Name = "buttonBorderColor";
            buttonBorderColor.Size = new Size(30, 30);
            buttonBorderColor.TabIndex = 1;
            buttonBorderColor.Text = "…";
            buttonBorderColor.UseVisualStyleBackColor = true;
            buttonBorderColor.Click += ColorChange;
            // 
            // labelBorderThickness
            // 
            labelBorderThickness.AutoSize = true;
            labelBorderThickness.Dock = DockStyle.Fill;
            labelBorderThickness.Location = new Point(162, 111);
            labelBorderThickness.Name = "labelBorderThickness";
            labelBorderThickness.Size = new Size(120, 33);
            labelBorderThickness.TabIndex = 2;
            labelBorderThickness.Text = "Border thickness:";
            labelBorderThickness.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownBorderThickness
            // 
            numericUpDownBorderThickness.DecimalPlaces = 1;
            numericUpDownBorderThickness.Location = new Point(288, 114);
            numericUpDownBorderThickness.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownBorderThickness.Name = "numericUpDownBorderThickness";
            numericUpDownBorderThickness.Size = new Size(70, 27);
            numericUpDownBorderThickness.TabIndex = 3;
            numericUpDownBorderThickness.TextAlign = HorizontalAlignment.Right;
            numericUpDownBorderThickness.Enter += ControlFocusEnter;
            // 
            // labelBrush
            // 
            labelBrush.AutoSize = true;
            labelBrush.Dock = DockStyle.Fill;
            labelBrush.Location = new Point(162, 144);
            labelBrush.Name = "labelBrush";
            labelBrush.Size = new Size(120, 34);
            labelBrush.TabIndex = 4;
            labelBrush.Text = "Brush:";
            labelBrush.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxBrush
            // 
            comboBoxBrush.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrush.Location = new Point(288, 147);
            comboBoxBrush.Name = "comboBoxBrush";
            comboBoxBrush.Size = new Size(250, 28);
            comboBoxBrush.TabIndex = 5;
            // 
            // labelSection1
            // 
            labelSection1.AutoSize = true;
            labelSection1.Dock = DockStyle.Fill;
            labelSection1.Location = new Point(162, 178);
            labelSection1.Name = "labelSection1";
            labelSection1.Size = new Size(120, 34);
            labelSection1.TabIndex = 6;
            labelSection1.Text = "Section 1:";
            labelSection1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxSection1
            // 
            comboBoxSection1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSection1.Enabled = false;
            comboBoxSection1.Location = new Point(288, 181);
            comboBoxSection1.Name = "comboBoxSection1";
            comboBoxSection1.Size = new Size(250, 28);
            comboBoxSection1.TabIndex = 7;
            // 
            // labelPositionX1
            // 
            labelPositionX1.AutoSize = true;
            labelPositionX1.Dock = DockStyle.Fill;
            labelPositionX1.Location = new Point(162, 212);
            labelPositionX1.Name = "labelPositionX1";
            labelPositionX1.Size = new Size(120, 33);
            labelPositionX1.TabIndex = 8;
            labelPositionX1.Text = "Position X1 (cm):";
            labelPositionX1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPositionX1
            // 
            numericUpDownPositionX1.DecimalPlaces = 2;
            numericUpDownPositionX1.Location = new Point(288, 215);
            numericUpDownPositionX1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPositionX1.Name = "numericUpDownPositionX1";
            numericUpDownPositionX1.Size = new Size(80, 27);
            numericUpDownPositionX1.TabIndex = 9;
            numericUpDownPositionX1.TextAlign = HorizontalAlignment.Right;
            numericUpDownPositionX1.Enter += ControlFocusEnter;
            // 
            // labelPositionY1
            // 
            labelPositionY1.AutoSize = true;
            labelPositionY1.Dock = DockStyle.Fill;
            labelPositionY1.Location = new Point(162, 245);
            labelPositionY1.Name = "labelPositionY1";
            labelPositionY1.Size = new Size(120, 33);
            labelPositionY1.TabIndex = 10;
            labelPositionY1.Text = "Position Y1 (cm):";
            labelPositionY1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPositionY1
            // 
            numericUpDownPositionY1.DecimalPlaces = 2;
            numericUpDownPositionY1.Location = new Point(288, 248);
            numericUpDownPositionY1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPositionY1.Name = "numericUpDownPositionY1";
            numericUpDownPositionY1.Size = new Size(80, 27);
            numericUpDownPositionY1.TabIndex = 11;
            numericUpDownPositionY1.TextAlign = HorizontalAlignment.Right;
            numericUpDownPositionY1.Enter += ControlFocusEnter;
            // 
            // labelSection2
            // 
            labelSection2.AutoSize = true;
            labelSection2.Dock = DockStyle.Fill;
            labelSection2.Location = new Point(162, 278);
            labelSection2.Name = "labelSection2";
            labelSection2.Size = new Size(120, 34);
            labelSection2.TabIndex = 12;
            labelSection2.Text = "Section 2:";
            labelSection2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxSection2
            // 
            comboBoxSection2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSection2.Enabled = false;
            comboBoxSection2.Location = new Point(288, 281);
            comboBoxSection2.Name = "comboBoxSection2";
            comboBoxSection2.Size = new Size(250, 28);
            comboBoxSection2.TabIndex = 13;
            // 
            // labelPositionX2
            // 
            labelPositionX2.AutoSize = true;
            labelPositionX2.Dock = DockStyle.Fill;
            labelPositionX2.Location = new Point(162, 312);
            labelPositionX2.Name = "labelPositionX2";
            labelPositionX2.Size = new Size(120, 33);
            labelPositionX2.TabIndex = 14;
            labelPositionX2.Text = "Position X2 (cm):";
            labelPositionX2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPositionX2
            // 
            numericUpDownPositionX2.DecimalPlaces = 2;
            numericUpDownPositionX2.Location = new Point(288, 315);
            numericUpDownPositionX2.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPositionX2.Name = "numericUpDownPositionX2";
            numericUpDownPositionX2.Size = new Size(80, 27);
            numericUpDownPositionX2.TabIndex = 15;
            numericUpDownPositionX2.TextAlign = HorizontalAlignment.Right;
            numericUpDownPositionX2.Enter += ControlFocusEnter;
            // 
            // labelPositionY2
            // 
            labelPositionY2.AutoSize = true;
            labelPositionY2.Dock = DockStyle.Fill;
            labelPositionY2.Location = new Point(162, 345);
            labelPositionY2.Name = "labelPositionY2";
            labelPositionY2.Size = new Size(120, 33);
            labelPositionY2.TabIndex = 16;
            labelPositionY2.Text = "Position Y2 (cm):";
            labelPositionY2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPositionY2
            // 
            numericUpDownPositionY2.DecimalPlaces = 2;
            numericUpDownPositionY2.Location = new Point(288, 348);
            numericUpDownPositionY2.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPositionY2.Name = "numericUpDownPositionY2";
            numericUpDownPositionY2.Size = new Size(80, 27);
            numericUpDownPositionY2.TabIndex = 17;
            numericUpDownPositionY2.TextAlign = HorizontalAlignment.Right;
            numericUpDownPositionY2.Enter += ControlFocusEnter;
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
            tableLayoutPanelButtons.Location = new Point(288, 381);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(206, 40);
            tableLayoutPanelButtons.TabIndex = 18;
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
            // PanelRectangle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelRectangle";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tableLayoutPanelBorderColor.ResumeLayout(false);
            tableLayoutPanelBorderColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBorderThickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionX1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionX2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPositionY2).EndInit();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private NumericUpDown numericUpDownBorderThickness;
        private ComboBox comboBoxSection2;
        private Label labelSection2;
        private NumericUpDown numericUpDownPositionY2;
        private NumericUpDown numericUpDownPositionX2;
        private NumericUpDown numericUpDownPositionY1;
        private NumericUpDown numericUpDownPositionX1;
        private TableLayoutPanel tableLayoutPanelBorderColor;
        private TextBox textBoxBorderColor;
        private Button buttonBorderColor;
        private Label labelBorderColor;
        private Label labelBorderThickness;
        private ComboBox comboBoxSection1;
        private Label labelSection1;
        private Label labelPositionX1;
        private Label labelPositionY1;
        private Label labelPositionX2;
        private Label labelPositionY2;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonDelete;
        private Button buttonApply;
        private Button buttonReset;
        private ComboBox comboBoxBrush;
        private Label labelBrush;
    }
}
