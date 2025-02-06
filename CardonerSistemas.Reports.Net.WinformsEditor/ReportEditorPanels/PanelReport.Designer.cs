namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    partial class PanelReport
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
            labelReportId = new Label();
            textBoxReportId = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelTemplateFileName = new Label();
            textBoxTemplateFileName = new TextBox();
            labelPageSize = new Label();
            comboBoxPageSize = new ComboBox();
            labelPageOrientation = new Label();
            comboBoxPageOrientation = new ComboBox();
            labelPageMarginTop = new Label();
            numericUpDownPageMarginTop = new NumericUpDown();
            labelPageMarginLeft = new Label();
            numericUpDownPageMarginLeft = new NumericUpDown();
            labelPageMarginRight = new Label();
            numericUpDownPageMarginRight = new NumericUpDown();
            labelPageMarginBottom = new Label();
            numericUpDownPageMarginBottom = new NumericUpDown();
            labelDetailSectionMaxRowCount = new Label();
            numericUpDownDetailSectionMaxRowCount = new NumericUpDown();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDetailSectionMaxRowCount).BeginInit();
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
            tableLayoutPanelMain.Controls.Add(labelReportId, 1, 1);
            tableLayoutPanelMain.Controls.Add(textBoxReportId, 2, 1);
            tableLayoutPanelMain.Controls.Add(labelName, 1, 2);
            tableLayoutPanelMain.Controls.Add(textBoxName, 2, 2);
            tableLayoutPanelMain.Controls.Add(labelTemplateFileName, 1, 3);
            tableLayoutPanelMain.Controls.Add(textBoxTemplateFileName, 2, 3);
            tableLayoutPanelMain.Controls.Add(labelPageSize, 1, 4);
            tableLayoutPanelMain.Controls.Add(comboBoxPageSize, 2, 4);
            tableLayoutPanelMain.Controls.Add(labelPageOrientation, 1, 5);
            tableLayoutPanelMain.Controls.Add(comboBoxPageOrientation, 2, 5);
            tableLayoutPanelMain.Controls.Add(labelPageMarginTop, 1, 6);
            tableLayoutPanelMain.Controls.Add(numericUpDownPageMarginTop, 2, 6);
            tableLayoutPanelMain.Controls.Add(labelPageMarginLeft, 1, 7);
            tableLayoutPanelMain.Controls.Add(numericUpDownPageMarginLeft, 2, 7);
            tableLayoutPanelMain.Controls.Add(labelPageMarginRight, 1, 8);
            tableLayoutPanelMain.Controls.Add(numericUpDownPageMarginRight, 2, 8);
            tableLayoutPanelMain.Controls.Add(labelPageMarginBottom, 1, 9);
            tableLayoutPanelMain.Controls.Add(numericUpDownPageMarginBottom, 2, 9);
            tableLayoutPanelMain.Controls.Add(labelDetailSectionMaxRowCount, 1, 10);
            tableLayoutPanelMain.Controls.Add(numericUpDownDetailSectionMaxRowCount, 2, 10);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 11);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 13;
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
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelReportId
            // 
            labelReportId.AutoSize = true;
            labelReportId.Dock = DockStyle.Fill;
            labelReportId.Location = new Point(32, 61);
            labelReportId.Name = "labelReportId";
            labelReportId.Size = new Size(230, 33);
            labelReportId.TabIndex = 0;
            labelReportId.Text = "Id:";
            labelReportId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportId
            // 
            textBoxReportId.Dock = DockStyle.Fill;
            textBoxReportId.Location = new Point(268, 64);
            textBoxReportId.Name = "textBoxReportId";
            textBoxReportId.ReadOnly = true;
            textBoxReportId.Size = new Size(400, 27);
            textBoxReportId.TabIndex = 1;
            textBoxReportId.TextAlign = HorizontalAlignment.Center;
            textBoxReportId.Enter += TextBoxs_Enter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(32, 94);
            labelName.Name = "labelName";
            labelName.Size = new Size(230, 33);
            labelName.TabIndex = 2;
            labelName.Text = "Name:";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(268, 97);
            textBoxName.MaxLength = 100;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(400, 27);
            textBoxName.TabIndex = 3;
            textBoxName.Enter += TextBoxs_Enter;
            // 
            // labelTemplateFileName
            // 
            labelTemplateFileName.AutoSize = true;
            labelTemplateFileName.Dock = DockStyle.Fill;
            labelTemplateFileName.Location = new Point(32, 127);
            labelTemplateFileName.Name = "labelTemplateFileName";
            labelTemplateFileName.Size = new Size(230, 33);
            labelTemplateFileName.TabIndex = 4;
            labelTemplateFileName.Text = "Template file:";
            labelTemplateFileName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxTemplateFileName
            // 
            textBoxTemplateFileName.Dock = DockStyle.Fill;
            textBoxTemplateFileName.Location = new Point(268, 130);
            textBoxTemplateFileName.MaxLength = 255;
            textBoxTemplateFileName.Name = "textBoxTemplateFileName";
            textBoxTemplateFileName.Size = new Size(400, 27);
            textBoxTemplateFileName.TabIndex = 5;
            textBoxTemplateFileName.Enter += TextBoxs_Enter;
            // 
            // labelPageSize
            // 
            labelPageSize.AutoSize = true;
            labelPageSize.Dock = DockStyle.Fill;
            labelPageSize.Location = new Point(32, 160);
            labelPageSize.Name = "labelPageSize";
            labelPageSize.Size = new Size(230, 34);
            labelPageSize.TabIndex = 6;
            labelPageSize.Text = "Page size:";
            labelPageSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageSize
            // 
            comboBoxPageSize.Dock = DockStyle.Fill;
            comboBoxPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageSize.FormattingEnabled = true;
            comboBoxPageSize.Location = new Point(268, 163);
            comboBoxPageSize.Name = "comboBoxPageSize";
            comboBoxPageSize.Size = new Size(400, 28);
            comboBoxPageSize.TabIndex = 7;
            // 
            // labelPageOrientation
            // 
            labelPageOrientation.AutoSize = true;
            labelPageOrientation.Dock = DockStyle.Fill;
            labelPageOrientation.Location = new Point(32, 194);
            labelPageOrientation.Name = "labelPageOrientation";
            labelPageOrientation.Size = new Size(230, 34);
            labelPageOrientation.TabIndex = 8;
            labelPageOrientation.Text = "Page orientation:";
            labelPageOrientation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageOrientation
            // 
            comboBoxPageOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageOrientation.FormattingEnabled = true;
            comboBoxPageOrientation.Location = new Point(268, 197);
            comboBoxPageOrientation.Name = "comboBoxPageOrientation";
            comboBoxPageOrientation.Size = new Size(151, 28);
            comboBoxPageOrientation.TabIndex = 9;
            // 
            // labelPageMarginTop
            // 
            labelPageMarginTop.AutoSize = true;
            labelPageMarginTop.Dock = DockStyle.Fill;
            labelPageMarginTop.Location = new Point(32, 228);
            labelPageMarginTop.Name = "labelPageMarginTop";
            labelPageMarginTop.Size = new Size(230, 33);
            labelPageMarginTop.TabIndex = 10;
            labelPageMarginTop.Text = "Page margin - top (cm):";
            labelPageMarginTop.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPageMarginTop
            // 
            numericUpDownPageMarginTop.DecimalPlaces = 2;
            numericUpDownPageMarginTop.Location = new Point(268, 231);
            numericUpDownPageMarginTop.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginTop.Name = "numericUpDownPageMarginTop";
            numericUpDownPageMarginTop.Size = new Size(72, 27);
            numericUpDownPageMarginTop.TabIndex = 11;
            numericUpDownPageMarginTop.TextAlign = HorizontalAlignment.Right;
            numericUpDownPageMarginTop.Enter += TextBoxs_Enter;
            // 
            // labelPageMarginLeft
            // 
            labelPageMarginLeft.AutoSize = true;
            labelPageMarginLeft.Dock = DockStyle.Fill;
            labelPageMarginLeft.Location = new Point(32, 261);
            labelPageMarginLeft.Name = "labelPageMarginLeft";
            labelPageMarginLeft.Size = new Size(230, 33);
            labelPageMarginLeft.TabIndex = 12;
            labelPageMarginLeft.Text = "Page margin - left (cm):";
            labelPageMarginLeft.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPageMarginLeft
            // 
            numericUpDownPageMarginLeft.DecimalPlaces = 2;
            numericUpDownPageMarginLeft.Location = new Point(268, 264);
            numericUpDownPageMarginLeft.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginLeft.Name = "numericUpDownPageMarginLeft";
            numericUpDownPageMarginLeft.Size = new Size(72, 27);
            numericUpDownPageMarginLeft.TabIndex = 13;
            numericUpDownPageMarginLeft.TextAlign = HorizontalAlignment.Right;
            numericUpDownPageMarginLeft.Enter += TextBoxs_Enter;
            // 
            // labelPageMarginRight
            // 
            labelPageMarginRight.AutoSize = true;
            labelPageMarginRight.Dock = DockStyle.Fill;
            labelPageMarginRight.Location = new Point(32, 294);
            labelPageMarginRight.Name = "labelPageMarginRight";
            labelPageMarginRight.Size = new Size(230, 33);
            labelPageMarginRight.TabIndex = 14;
            labelPageMarginRight.Text = "Page margin - right (cm):";
            labelPageMarginRight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPageMarginRight
            // 
            numericUpDownPageMarginRight.DecimalPlaces = 2;
            numericUpDownPageMarginRight.Location = new Point(268, 297);
            numericUpDownPageMarginRight.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginRight.Name = "numericUpDownPageMarginRight";
            numericUpDownPageMarginRight.Size = new Size(72, 27);
            numericUpDownPageMarginRight.TabIndex = 15;
            numericUpDownPageMarginRight.TextAlign = HorizontalAlignment.Right;
            numericUpDownPageMarginRight.Enter += TextBoxs_Enter;
            // 
            // labelPageMarginBottom
            // 
            labelPageMarginBottom.AutoSize = true;
            labelPageMarginBottom.Dock = DockStyle.Fill;
            labelPageMarginBottom.Location = new Point(32, 327);
            labelPageMarginBottom.Name = "labelPageMarginBottom";
            labelPageMarginBottom.Size = new Size(230, 33);
            labelPageMarginBottom.TabIndex = 16;
            labelPageMarginBottom.Text = "Page margin - bottom (cm):";
            labelPageMarginBottom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownPageMarginBottom
            // 
            numericUpDownPageMarginBottom.DecimalPlaces = 2;
            numericUpDownPageMarginBottom.Location = new Point(268, 330);
            numericUpDownPageMarginBottom.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginBottom.Name = "numericUpDownPageMarginBottom";
            numericUpDownPageMarginBottom.Size = new Size(72, 27);
            numericUpDownPageMarginBottom.TabIndex = 17;
            numericUpDownPageMarginBottom.TextAlign = HorizontalAlignment.Right;
            numericUpDownPageMarginBottom.Enter += TextBoxs_Enter;
            // 
            // labelDetailSectionMaxRowCount
            // 
            labelDetailSectionMaxRowCount.AutoSize = true;
            labelDetailSectionMaxRowCount.Dock = DockStyle.Fill;
            labelDetailSectionMaxRowCount.Location = new Point(32, 360);
            labelDetailSectionMaxRowCount.Name = "labelDetailSectionMaxRowCount";
            labelDetailSectionMaxRowCount.Size = new Size(230, 33);
            labelDetailSectionMaxRowCount.TabIndex = 18;
            labelDetailSectionMaxRowCount.Text = "Max. row count of detail sections:";
            labelDetailSectionMaxRowCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDetailSectionMaxRowCount
            // 
            numericUpDownDetailSectionMaxRowCount.Location = new Point(268, 363);
            numericUpDownDetailSectionMaxRowCount.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDownDetailSectionMaxRowCount.Name = "numericUpDownDetailSectionMaxRowCount";
            numericUpDownDetailSectionMaxRowCount.Size = new Size(54, 27);
            numericUpDownDetailSectionMaxRowCount.TabIndex = 19;
            numericUpDownDetailSectionMaxRowCount.TextAlign = HorizontalAlignment.Right;
            numericUpDownDetailSectionMaxRowCount.Enter += TextBoxs_Enter;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 2;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButtons.Controls.Add(buttonApply, 0, 0);
            tableLayoutPanelButtons.Controls.Add(buttonReset, 1, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(268, 396);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(133, 40);
            tableLayoutPanelButtons.TabIndex = 20;
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
            // PanelReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelReport";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDetailSectionMaxRowCount).EndInit();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelReportId;
        private Label labelName;
        private Label labelTemplateFileName;
        private Label labelPageSize;
        private Label labelPageOrientation;
        private Label labelPageMarginTop;
        private Label labelPageMarginLeft;
        private Label labelPageMarginRight;
        private Label labelPageMarginBottom;
        private Label labelDetailSectionMaxRowCount;
        private TableLayoutPanel tableLayoutPanelButtons;
        private TextBox textBoxReportId;
        private TextBox textBoxName;
        private TextBox textBoxTemplateFileName;
        private ComboBox comboBoxPageSize;
        private ComboBox comboBoxPageOrientation;
        private NumericUpDown numericUpDownPageMarginTop;
        private NumericUpDown numericUpDownPageMarginLeft;
        private NumericUpDown numericUpDownPageMarginRight;
        private NumericUpDown numericUpDownPageMarginBottom;
        private NumericUpDown numericUpDownDetailSectionMaxRowCount;
        private Button buttonApply;
        private Button buttonReset;
    }
}
