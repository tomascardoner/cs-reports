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
            tableLayoutPanelDatasourceParameter = new TableLayoutPanel();
            labelDatasourceParameterName = new Label();
            textBoxDatasourceParameterName = new TextBox();
            labelDatasourceParameterType = new Label();
            comboBoxDatasourceParameterType = new ComboBox();
            labelDatasourceParameterValueNull = new Label();
            checkBoxDatasourceParameterValueNull = new CheckBox();
            labelDatasourceParameterValueText = new Label();
            textBoxDatasourceParameterValueText = new TextBox();
            labelDatasourceParameterValueNumeric = new Label();
            numericUpDownDatasourceParameterValueNumeric = new NumericUpDown();
            labelDatasourceParameterValueDateTime = new Label();
            dateTimePickerDatasourceParameterValueDateTime = new DateTimePicker();
            labelDatasourceParameterValueYesNo = new Label();
            checkBoxDatasourceParameterValueYesNo = new CheckBox();
            tableLayoutPanelDatasourceParameterButtons = new TableLayoutPanel();
            buttonDatasourceParameterApply = new Button();
            buttonDatasourceParameterReset = new Button();
            imageListMain = new ImageList(components);
            toolTipMain = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanelDatasourceParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDatasourceParameterValueNumeric).BeginInit();
            tableLayoutPanelDatasourceParameterButtons.SuspendLayout();
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
            splitContainerMain.Panel2.Controls.Add(tableLayoutPanelDatasourceParameter);
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
            // tableLayoutPanelDatasourceParameter
            // 
            tableLayoutPanelDatasourceParameter.ColumnCount = 4;
            tableLayoutPanelDatasourceParameter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasourceParameter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasourceParameter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasourceParameter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterName, 1, 1);
            tableLayoutPanelDatasourceParameter.Controls.Add(textBoxDatasourceParameterName, 2, 1);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterType, 1, 2);
            tableLayoutPanelDatasourceParameter.Controls.Add(comboBoxDatasourceParameterType, 2, 2);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterValueNull, 1, 3);
            tableLayoutPanelDatasourceParameter.Controls.Add(checkBoxDatasourceParameterValueNull, 2, 3);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterValueText, 1, 4);
            tableLayoutPanelDatasourceParameter.Controls.Add(textBoxDatasourceParameterValueText, 2, 4);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterValueNumeric, 1, 5);
            tableLayoutPanelDatasourceParameter.Controls.Add(numericUpDownDatasourceParameterValueNumeric, 2, 5);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterValueDateTime, 1, 6);
            tableLayoutPanelDatasourceParameter.Controls.Add(dateTimePickerDatasourceParameterValueDateTime, 2, 6);
            tableLayoutPanelDatasourceParameter.Controls.Add(labelDatasourceParameterValueYesNo, 1, 7);
            tableLayoutPanelDatasourceParameter.Controls.Add(checkBoxDatasourceParameterValueYesNo, 2, 7);
            tableLayoutPanelDatasourceParameter.Controls.Add(tableLayoutPanelDatasourceParameterButtons, 2, 8);
            tableLayoutPanelDatasourceParameter.Dock = DockStyle.Fill;
            tableLayoutPanelDatasourceParameter.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelDatasourceParameter.Location = new Point(0, 0);
            tableLayoutPanelDatasourceParameter.Name = "tableLayoutPanelDatasourceParameter";
            tableLayoutPanelDatasourceParameter.RowCount = 10;
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasourceParameter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelDatasourceParameter.Size = new Size(808, 661);
            tableLayoutPanelDatasourceParameter.TabIndex = 3;
            tableLayoutPanelDatasourceParameter.Visible = false;
            // 
            // labelDatasourceParameterName
            // 
            labelDatasourceParameterName.AutoSize = true;
            labelDatasourceParameterName.Dock = DockStyle.Fill;
            labelDatasourceParameterName.Location = new Point(162, 185);
            labelDatasourceParameterName.Name = "labelDatasourceParameterName";
            labelDatasourceParameterName.Size = new Size(78, 33);
            labelDatasourceParameterName.TabIndex = 0;
            labelDatasourceParameterName.Text = "Name:";
            labelDatasourceParameterName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDatasourceParameterName
            // 
            textBoxDatasourceParameterName.Dock = DockStyle.Fill;
            textBoxDatasourceParameterName.Location = new Point(246, 188);
            textBoxDatasourceParameterName.MaxLength = 128;
            textBoxDatasourceParameterName.Name = "textBoxDatasourceParameterName";
            textBoxDatasourceParameterName.Size = new Size(400, 27);
            textBoxDatasourceParameterName.TabIndex = 1;
            // 
            // labelDatasourceParameterType
            // 
            labelDatasourceParameterType.AutoSize = true;
            labelDatasourceParameterType.Dock = DockStyle.Fill;
            labelDatasourceParameterType.Location = new Point(162, 218);
            labelDatasourceParameterType.Name = "labelDatasourceParameterType";
            labelDatasourceParameterType.Size = new Size(78, 34);
            labelDatasourceParameterType.TabIndex = 2;
            labelDatasourceParameterType.Text = "Type:";
            labelDatasourceParameterType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxDatasourceParameterType
            // 
            comboBoxDatasourceParameterType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDatasourceParameterType.FormattingEnabled = true;
            comboBoxDatasourceParameterType.Location = new Point(246, 221);
            comboBoxDatasourceParameterType.Name = "comboBoxDatasourceParameterType";
            comboBoxDatasourceParameterType.Size = new Size(250, 28);
            comboBoxDatasourceParameterType.TabIndex = 3;
            // 
            // labelDatasourceParameterValueNull
            // 
            labelDatasourceParameterValueNull.AutoSize = true;
            labelDatasourceParameterValueNull.Dock = DockStyle.Fill;
            labelDatasourceParameterValueNull.Location = new Point(162, 252);
            labelDatasourceParameterValueNull.Name = "labelDatasourceParameterValueNull";
            labelDatasourceParameterValueNull.Size = new Size(78, 23);
            labelDatasourceParameterValueNull.TabIndex = 4;
            labelDatasourceParameterValueNull.Text = "Null value:";
            labelDatasourceParameterValueNull.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxDatasourceParameterValueNull
            // 
            checkBoxDatasourceParameterValueNull.AutoSize = true;
            checkBoxDatasourceParameterValueNull.Location = new Point(246, 255);
            checkBoxDatasourceParameterValueNull.Name = "checkBoxDatasourceParameterValueNull";
            checkBoxDatasourceParameterValueNull.Size = new Size(18, 17);
            checkBoxDatasourceParameterValueNull.TabIndex = 5;
            checkBoxDatasourceParameterValueNull.UseVisualStyleBackColor = true;
            // 
            // labelDatasourceParameterValueText
            // 
            labelDatasourceParameterValueText.AutoSize = true;
            labelDatasourceParameterValueText.Dock = DockStyle.Fill;
            labelDatasourceParameterValueText.Location = new Point(162, 275);
            labelDatasourceParameterValueText.Name = "labelDatasourceParameterValueText";
            labelDatasourceParameterValueText.Size = new Size(78, 66);
            labelDatasourceParameterValueText.TabIndex = 6;
            labelDatasourceParameterValueText.Text = "Value:";
            labelDatasourceParameterValueText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDatasourceParameterValueText
            // 
            textBoxDatasourceParameterValueText.Dock = DockStyle.Fill;
            textBoxDatasourceParameterValueText.Location = new Point(246, 278);
            textBoxDatasourceParameterValueText.Multiline = true;
            textBoxDatasourceParameterValueText.Name = "textBoxDatasourceParameterValueText";
            textBoxDatasourceParameterValueText.ScrollBars = ScrollBars.Vertical;
            textBoxDatasourceParameterValueText.Size = new Size(400, 60);
            textBoxDatasourceParameterValueText.TabIndex = 7;
            // 
            // labelDatasourceParameterValueNumeric
            // 
            labelDatasourceParameterValueNumeric.AutoSize = true;
            labelDatasourceParameterValueNumeric.Dock = DockStyle.Fill;
            labelDatasourceParameterValueNumeric.Location = new Point(162, 341);
            labelDatasourceParameterValueNumeric.Name = "labelDatasourceParameterValueNumeric";
            labelDatasourceParameterValueNumeric.Size = new Size(78, 33);
            labelDatasourceParameterValueNumeric.TabIndex = 8;
            labelDatasourceParameterValueNumeric.Text = "Value:";
            labelDatasourceParameterValueNumeric.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDatasourceParameterValueNumeric
            // 
            numericUpDownDatasourceParameterValueNumeric.Location = new Point(246, 344);
            numericUpDownDatasourceParameterValueNumeric.Name = "numericUpDownDatasourceParameterValueNumeric";
            numericUpDownDatasourceParameterValueNumeric.Size = new Size(150, 27);
            numericUpDownDatasourceParameterValueNumeric.TabIndex = 9;
            numericUpDownDatasourceParameterValueNumeric.TextAlign = HorizontalAlignment.Right;
            numericUpDownDatasourceParameterValueNumeric.ThousandsSeparator = true;
            // 
            // labelDatasourceParameterValueDateTime
            // 
            labelDatasourceParameterValueDateTime.AutoSize = true;
            labelDatasourceParameterValueDateTime.Dock = DockStyle.Fill;
            labelDatasourceParameterValueDateTime.Location = new Point(162, 374);
            labelDatasourceParameterValueDateTime.Name = "labelDatasourceParameterValueDateTime";
            labelDatasourceParameterValueDateTime.Size = new Size(78, 33);
            labelDatasourceParameterValueDateTime.TabIndex = 10;
            labelDatasourceParameterValueDateTime.Text = "Value:";
            labelDatasourceParameterValueDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerDatasourceParameterValueDateTime
            // 
            dateTimePickerDatasourceParameterValueDateTime.Format = DateTimePickerFormat.Short;
            dateTimePickerDatasourceParameterValueDateTime.Location = new Point(246, 377);
            dateTimePickerDatasourceParameterValueDateTime.Name = "dateTimePickerDatasourceParameterValueDateTime";
            dateTimePickerDatasourceParameterValueDateTime.Size = new Size(189, 27);
            dateTimePickerDatasourceParameterValueDateTime.TabIndex = 11;
            // 
            // labelDatasourceParameterValueYesNo
            // 
            labelDatasourceParameterValueYesNo.AutoSize = true;
            labelDatasourceParameterValueYesNo.Dock = DockStyle.Fill;
            labelDatasourceParameterValueYesNo.Location = new Point(162, 407);
            labelDatasourceParameterValueYesNo.Name = "labelDatasourceParameterValueYesNo";
            labelDatasourceParameterValueYesNo.Size = new Size(78, 23);
            labelDatasourceParameterValueYesNo.TabIndex = 12;
            labelDatasourceParameterValueYesNo.Text = "Value:";
            labelDatasourceParameterValueYesNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxDatasourceParameterValueYesNo
            // 
            checkBoxDatasourceParameterValueYesNo.AutoSize = true;
            checkBoxDatasourceParameterValueYesNo.Location = new Point(246, 410);
            checkBoxDatasourceParameterValueYesNo.Name = "checkBoxDatasourceParameterValueYesNo";
            checkBoxDatasourceParameterValueYesNo.Size = new Size(18, 17);
            checkBoxDatasourceParameterValueYesNo.TabIndex = 13;
            checkBoxDatasourceParameterValueYesNo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDatasourceParameterButtons
            // 
            tableLayoutPanelDatasourceParameterButtons.AutoSize = true;
            tableLayoutPanelDatasourceParameterButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelDatasourceParameterButtons.ColumnCount = 2;
            tableLayoutPanelDatasourceParameterButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasourceParameterButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasourceParameterButtons.Controls.Add(buttonDatasourceParameterApply, 0, 0);
            tableLayoutPanelDatasourceParameterButtons.Controls.Add(buttonDatasourceParameterReset, 1, 0);
            tableLayoutPanelDatasourceParameterButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelDatasourceParameterButtons.Location = new Point(246, 433);
            tableLayoutPanelDatasourceParameterButtons.Name = "tableLayoutPanelDatasourceParameterButtons";
            tableLayoutPanelDatasourceParameterButtons.RowCount = 1;
            tableLayoutPanelDatasourceParameterButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelDatasourceParameterButtons.Size = new Size(133, 40);
            tableLayoutPanelDatasourceParameterButtons.TabIndex = 14;
            // 
            // buttonDatasourceParameterApply
            // 
            buttonDatasourceParameterApply.AutoSize = true;
            buttonDatasourceParameterApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceParameterApply.Location = new Point(5, 5);
            buttonDatasourceParameterApply.Margin = new Padding(5);
            buttonDatasourceParameterApply.Name = "buttonDatasourceParameterApply";
            buttonDatasourceParameterApply.Size = new Size(58, 30);
            buttonDatasourceParameterApply.TabIndex = 0;
            buttonDatasourceParameterApply.Text = "Apply";
            buttonDatasourceParameterApply.UseVisualStyleBackColor = true;
            // 
            // buttonDatasourceParameterReset
            // 
            buttonDatasourceParameterReset.AutoSize = true;
            buttonDatasourceParameterReset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDatasourceParameterReset.Location = new Point(73, 5);
            buttonDatasourceParameterReset.Margin = new Padding(5);
            buttonDatasourceParameterReset.Name = "buttonDatasourceParameterReset";
            buttonDatasourceParameterReset.Size = new Size(55, 30);
            buttonDatasourceParameterReset.TabIndex = 1;
            buttonDatasourceParameterReset.Text = "Reset";
            buttonDatasourceParameterReset.UseVisualStyleBackColor = true;
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
            FormClosing += FormReportEditor_FormClosing;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanelDatasourceParameter.ResumeLayout(false);
            tableLayoutPanelDatasourceParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDatasourceParameterValueNumeric).EndInit();
            tableLayoutPanelDatasourceParameterButtons.ResumeLayout(false);
            tableLayoutPanelDatasourceParameterButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private TreeView treeViewReport;
        private ImageList imageListMain;
        private ToolTip toolTipMain;
        private TableLayoutPanel tableLayoutPanelDatasourceParameters;
        private TextBox textBox1;
        private Label labelDatasourceParametersCount;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TableLayoutPanel tableLayoutPanelDatasourceParameter;
        private TextBox textBoxDatasourceParameterValueText;
        private Label labelDatasourceParameterName;
        private Label label6;
        private TextBox textBoxDatasourceParameterName;
        private Label labelDatasourceParameterType;
        private Label labelDatasourceParameterValueText;
        private ComboBox comboBoxDatasourceParameterType;
        private TableLayoutPanel tableLayoutPanelDatasourceParameterButtons;
        private Button buttonDatasourceParameterReset;
        private Button buttonDatasourceParameterApply;
        private Label labelDatasourceParameterValueNull;
        private Label labelDatasourceParameterValueNumeric;
        private Label labelDatasourceParameterValueDateTime;
        private NumericUpDown numericUpDownDatasourceParameterValueNumeric;
        private CheckBox checkBoxDatasourceParameterValueNull;
        private DateTimePicker dateTimePickerDatasourceParameterValueDateTime;
        private CheckBox checkBoxDatasourceParameterValueYesNo;
        private Label labelDatasourceParameterValueYesNo;
    }
}