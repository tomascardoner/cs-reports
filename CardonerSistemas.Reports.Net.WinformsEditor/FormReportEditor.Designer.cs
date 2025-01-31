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
            labelReportId = new Label();
            textBoxReportId = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelPageSize = new Label();
            comboBoxPageSize = new ComboBox();
            labelPageOrientation = new Label();
            comboBoxPageOrientation = new ComboBox();
            ImageListMain = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)SplitContainerMain).BeginInit();
            SplitContainerMain.Panel1.SuspendLayout();
            SplitContainerMain.Panel2.SuspendLayout();
            SplitContainerMain.SuspendLayout();
            TableLayoutPanelReport.SuspendLayout();
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
            TableLayoutPanelReport.Controls.Add(labelPageSize, 1, 3);
            TableLayoutPanelReport.Controls.Add(comboBoxPageSize, 2, 3);
            TableLayoutPanelReport.Controls.Add(labelPageOrientation, 1, 4);
            TableLayoutPanelReport.Controls.Add(comboBoxPageOrientation, 2, 4);
            TableLayoutPanelReport.Dock = DockStyle.Fill;
            TableLayoutPanelReport.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TableLayoutPanelReport.Location = new Point(0, 0);
            TableLayoutPanelReport.Name = "TableLayoutPanelReport";
            TableLayoutPanelReport.RowCount = 7;
            TableLayoutPanelReport.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
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
            // labelReportId
            // 
            labelReportId.AutoSize = true;
            labelReportId.Dock = DockStyle.Fill;
            labelReportId.Location = new Point(140, 263);
            labelReportId.Name = "labelReportId";
            labelReportId.Size = new Size(121, 33);
            labelReportId.TabIndex = 0;
            labelReportId.Text = "Id:";
            labelReportId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxReportId
            // 
            textBoxReportId.Dock = DockStyle.Fill;
            textBoxReportId.Location = new Point(267, 266);
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
            labelName.Location = new Point(140, 296);
            labelName.Name = "labelName";
            labelName.Size = new Size(121, 33);
            labelName.TabIndex = 2;
            labelName.Text = "Name:";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(267, 299);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(400, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelPageSize
            // 
            labelPageSize.AutoSize = true;
            labelPageSize.Dock = DockStyle.Fill;
            labelPageSize.Location = new Point(140, 329);
            labelPageSize.Name = "labelPageSize";
            labelPageSize.Size = new Size(121, 34);
            labelPageSize.TabIndex = 4;
            labelPageSize.Text = "Page size:";
            labelPageSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageSize
            // 
            comboBoxPageSize.Dock = DockStyle.Fill;
            comboBoxPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageSize.FormattingEnabled = true;
            comboBoxPageSize.Location = new Point(267, 332);
            comboBoxPageSize.Name = "comboBoxPageSize";
            comboBoxPageSize.Size = new Size(400, 28);
            comboBoxPageSize.TabIndex = 6;
            // 
            // labelPageOrientation
            // 
            labelPageOrientation.AutoSize = true;
            labelPageOrientation.Dock = DockStyle.Fill;
            labelPageOrientation.Location = new Point(140, 363);
            labelPageOrientation.Name = "labelPageOrientation";
            labelPageOrientation.Size = new Size(121, 34);
            labelPageOrientation.TabIndex = 5;
            labelPageOrientation.Text = "Page orientation:";
            labelPageOrientation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPageOrientation
            // 
            comboBoxPageOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageOrientation.FormattingEnabled = true;
            comboBoxPageOrientation.Location = new Point(267, 366);
            comboBoxPageOrientation.Name = "comboBoxPageOrientation";
            comboBoxPageOrientation.Size = new Size(151, 28);
            comboBoxPageOrientation.TabIndex = 7;
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
    }
}