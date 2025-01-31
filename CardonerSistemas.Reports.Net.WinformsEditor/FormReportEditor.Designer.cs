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
            TableLayoutPanelReport = new TableLayoutPanel();
            numericUpDownPageMarginBottom = new NumericUpDown();
            numericUpDownPageMarginRight = new NumericUpDown();
            numericUpDownPageMarginLeft = new NumericUpDown();
            numericUpDownPageMarginTop = new NumericUpDown();
            textBoxTemplateFileName = new TextBox();
            labelDetailSectionMaxRowCount = new Label();
            labelTemplateFileName = new Label();
            labelPageMarginBottom = new Label();
            labelPageMarginRight = new Label();
            labelPageMarginLeft = new Label();
            labelPageMarginTop = new Label();
            labelReportId = new Label();
            textBoxReportId = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelPageSize = new Label();
            comboBoxPageSize = new ComboBox();
            labelPageOrientation = new Label();
            comboBoxPageOrientation = new ComboBox();
            numericUpDownDetailSectionMaxRowCount = new NumericUpDown();
            ImageListMain = new ImageList(components);
            toolTipMain = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)SplitContainerMain).BeginInit();
            SplitContainerMain.Panel1.SuspendLayout();
            SplitContainerMain.Panel2.SuspendLayout();
            SplitContainerMain.SuspendLayout();
            TableLayoutPanelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDetailSectionMaxRowCount).BeginInit();
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
            SplitContainerMain.Panel2.Controls.Add(TableLayoutPanelReport);
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
            TreeViewReport.AfterSelect += TreeViewReport_AfterSelect;
            // 
            // TableLayoutPanelReport
            // 
            TableLayoutPanelReport.ColumnCount = 4;
            TableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle());
            TableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle());
            TableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanelReport.Controls.Add(labelReportId, 1, 1);
            TableLayoutPanelReport.Controls.Add(textBoxReportId, 2, 1);
            TableLayoutPanelReport.Controls.Add(labelName, 1, 2);
            TableLayoutPanelReport.Controls.Add(textBoxName, 2, 2);
            TableLayoutPanelReport.Controls.Add(labelTemplateFileName, 1, 3);
            TableLayoutPanelReport.Controls.Add(textBoxTemplateFileName, 2, 3);
            TableLayoutPanelReport.Controls.Add(labelPageSize, 1, 4);
            TableLayoutPanelReport.Controls.Add(comboBoxPageSize, 2, 4);
            TableLayoutPanelReport.Controls.Add(labelPageOrientation, 1, 5);
            TableLayoutPanelReport.Controls.Add(comboBoxPageOrientation, 2, 5);
            TableLayoutPanelReport.Controls.Add(labelPageMarginTop, 1, 6);
            TableLayoutPanelReport.Controls.Add(numericUpDownPageMarginTop, 2, 6);
            TableLayoutPanelReport.Controls.Add(labelPageMarginLeft, 1, 7);
            TableLayoutPanelReport.Controls.Add(numericUpDownPageMarginLeft, 2, 7);
            TableLayoutPanelReport.Controls.Add(labelPageMarginRight, 1, 8);
            TableLayoutPanelReport.Controls.Add(numericUpDownPageMarginRight, 2, 8);
            TableLayoutPanelReport.Controls.Add(labelPageMarginBottom, 1, 9);
            TableLayoutPanelReport.Controls.Add(numericUpDownPageMarginBottom, 2, 9);
            TableLayoutPanelReport.Controls.Add(labelDetailSectionMaxRowCount, 1, 10);
            TableLayoutPanelReport.Controls.Add(numericUpDownDetailSectionMaxRowCount, 2, 10);
            TableLayoutPanelReport.Dock = DockStyle.Fill;
            TableLayoutPanelReport.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TableLayoutPanelReport.Location = new Point(0, 0);
            TableLayoutPanelReport.Name = "TableLayoutPanelReport";
            TableLayoutPanelReport.RowCount = 12;
            TableLayoutPanelReport.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle());
            TableLayoutPanelReport.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutPanelReport.Size = new Size(808, 661);
            TableLayoutPanelReport.TabIndex = 0;
            TableLayoutPanelReport.Visible = false;
            // 
            // numericUpDownPageMarginBottom
            // 
            numericUpDownPageMarginBottom.DecimalPlaces = 2;
            numericUpDownPageMarginBottom.Location = new Point(322, 433);
            numericUpDownPageMarginBottom.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginBottom.Name = "numericUpDownPageMarginBottom";
            numericUpDownPageMarginBottom.Size = new Size(72, 27);
            numericUpDownPageMarginBottom.TabIndex = 23;
            numericUpDownPageMarginBottom.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownPageMarginBottom, "Set to zero for unlimited rows.");
            // 
            // numericUpDownPageMarginRight
            // 
            numericUpDownPageMarginRight.DecimalPlaces = 2;
            numericUpDownPageMarginRight.Location = new Point(322, 400);
            numericUpDownPageMarginRight.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginRight.Name = "numericUpDownPageMarginRight";
            numericUpDownPageMarginRight.Size = new Size(72, 27);
            numericUpDownPageMarginRight.TabIndex = 22;
            numericUpDownPageMarginRight.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownPageMarginRight, "Set to zero for unlimited rows.");
            // 
            // numericUpDownPageMarginLeft
            // 
            numericUpDownPageMarginLeft.DecimalPlaces = 2;
            numericUpDownPageMarginLeft.Location = new Point(322, 367);
            numericUpDownPageMarginLeft.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginLeft.Name = "numericUpDownPageMarginLeft";
            numericUpDownPageMarginLeft.Size = new Size(72, 27);
            numericUpDownPageMarginLeft.TabIndex = 21;
            numericUpDownPageMarginLeft.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownPageMarginLeft, "Set to zero for unlimited rows.");
            // 
            // numericUpDownPageMarginTop
            // 
            numericUpDownPageMarginTop.DecimalPlaces = 2;
            numericUpDownPageMarginTop.Location = new Point(322, 334);
            numericUpDownPageMarginTop.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPageMarginTop.Name = "numericUpDownPageMarginTop";
            numericUpDownPageMarginTop.Size = new Size(72, 27);
            numericUpDownPageMarginTop.TabIndex = 20;
            numericUpDownPageMarginTop.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownPageMarginTop, "Set to zero for unlimited rows.");
            // 
            // textBoxTemplateFileName
            // 
            textBoxTemplateFileName.Dock = DockStyle.Fill;
            textBoxTemplateFileName.Location = new Point(322, 233);
            textBoxTemplateFileName.MaxLength = 255;
            textBoxTemplateFileName.Name = "textBoxTemplateFileName";
            textBoxTemplateFileName.Size = new Size(400, 27);
            textBoxTemplateFileName.TabIndex = 18;
            toolTipMain.SetToolTip(textBoxTemplateFileName, "Use fullpath or filename only if the template file is located in the same folder of the report file.");
            // 
            // labelDetailSectionMaxRowCount
            // 
            labelDetailSectionMaxRowCount.AutoSize = true;
            labelDetailSectionMaxRowCount.Dock = DockStyle.Fill;
            labelDetailSectionMaxRowCount.Location = new Point(86, 463);
            labelDetailSectionMaxRowCount.Name = "labelDetailSectionMaxRowCount";
            labelDetailSectionMaxRowCount.Size = new Size(230, 33);
            labelDetailSectionMaxRowCount.TabIndex = 17;
            labelDetailSectionMaxRowCount.Text = "Max. row count of detail sections:";
            labelDetailSectionMaxRowCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTemplateFileName
            // 
            labelTemplateFileName.AutoSize = true;
            labelTemplateFileName.Dock = DockStyle.Fill;
            labelTemplateFileName.Location = new Point(86, 230);
            labelTemplateFileName.Name = "labelTemplateFileName";
            labelTemplateFileName.Size = new Size(230, 33);
            labelTemplateFileName.TabIndex = 16;
            labelTemplateFileName.Text = "Template file:";
            labelTemplateFileName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPageMarginBottom
            // 
            labelPageMarginBottom.AutoSize = true;
            labelPageMarginBottom.Dock = DockStyle.Fill;
            labelPageMarginBottom.Location = new Point(86, 430);
            labelPageMarginBottom.Name = "labelPageMarginBottom";
            labelPageMarginBottom.Size = new Size(230, 33);
            labelPageMarginBottom.TabIndex = 11;
            labelPageMarginBottom.Text = "Page margin - bottom (cm):";
            labelPageMarginBottom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPageMarginRight
            // 
            labelPageMarginRight.AutoSize = true;
            labelPageMarginRight.Dock = DockStyle.Fill;
            labelPageMarginRight.Location = new Point(86, 397);
            labelPageMarginRight.Name = "labelPageMarginRight";
            labelPageMarginRight.Size = new Size(230, 33);
            labelPageMarginRight.TabIndex = 10;
            labelPageMarginRight.Text = "Page margin - right (cm):";
            labelPageMarginRight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPageMarginLeft
            // 
            labelPageMarginLeft.AutoSize = true;
            labelPageMarginLeft.Dock = DockStyle.Fill;
            labelPageMarginLeft.Location = new Point(86, 364);
            labelPageMarginLeft.Name = "labelPageMarginLeft";
            labelPageMarginLeft.Size = new Size(230, 33);
            labelPageMarginLeft.TabIndex = 9;
            labelPageMarginLeft.Text = "Page margin - left (cm):";
            labelPageMarginLeft.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPageMarginTop
            // 
            labelPageMarginTop.AutoSize = true;
            labelPageMarginTop.Dock = DockStyle.Fill;
            labelPageMarginTop.Location = new Point(86, 331);
            labelPageMarginTop.Name = "labelPageMarginTop";
            labelPageMarginTop.Size = new Size(230, 33);
            labelPageMarginTop.TabIndex = 8;
            labelPageMarginTop.Text = "Page margin - top (cm):";
            labelPageMarginTop.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelReportId
            // 
            labelReportId.AutoSize = true;
            labelReportId.Dock = DockStyle.Fill;
            labelReportId.Location = new Point(86, 164);
            labelReportId.Name = "labelReportId";
            labelReportId.Size = new Size(230, 33);
            labelReportId.TabIndex = 0;
            labelReportId.Text = "Id:";
            labelReportId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportId
            // 
            textBoxReportId.Dock = DockStyle.Fill;
            textBoxReportId.Location = new Point(322, 167);
            textBoxReportId.Name = "textBoxReportId";
            textBoxReportId.ReadOnly = true;
            textBoxReportId.Size = new Size(400, 27);
            textBoxReportId.TabIndex = 1;
            textBoxReportId.TextAlign = HorizontalAlignment.Center;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(86, 197);
            labelName.Name = "labelName";
            labelName.Size = new Size(230, 33);
            labelName.TabIndex = 2;
            labelName.Text = "Name:";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(322, 200);
            textBoxName.MaxLength = 100;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(400, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelPageSize
            // 
            labelPageSize.AutoSize = true;
            labelPageSize.Dock = DockStyle.Fill;
            labelPageSize.Location = new Point(86, 263);
            labelPageSize.Name = "labelPageSize";
            labelPageSize.Size = new Size(230, 34);
            labelPageSize.TabIndex = 4;
            labelPageSize.Text = "Page size:";
            labelPageSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageSize
            // 
            comboBoxPageSize.Dock = DockStyle.Fill;
            comboBoxPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageSize.FormattingEnabled = true;
            comboBoxPageSize.Location = new Point(322, 266);
            comboBoxPageSize.Name = "comboBoxPageSize";
            comboBoxPageSize.Size = new Size(400, 28);
            comboBoxPageSize.TabIndex = 6;
            // 
            // labelPageOrientation
            // 
            labelPageOrientation.AutoSize = true;
            labelPageOrientation.Dock = DockStyle.Fill;
            labelPageOrientation.Location = new Point(86, 297);
            labelPageOrientation.Name = "labelPageOrientation";
            labelPageOrientation.Size = new Size(230, 34);
            labelPageOrientation.TabIndex = 5;
            labelPageOrientation.Text = "Page orientation:";
            labelPageOrientation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageOrientation
            // 
            comboBoxPageOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageOrientation.FormattingEnabled = true;
            comboBoxPageOrientation.Location = new Point(322, 300);
            comboBoxPageOrientation.Name = "comboBoxPageOrientation";
            comboBoxPageOrientation.Size = new Size(151, 28);
            comboBoxPageOrientation.TabIndex = 7;
            // 
            // numericUpDownDetailSectionMaxRowCount
            // 
            numericUpDownDetailSectionMaxRowCount.Location = new Point(322, 466);
            numericUpDownDetailSectionMaxRowCount.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDownDetailSectionMaxRowCount.Name = "numericUpDownDetailSectionMaxRowCount";
            numericUpDownDetailSectionMaxRowCount.Size = new Size(54, 27);
            numericUpDownDetailSectionMaxRowCount.TabIndex = 19;
            numericUpDownDetailSectionMaxRowCount.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownDetailSectionMaxRowCount, "Set to zero for unlimited rows.");
            // 
            // ImageListMain
            // 
            ImageListMain.ColorDepth = ColorDepth.Depth32Bit;
            ImageListMain.ImageStream = (ImageListStreamer)resources.GetObject("ImageListMain.ImageStream");
            ImageListMain.TransparentColor = Color.Transparent;
            ImageListMain.Images.SetKeyName(0, "Report");
            ImageListMain.Images.SetKeyName(1, "Datasource");
            ImageListMain.Images.SetKeyName(2, "DatasourceParameter");
            ImageListMain.Images.SetKeyName(3, "Fonts");
            ImageListMain.Images.SetKeyName(4, "Font");
            ImageListMain.Images.SetKeyName(5, "Brushes");
            ImageListMain.Images.SetKeyName(6, "Brush");
            ImageListMain.Images.SetKeyName(7, "Sections");
            ImageListMain.Images.SetKeyName(8, "Section");
            ImageListMain.Images.SetKeyName(9, "Rectangles");
            ImageListMain.Images.SetKeyName(10, "Rectangle");
            ImageListMain.Images.SetKeyName(11, "Lines");
            ImageListMain.Images.SetKeyName(12, "Line");
            ImageListMain.Images.SetKeyName(13, "Texts");
            ImageListMain.Images.SetKeyName(14, "Text");
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
            TableLayoutPanelReport.ResumeLayout(false);
            TableLayoutPanelReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPageMarginTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDetailSectionMaxRowCount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer SplitContainerMain;
        private TreeView TreeViewReport;
        private ImageList ImageListMain;
        private TableLayoutPanel TableLayoutPanelReport;
        private Label labelReportId;
        private TextBox textBoxReportId;
        private TextBox textBoxName;
        private Label labelName;
        private Label labelPageOrientation;
        private Label labelPageSize;
        private ComboBox comboBoxPageOrientation;
        private ComboBox comboBoxPageSize;
        private Label labelPageMarginBottom;
        private Label labelPageMarginRight;
        private Label labelPageMarginLeft;
        private Label labelPageMarginTop;
        private Label labelDetailSectionMaxRowCount;
        private Label labelTemplateFileName;
        private TextBox textBoxTemplateFileName;
        private NumericUpDown numericUpDownDetailSectionMaxRowCount;
        private ToolTip toolTipMain;
        private NumericUpDown numericUpDownPageMarginTop;
        private NumericUpDown numericUpDownPageMarginBottom;
        private NumericUpDown numericUpDownPageMarginRight;
        private NumericUpDown numericUpDownPageMarginLeft;
    }
}