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
            splitContainerMain = new SplitContainer();
            treeViewReport = new TreeView();
            tableLayoutPanelReport = new TableLayoutPanel();
            labelReportId = new Label();
            textBoxReportId = new TextBox();
            labelReportName = new Label();
            textBoxReportName = new TextBox();
            labelReportTemplateFileName = new Label();
            textBoxReportTemplateFileName = new TextBox();
            labelReportPageSize = new Label();
            comboBoxReportPageSize = new ComboBox();
            labelReportPageOrientation = new Label();
            comboBoxReportPageOrientation = new ComboBox();
            labelReportPageMarginTop = new Label();
            numericUpDownReportPageMarginTop = new NumericUpDown();
            labelReportPageMarginLeft = new Label();
            numericUpDownReportPageMarginLeft = new NumericUpDown();
            labelReportPageMarginRight = new Label();
            numericUpDownReportPageMarginRight = new NumericUpDown();
            labelReportPageMarginBottom = new Label();
            numericUpDownReportPageMarginBottom = new NumericUpDown();
            labelReportDetailSectionMaxRowCount = new Label();
            numericUpDownReportDetailSectionMaxRowCount = new NumericUpDown();
            tableLayoutPanelReportButtons = new TableLayoutPanel();
            buttonReportApply = new Button();
            buttonReportReset = new Button();
            tableLayoutPanelDatasource = new TableLayoutPanel();
            textBoxDatasourceText = new TextBox();
            labelDatasourceProvider = new Label();
            labelDatasourceConnectionString = new Label();
            textBoxDatasourceConnectionString = new TextBox();
            labelDatasourceType = new Label();
            labelDatasourceText = new Label();
            comboBoxDatasourceProvider = new ComboBox();
            comboBoxDatasourceType = new ComboBox();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonDatasourceTest = new Button();
            buttonDatasourceGetFields = new Button();
            buttonDatasourceReset = new Button();
            buttonDatasourceApply = new Button();
            imageListMain = new ImageList(components);
            toolTipMain = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportDetailSectionMaxRowCount).BeginInit();
            tableLayoutPanelReportButtons.SuspendLayout();
            tableLayoutPanelDatasource.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
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
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(tableLayoutPanelReport);
            splitContainerMain.Panel2.Controls.Add(tableLayoutPanelDatasource);
            splitContainerMain.Size = new Size(1062, 661);
            splitContainerMain.SplitterDistance = 250;
            splitContainerMain.TabIndex = 0;
            // 
            // treeViewReport
            // 
            treeViewReport.Dock = DockStyle.Fill;
            treeViewReport.ItemHeight = 55;
            treeViewReport.Location = new Point(0, 0);
            treeViewReport.Name = "treeViewReport";
            treeViewReport.ShowRootLines = false;
            treeViewReport.Size = new Size(250, 661);
            treeViewReport.TabIndex = 0;
            treeViewReport.AfterSelect += TreeViewReport_AfterSelect;
            // 
            // tableLayoutPanelReport
            // 
            tableLayoutPanelReport.ColumnCount = 4;
            tableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelReport.Controls.Add(labelReportId, 1, 1);
            tableLayoutPanelReport.Controls.Add(textBoxReportId, 2, 1);
            tableLayoutPanelReport.Controls.Add(labelReportName, 1, 2);
            tableLayoutPanelReport.Controls.Add(textBoxReportName, 2, 2);
            tableLayoutPanelReport.Controls.Add(labelReportTemplateFileName, 1, 3);
            tableLayoutPanelReport.Controls.Add(textBoxReportTemplateFileName, 2, 3);
            tableLayoutPanelReport.Controls.Add(labelReportPageSize, 1, 4);
            tableLayoutPanelReport.Controls.Add(comboBoxReportPageSize, 2, 4);
            tableLayoutPanelReport.Controls.Add(labelReportPageOrientation, 1, 5);
            tableLayoutPanelReport.Controls.Add(comboBoxReportPageOrientation, 2, 5);
            tableLayoutPanelReport.Controls.Add(labelReportPageMarginTop, 1, 6);
            tableLayoutPanelReport.Controls.Add(numericUpDownReportPageMarginTop, 2, 6);
            tableLayoutPanelReport.Controls.Add(labelReportPageMarginLeft, 1, 7);
            tableLayoutPanelReport.Controls.Add(numericUpDownReportPageMarginLeft, 2, 7);
            tableLayoutPanelReport.Controls.Add(labelReportPageMarginRight, 1, 8);
            tableLayoutPanelReport.Controls.Add(numericUpDownReportPageMarginRight, 2, 8);
            tableLayoutPanelReport.Controls.Add(labelReportPageMarginBottom, 1, 9);
            tableLayoutPanelReport.Controls.Add(numericUpDownReportPageMarginBottom, 2, 9);
            tableLayoutPanelReport.Controls.Add(labelReportDetailSectionMaxRowCount, 1, 10);
            tableLayoutPanelReport.Controls.Add(numericUpDownReportDetailSectionMaxRowCount, 2, 10);
            tableLayoutPanelReport.Controls.Add(tableLayoutPanelReportButtons, 2, 11);
            tableLayoutPanelReport.Dock = DockStyle.Fill;
            tableLayoutPanelReport.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelReport.Location = new Point(0, 0);
            tableLayoutPanelReport.Name = "tableLayoutPanelReport";
            tableLayoutPanelReport.RowCount = 13;
            tableLayoutPanelReport.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle());
            tableLayoutPanelReport.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelReport.Size = new Size(808, 661);
            tableLayoutPanelReport.TabIndex = 0;
            tableLayoutPanelReport.Visible = false;
            // 
            // labelReportId
            // 
            labelReportId.AutoSize = true;
            labelReportId.Dock = DockStyle.Fill;
            labelReportId.Location = new Point(86, 141);
            labelReportId.Name = "labelReportId";
            labelReportId.Size = new Size(230, 33);
            labelReportId.TabIndex = 0;
            labelReportId.Text = "Id:";
            labelReportId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportId
            // 
            textBoxReportId.Dock = DockStyle.Fill;
            textBoxReportId.Location = new Point(322, 144);
            textBoxReportId.Name = "textBoxReportId";
            textBoxReportId.ReadOnly = true;
            textBoxReportId.Size = new Size(400, 27);
            textBoxReportId.TabIndex = 1;
            textBoxReportId.TextAlign = HorizontalAlignment.Center;
            textBoxReportId.Enter += TextBoxs_Enter;
            // 
            // labelReportName
            // 
            labelReportName.AutoSize = true;
            labelReportName.Dock = DockStyle.Fill;
            labelReportName.Location = new Point(86, 174);
            labelReportName.Name = "labelReportName";
            labelReportName.Size = new Size(230, 33);
            labelReportName.TabIndex = 2;
            labelReportName.Text = "Name:";
            labelReportName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportName
            // 
            textBoxReportName.Dock = DockStyle.Fill;
            textBoxReportName.Location = new Point(322, 177);
            textBoxReportName.MaxLength = 100;
            textBoxReportName.Name = "textBoxReportName";
            textBoxReportName.Size = new Size(400, 27);
            textBoxReportName.TabIndex = 3;
            textBoxReportName.Enter += TextBoxs_Enter;
            // 
            // labelReportTemplateFileName
            // 
            labelReportTemplateFileName.AutoSize = true;
            labelReportTemplateFileName.Dock = DockStyle.Fill;
            labelReportTemplateFileName.Location = new Point(86, 207);
            labelReportTemplateFileName.Name = "labelReportTemplateFileName";
            labelReportTemplateFileName.Size = new Size(230, 33);
            labelReportTemplateFileName.TabIndex = 4;
            labelReportTemplateFileName.Text = "Template file:";
            labelReportTemplateFileName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportTemplateFileName
            // 
            textBoxReportTemplateFileName.Dock = DockStyle.Fill;
            textBoxReportTemplateFileName.Location = new Point(322, 210);
            textBoxReportTemplateFileName.MaxLength = 255;
            textBoxReportTemplateFileName.Name = "textBoxReportTemplateFileName";
            textBoxReportTemplateFileName.Size = new Size(400, 27);
            textBoxReportTemplateFileName.TabIndex = 5;
            toolTipMain.SetToolTip(textBoxReportTemplateFileName, "Use fullpath or filename only if the template file is located in the same folder of the report file.");
            textBoxReportTemplateFileName.Enter += TextBoxs_Enter;
            // 
            // labelReportPageSize
            // 
            labelReportPageSize.AutoSize = true;
            labelReportPageSize.Dock = DockStyle.Fill;
            labelReportPageSize.Location = new Point(86, 240);
            labelReportPageSize.Name = "labelReportPageSize";
            labelReportPageSize.Size = new Size(230, 34);
            labelReportPageSize.TabIndex = 6;
            labelReportPageSize.Text = "Page size:";
            labelReportPageSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxReportPageSize
            // 
            comboBoxReportPageSize.Dock = DockStyle.Fill;
            comboBoxReportPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxReportPageSize.FormattingEnabled = true;
            comboBoxReportPageSize.Location = new Point(322, 243);
            comboBoxReportPageSize.Name = "comboBoxReportPageSize";
            comboBoxReportPageSize.Size = new Size(400, 28);
            comboBoxReportPageSize.TabIndex = 7;
            // 
            // labelReportPageOrientation
            // 
            labelReportPageOrientation.AutoSize = true;
            labelReportPageOrientation.Dock = DockStyle.Fill;
            labelReportPageOrientation.Location = new Point(86, 274);
            labelReportPageOrientation.Name = "labelReportPageOrientation";
            labelReportPageOrientation.Size = new Size(230, 34);
            labelReportPageOrientation.TabIndex = 8;
            labelReportPageOrientation.Text = "Page orientation:";
            labelReportPageOrientation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxReportPageOrientation
            // 
            comboBoxReportPageOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxReportPageOrientation.FormattingEnabled = true;
            comboBoxReportPageOrientation.Location = new Point(322, 277);
            comboBoxReportPageOrientation.Name = "comboBoxReportPageOrientation";
            comboBoxReportPageOrientation.Size = new Size(151, 28);
            comboBoxReportPageOrientation.TabIndex = 9;
            // 
            // labelReportPageMarginTop
            // 
            labelReportPageMarginTop.AutoSize = true;
            labelReportPageMarginTop.Dock = DockStyle.Fill;
            labelReportPageMarginTop.Location = new Point(86, 308);
            labelReportPageMarginTop.Name = "labelReportPageMarginTop";
            labelReportPageMarginTop.Size = new Size(230, 33);
            labelReportPageMarginTop.TabIndex = 10;
            labelReportPageMarginTop.Text = "Page margin - top (cm):";
            labelReportPageMarginTop.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownReportPageMarginTop
            // 
            numericUpDownReportPageMarginTop.DecimalPlaces = 2;
            numericUpDownReportPageMarginTop.Location = new Point(322, 311);
            numericUpDownReportPageMarginTop.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownReportPageMarginTop.Name = "numericUpDownReportPageMarginTop";
            numericUpDownReportPageMarginTop.Size = new Size(72, 27);
            numericUpDownReportPageMarginTop.TabIndex = 11;
            numericUpDownReportPageMarginTop.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownReportPageMarginTop, "Set to zero for unlimited rows.");
            // 
            // labelReportPageMarginLeft
            // 
            labelReportPageMarginLeft.AutoSize = true;
            labelReportPageMarginLeft.Dock = DockStyle.Fill;
            labelReportPageMarginLeft.Location = new Point(86, 341);
            labelReportPageMarginLeft.Name = "labelReportPageMarginLeft";
            labelReportPageMarginLeft.Size = new Size(230, 33);
            labelReportPageMarginLeft.TabIndex = 12;
            labelReportPageMarginLeft.Text = "Page margin - left (cm):";
            labelReportPageMarginLeft.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownReportPageMarginLeft
            // 
            numericUpDownReportPageMarginLeft.DecimalPlaces = 2;
            numericUpDownReportPageMarginLeft.Location = new Point(322, 344);
            numericUpDownReportPageMarginLeft.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownReportPageMarginLeft.Name = "numericUpDownReportPageMarginLeft";
            numericUpDownReportPageMarginLeft.Size = new Size(72, 27);
            numericUpDownReportPageMarginLeft.TabIndex = 13;
            numericUpDownReportPageMarginLeft.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownReportPageMarginLeft, "Set to zero for unlimited rows.");
            // 
            // labelReportPageMarginRight
            // 
            labelReportPageMarginRight.AutoSize = true;
            labelReportPageMarginRight.Dock = DockStyle.Fill;
            labelReportPageMarginRight.Location = new Point(86, 374);
            labelReportPageMarginRight.Name = "labelReportPageMarginRight";
            labelReportPageMarginRight.Size = new Size(230, 33);
            labelReportPageMarginRight.TabIndex = 14;
            labelReportPageMarginRight.Text = "Page margin - right (cm):";
            labelReportPageMarginRight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownReportPageMarginRight
            // 
            numericUpDownReportPageMarginRight.DecimalPlaces = 2;
            numericUpDownReportPageMarginRight.Location = new Point(322, 377);
            numericUpDownReportPageMarginRight.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownReportPageMarginRight.Name = "numericUpDownReportPageMarginRight";
            numericUpDownReportPageMarginRight.Size = new Size(72, 27);
            numericUpDownReportPageMarginRight.TabIndex = 15;
            numericUpDownReportPageMarginRight.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownReportPageMarginRight, "Set to zero for unlimited rows.");
            // 
            // labelReportPageMarginBottom
            // 
            labelReportPageMarginBottom.AutoSize = true;
            labelReportPageMarginBottom.Dock = DockStyle.Fill;
            labelReportPageMarginBottom.Location = new Point(86, 407);
            labelReportPageMarginBottom.Name = "labelReportPageMarginBottom";
            labelReportPageMarginBottom.Size = new Size(230, 33);
            labelReportPageMarginBottom.TabIndex = 16;
            labelReportPageMarginBottom.Text = "Page margin - bottom (cm):";
            labelReportPageMarginBottom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownReportPageMarginBottom
            // 
            numericUpDownReportPageMarginBottom.DecimalPlaces = 2;
            numericUpDownReportPageMarginBottom.Location = new Point(322, 410);
            numericUpDownReportPageMarginBottom.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownReportPageMarginBottom.Name = "numericUpDownReportPageMarginBottom";
            numericUpDownReportPageMarginBottom.Size = new Size(72, 27);
            numericUpDownReportPageMarginBottom.TabIndex = 17;
            numericUpDownReportPageMarginBottom.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownReportPageMarginBottom, "Set to zero for unlimited rows.");
            // 
            // labelReportDetailSectionMaxRowCount
            // 
            labelReportDetailSectionMaxRowCount.AutoSize = true;
            labelReportDetailSectionMaxRowCount.Dock = DockStyle.Fill;
            labelReportDetailSectionMaxRowCount.Location = new Point(86, 440);
            labelReportDetailSectionMaxRowCount.Name = "labelReportDetailSectionMaxRowCount";
            labelReportDetailSectionMaxRowCount.Size = new Size(230, 33);
            labelReportDetailSectionMaxRowCount.TabIndex = 18;
            labelReportDetailSectionMaxRowCount.Text = "Max. row count of detail sections:";
            labelReportDetailSectionMaxRowCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownReportDetailSectionMaxRowCount
            // 
            numericUpDownReportDetailSectionMaxRowCount.Location = new Point(322, 443);
            numericUpDownReportDetailSectionMaxRowCount.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDownReportDetailSectionMaxRowCount.Name = "numericUpDownReportDetailSectionMaxRowCount";
            numericUpDownReportDetailSectionMaxRowCount.Size = new Size(54, 27);
            numericUpDownReportDetailSectionMaxRowCount.TabIndex = 19;
            numericUpDownReportDetailSectionMaxRowCount.TextAlign = HorizontalAlignment.Right;
            toolTipMain.SetToolTip(numericUpDownReportDetailSectionMaxRowCount, "Set to zero for unlimited rows.");
            // 
            // tableLayoutPanelReportButtons
            // 
            tableLayoutPanelReportButtons.AutoSize = true;
            tableLayoutPanelReportButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelReportButtons.ColumnCount = 2;
            tableLayoutPanelReportButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReportButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReportButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelReportButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelReportButtons.Controls.Add(buttonReportApply, 0, 0);
            tableLayoutPanelReportButtons.Controls.Add(buttonReportReset, 1, 0);
            tableLayoutPanelReportButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelReportButtons.Location = new Point(322, 476);
            tableLayoutPanelReportButtons.Name = "tableLayoutPanelReportButtons";
            tableLayoutPanelReportButtons.RowCount = 1;
            tableLayoutPanelReportButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelReportButtons.Size = new Size(133, 40);
            tableLayoutPanelReportButtons.TabIndex = 20;
            // 
            // buttonReportApply
            // 
            buttonReportApply.AutoSize = true;
            buttonReportApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonReportApply.Location = new Point(5, 5);
            buttonReportApply.Margin = new Padding(5);
            buttonReportApply.Name = "buttonReportApply";
            buttonReportApply.Size = new Size(58, 30);
            buttonReportApply.TabIndex = 9;
            buttonReportApply.Text = "Apply";
            buttonReportApply.UseVisualStyleBackColor = true;
            buttonReportApply.Click += ReportApplyChanges;
            // 
            // buttonReportReset
            // 
            buttonReportReset.AutoSize = true;
            buttonReportReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonReportReset.Location = new Point(73, 5);
            buttonReportReset.Margin = new Padding(5);
            buttonReportReset.Name = "buttonReportReset";
            buttonReportReset.Size = new Size(55, 30);
            buttonReportReset.TabIndex = 10;
            buttonReportReset.Text = "Reset";
            buttonReportReset.UseVisualStyleBackColor = true;
            buttonReportReset.Click += ReportResetChanges;
            // 
            // tableLayoutPanelDatasource
            // 
            tableLayoutPanelDatasource.ColumnCount = 4;
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.Controls.Add(textBoxDatasourceText, 2, 4);
            tableLayoutPanelDatasource.Controls.Add(labelDatasourceProvider, 1, 1);
            tableLayoutPanelDatasource.Controls.Add(labelDatasourceConnectionString, 1, 2);
            tableLayoutPanelDatasource.Controls.Add(textBoxDatasourceConnectionString, 2, 2);
            tableLayoutPanelDatasource.Controls.Add(labelDatasourceType, 1, 3);
            tableLayoutPanelDatasource.Controls.Add(labelDatasourceText, 1, 4);
            tableLayoutPanelDatasource.Controls.Add(comboBoxDatasourceProvider, 2, 1);
            tableLayoutPanelDatasource.Controls.Add(comboBoxDatasourceType, 2, 3);
            tableLayoutPanelDatasource.Controls.Add(tableLayoutPanelButtons, 2, 5);
            tableLayoutPanelDatasource.Dock = DockStyle.Fill;
            tableLayoutPanelDatasource.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelDatasource.Location = new Point(0, 0);
            tableLayoutPanelDatasource.Name = "tableLayoutPanelDatasource";
            tableLayoutPanelDatasource.RowCount = 7;
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasource.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.Size = new Size(808, 661);
            tableLayoutPanelDatasource.TabIndex = 1;
            tableLayoutPanelDatasource.Visible = false;
            // 
            // textBoxDatasourceText
            // 
            textBoxDatasourceText.Dock = DockStyle.Fill;
            textBoxDatasourceText.Location = new Point(271, 283);
            textBoxDatasourceText.Multiline = true;
            textBoxDatasourceText.Name = "textBoxDatasourceText";
            textBoxDatasourceText.ScrollBars = ScrollBars.Vertical;
            textBoxDatasourceText.Size = new Size(400, 150);
            textBoxDatasourceText.TabIndex = 7;
            textBoxDatasourceText.Enter += TextBoxs_Enter;
            // 
            // labelDatasourceProvider
            // 
            labelDatasourceProvider.AutoSize = true;
            labelDatasourceProvider.Dock = DockStyle.Fill;
            labelDatasourceProvider.Location = new Point(137, 179);
            labelDatasourceProvider.Name = "labelDatasourceProvider";
            labelDatasourceProvider.Size = new Size(128, 34);
            labelDatasourceProvider.TabIndex = 0;
            labelDatasourceProvider.Text = "Provider:";
            labelDatasourceProvider.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDatasourceConnectionString
            // 
            labelDatasourceConnectionString.AutoSize = true;
            labelDatasourceConnectionString.Dock = DockStyle.Fill;
            labelDatasourceConnectionString.Location = new Point(137, 213);
            labelDatasourceConnectionString.Name = "labelDatasourceConnectionString";
            labelDatasourceConnectionString.Size = new Size(128, 33);
            labelDatasourceConnectionString.TabIndex = 2;
            labelDatasourceConnectionString.Text = "Connection string:";
            labelDatasourceConnectionString.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDatasourceConnectionString
            // 
            textBoxDatasourceConnectionString.Dock = DockStyle.Fill;
            textBoxDatasourceConnectionString.Location = new Point(271, 216);
            textBoxDatasourceConnectionString.MaxLength = 200;
            textBoxDatasourceConnectionString.Name = "textBoxDatasourceConnectionString";
            textBoxDatasourceConnectionString.Size = new Size(400, 27);
            textBoxDatasourceConnectionString.TabIndex = 3;
            textBoxDatasourceConnectionString.Enter += TextBoxs_Enter;
            // 
            // labelDatasourceType
            // 
            labelDatasourceType.AutoSize = true;
            labelDatasourceType.Dock = DockStyle.Fill;
            labelDatasourceType.Location = new Point(137, 246);
            labelDatasourceType.Name = "labelDatasourceType";
            labelDatasourceType.Size = new Size(128, 34);
            labelDatasourceType.TabIndex = 4;
            labelDatasourceType.Text = "Type:";
            labelDatasourceType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDatasourceText
            // 
            labelDatasourceText.AutoSize = true;
            labelDatasourceText.Dock = DockStyle.Fill;
            labelDatasourceText.Location = new Point(137, 280);
            labelDatasourceText.Name = "labelDatasourceText";
            labelDatasourceText.Size = new Size(128, 156);
            labelDatasourceText.TabIndex = 6;
            labelDatasourceText.Text = "Text:";
            labelDatasourceText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxDatasourceProvider
            // 
            comboBoxDatasourceProvider.Dock = DockStyle.Fill;
            comboBoxDatasourceProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDatasourceProvider.FormattingEnabled = true;
            comboBoxDatasourceProvider.Location = new Point(271, 182);
            comboBoxDatasourceProvider.Name = "comboBoxDatasourceProvider";
            comboBoxDatasourceProvider.Size = new Size(400, 28);
            comboBoxDatasourceProvider.TabIndex = 1;
            // 
            // comboBoxDatasourceType
            // 
            comboBoxDatasourceType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDatasourceType.FormattingEnabled = true;
            comboBoxDatasourceType.Location = new Point(271, 249);
            comboBoxDatasourceType.Name = "comboBoxDatasourceType";
            comboBoxDatasourceType.Size = new Size(250, 28);
            comboBoxDatasourceType.TabIndex = 5;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 4;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonDatasourceTest, 3, 0);
            tableLayoutPanelButtons.Controls.Add(buttonDatasourceGetFields, 2, 0);
            tableLayoutPanelButtons.Controls.Add(buttonDatasourceReset, 1, 0);
            tableLayoutPanelButtons.Controls.Add(buttonDatasourceApply, 0, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(271, 439);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButtons.Size = new Size(280, 40);
            tableLayoutPanelButtons.TabIndex = 9;
            // 
            // buttonDatasourceTest
            // 
            buttonDatasourceTest.AutoSize = true;
            buttonDatasourceTest.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceTest.Location = new Point(230, 5);
            buttonDatasourceTest.Margin = new Padding(5);
            buttonDatasourceTest.Name = "buttonDatasourceTest";
            buttonDatasourceTest.Size = new Size(45, 30);
            buttonDatasourceTest.TabIndex = 12;
            buttonDatasourceTest.Text = "Test";
            buttonDatasourceTest.UseVisualStyleBackColor = true;
            // 
            // buttonDatasourceGetFields
            // 
            buttonDatasourceGetFields.AutoSize = true;
            buttonDatasourceGetFields.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceGetFields.Location = new Point(138, 5);
            buttonDatasourceGetFields.Margin = new Padding(5);
            buttonDatasourceGetFields.Name = "buttonDatasourceGetFields";
            buttonDatasourceGetFields.Size = new Size(82, 30);
            buttonDatasourceGetFields.TabIndex = 11;
            buttonDatasourceGetFields.Text = "Get fields";
            buttonDatasourceGetFields.UseVisualStyleBackColor = true;
            // 
            // buttonDatasourceReset
            // 
            buttonDatasourceReset.AutoSize = true;
            buttonDatasourceReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceReset.Location = new Point(73, 5);
            buttonDatasourceReset.Margin = new Padding(5);
            buttonDatasourceReset.Name = "buttonDatasourceReset";
            buttonDatasourceReset.Size = new Size(55, 30);
            buttonDatasourceReset.TabIndex = 10;
            buttonDatasourceReset.Text = "Reset";
            buttonDatasourceReset.UseVisualStyleBackColor = true;
            buttonDatasourceReset.Click += DatasourceResetChanges;
            // 
            // buttonDatasourceApply
            // 
            buttonDatasourceApply.AutoSize = true;
            buttonDatasourceApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceApply.Location = new Point(5, 5);
            buttonDatasourceApply.Margin = new Padding(5);
            buttonDatasourceApply.Name = "buttonDatasourceApply";
            buttonDatasourceApply.Size = new Size(58, 30);
            buttonDatasourceApply.TabIndex = 9;
            buttonDatasourceApply.Text = "Apply";
            buttonDatasourceApply.UseVisualStyleBackColor = true;
            buttonDatasourceApply.Click += DatasourceApplyChanges;
            // 
            // imageListMain
            // 
            imageListMain.ColorDepth = ColorDepth.Depth32Bit;
            imageListMain.ImageStream = (ImageListStreamer)resources.GetObject("imageListMain.ImageStream");
            imageListMain.TransparentColor = Color.Transparent;
            imageListMain.Images.SetKeyName(0, "Report");
            imageListMain.Images.SetKeyName(1, "Datasource");
            imageListMain.Images.SetKeyName(2, "DatasourceParameter");
            imageListMain.Images.SetKeyName(3, "Fonts");
            imageListMain.Images.SetKeyName(4, "Font");
            imageListMain.Images.SetKeyName(5, "Brushes");
            imageListMain.Images.SetKeyName(6, "Brush");
            imageListMain.Images.SetKeyName(7, "Sections");
            imageListMain.Images.SetKeyName(8, "Section");
            imageListMain.Images.SetKeyName(9, "Rectangles");
            imageListMain.Images.SetKeyName(10, "Rectangle");
            imageListMain.Images.SetKeyName(11, "Lines");
            imageListMain.Images.SetKeyName(12, "Line");
            imageListMain.Images.SetKeyName(13, "Texts");
            imageListMain.Images.SetKeyName(14, "Text");
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 661);
            Controls.Add(splitContainerMain);
            Name = "FormReportEditor";
            Text = "Report editor";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanelReport.ResumeLayout(false);
            tableLayoutPanelReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportPageMarginBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReportDetailSectionMaxRowCount).EndInit();
            tableLayoutPanelReportButtons.ResumeLayout(false);
            tableLayoutPanelReportButtons.PerformLayout();
            tableLayoutPanelDatasource.ResumeLayout(false);
            tableLayoutPanelDatasource.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private TreeView treeViewReport;
        private ImageList imageListMain;
        private TableLayoutPanel tableLayoutPanelReport;
        private Label labelReportId;
        private TextBox textBoxReportId;
        private TextBox textBoxReportName;
        private Label labelReportName;
        private Label labelReportPageOrientation;
        private Label labelReportPageSize;
        private ComboBox comboBoxReportPageOrientation;
        private ComboBox comboBoxReportPageSize;
        private Label labelReportPageMarginBottom;
        private Label labelReportPageMarginRight;
        private Label labelReportPageMarginLeft;
        private Label labelReportPageMarginTop;
        private Label labelReportDetailSectionMaxRowCount;
        private Label labelReportTemplateFileName;
        private TextBox textBoxReportTemplateFileName;
        private NumericUpDown numericUpDownReportDetailSectionMaxRowCount;
        private ToolTip toolTipMain;
        private NumericUpDown numericUpDownReportPageMarginTop;
        private NumericUpDown numericUpDownReportPageMarginBottom;
        private NumericUpDown numericUpDownReportPageMarginRight;
        private NumericUpDown numericUpDownReportPageMarginLeft;
        private TableLayoutPanel tableLayoutPanelDatasource;
        private Label labelDatasourceProvider;
        private Label labelDatasourceConnectionString;
        private TextBox textBoxDatasourceConnectionString;
        private Label labelDatasourceType;
        private Label labelDatasourceText;
        private ComboBox comboBoxDatasourceProvider;
        private ComboBox comboBoxDatasourceType;
        private TextBox textBoxDatasourceText;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonDatasourceApply;
        private Button buttonDatasourceTest;
        private Button buttonDatasourceGetFields;
        private Button buttonDatasourceReset;
        private TableLayoutPanel tableLayoutPanelReportButtons;
        private Button buttonReportReset;
        private Button buttonReportApply;
    }
}