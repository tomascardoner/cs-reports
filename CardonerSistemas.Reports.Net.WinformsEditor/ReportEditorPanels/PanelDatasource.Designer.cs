namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    partial class PanelDatasource
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
            tableLayoutPanelDatasource = new TableLayoutPanel();
            labelProvider = new Label();
            comboBoxProvider = new ComboBox();
            labelConnectionString = new Label();
            textBoxConnectionString = new TextBox();
            labelType = new Label();
            comboBoxType = new ComboBox();
            labelText = new Label();
            textBoxText = new TextBox();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            buttonAddParameter = new Button();
            buttonGetFields = new Button();
            buttonTest = new Button();
            tableLayoutPanelDatasource.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelDatasource
            // 
            tableLayoutPanelDatasource.ColumnCount = 4;
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelDatasource.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDatasource.Controls.Add(labelProvider, 1, 1);
            tableLayoutPanelDatasource.Controls.Add(comboBoxProvider, 2, 1);
            tableLayoutPanelDatasource.Controls.Add(labelConnectionString, 1, 2);
            tableLayoutPanelDatasource.Controls.Add(textBoxConnectionString, 2, 2);
            tableLayoutPanelDatasource.Controls.Add(labelType, 1, 3);
            tableLayoutPanelDatasource.Controls.Add(comboBoxType, 2, 3);
            tableLayoutPanelDatasource.Controls.Add(labelText, 1, 4);
            tableLayoutPanelDatasource.Controls.Add(textBoxText, 2, 4);
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
            tableLayoutPanelDatasource.Size = new Size(700, 500);
            tableLayoutPanelDatasource.TabIndex = 0;
            tableLayoutPanelDatasource.Visible = false;
            // 
            // labelProvider
            // 
            labelProvider.AutoSize = true;
            labelProvider.Dock = DockStyle.Fill;
            labelProvider.Location = new Point(78, 62);
            labelProvider.Name = "labelProvider";
            labelProvider.Size = new Size(128, 34);
            labelProvider.TabIndex = 0;
            labelProvider.Text = "Provider:";
            labelProvider.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxProvider
            // 
            comboBoxProvider.Dock = DockStyle.Fill;
            comboBoxProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvider.FormattingEnabled = true;
            comboBoxProvider.Location = new Point(212, 65);
            comboBoxProvider.Name = "comboBoxProvider";
            comboBoxProvider.Size = new Size(410, 28);
            comboBoxProvider.TabIndex = 1;
            // 
            // labelConnectionString
            // 
            labelConnectionString.AutoSize = true;
            labelConnectionString.Dock = DockStyle.Fill;
            labelConnectionString.Location = new Point(78, 96);
            labelConnectionString.Name = "labelConnectionString";
            labelConnectionString.Size = new Size(128, 106);
            labelConnectionString.TabIndex = 2;
            labelConnectionString.Text = "Connection string:";
            labelConnectionString.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxConnectionString
            // 
            textBoxConnectionString.Dock = DockStyle.Fill;
            textBoxConnectionString.Location = new Point(212, 99);
            textBoxConnectionString.MaxLength = 500;
            textBoxConnectionString.Multiline = true;
            textBoxConnectionString.Name = "textBoxConnectionString";
            textBoxConnectionString.ScrollBars = ScrollBars.Vertical;
            textBoxConnectionString.Size = new Size(410, 100);
            textBoxConnectionString.TabIndex = 3;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Dock = DockStyle.Fill;
            labelType.Location = new Point(78, 202);
            labelType.Name = "labelType";
            labelType.Size = new Size(128, 34);
            labelType.TabIndex = 4;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(212, 205);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(250, 28);
            comboBoxType.TabIndex = 5;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Dock = DockStyle.Fill;
            labelText.Location = new Point(78, 236);
            labelText.Name = "labelText";
            labelText.Size = new Size(128, 156);
            labelText.TabIndex = 6;
            labelText.Text = "Text:";
            labelText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxText
            // 
            textBoxText.Dock = DockStyle.Fill;
            textBoxText.Location = new Point(212, 239);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.ScrollBars = ScrollBars.Vertical;
            textBoxText.Size = new Size(410, 150);
            textBoxText.TabIndex = 7;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 5;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonApply, 0, 0);
            tableLayoutPanelButtons.Controls.Add(buttonReset, 1, 0);
            tableLayoutPanelButtons.Controls.Add(buttonAddParameter, 2, 0);
            tableLayoutPanelButtons.Controls.Add(buttonGetFields, 3, 0);
            tableLayoutPanelButtons.Controls.Add(buttonTest, 4, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(212, 395);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(410, 40);
            tableLayoutPanelButtons.TabIndex = 8;
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
            // 
            // buttonAddParameter
            // 
            buttonAddParameter.AutoSize = true;
            buttonAddParameter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddParameter.Location = new Point(138, 5);
            buttonAddParameter.Margin = new Padding(5);
            buttonAddParameter.Name = "buttonAddParameter";
            buttonAddParameter.Size = new Size(120, 30);
            buttonAddParameter.TabIndex = 2;
            buttonAddParameter.Text = "Add parameter";
            buttonAddParameter.UseVisualStyleBackColor = true;
            // 
            // buttonGetFields
            // 
            buttonGetFields.AutoSize = true;
            buttonGetFields.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonGetFields.Location = new Point(268, 5);
            buttonGetFields.Margin = new Padding(5);
            buttonGetFields.Name = "buttonGetFields";
            buttonGetFields.Size = new Size(82, 30);
            buttonGetFields.TabIndex = 3;
            buttonGetFields.Text = "Get fields";
            buttonGetFields.UseVisualStyleBackColor = true;
            buttonGetFields.Click += ButtonGetFields_Click;
            // 
            // buttonTest
            // 
            buttonTest.AutoSize = true;
            buttonTest.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonTest.Location = new Point(360, 5);
            buttonTest.Margin = new Padding(5);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(45, 30);
            buttonTest.TabIndex = 4;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            // 
            // PanelDatasource
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelDatasource);
            Name = "PanelDatasource";
            Size = new Size(700, 500);
            tableLayoutPanelDatasource.ResumeLayout(false);
            tableLayoutPanelDatasource.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelDatasource;
        private TextBox textBoxText;
        private Label labelProvider;
        private Label labelConnectionString;
        private TextBox textBoxConnectionString;
        private Label labelType;
        private Label labelText;
        private ComboBox comboBoxProvider;
        private ComboBox comboBoxType;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonAddParameter;
        private Button buttonTest;
        private Button buttonGetFields;
        private Button buttonReset;
        private Button buttonApply;
    }
}
