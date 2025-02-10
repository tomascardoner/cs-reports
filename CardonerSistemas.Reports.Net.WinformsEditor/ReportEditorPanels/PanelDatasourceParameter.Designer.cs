namespace CardonerSistemas.Reports.Net.WinformsEditor.ReportEditorPanels
{
    partial class PanelDatasourceParameter
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
            labelName = new Label();
            textBoxName = new TextBox();
            labelType = new Label();
            comboBoxType = new ComboBox();
            labelValueNull = new Label();
            checkBoxValueNull = new CheckBox();
            labelValueText = new Label();
            textBoxValueText = new TextBox();
            labelValueNumeric = new Label();
            numericUpDownValueNumeric = new NumericUpDown();
            labelValueDateTime = new Label();
            dateTimePickerValueDateTime = new DateTimePicker();
            labelValueYesNo = new Label();
            checkBoxValueYesNo = new CheckBox();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            buttonDelete = new Button();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownValueNumeric).BeginInit();
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
            tableLayoutPanelMain.Controls.Add(labelName, 1, 1);
            tableLayoutPanelMain.Controls.Add(textBoxName, 2, 1);
            tableLayoutPanelMain.Controls.Add(labelType, 1, 2);
            tableLayoutPanelMain.Controls.Add(comboBoxType, 2, 2);
            tableLayoutPanelMain.Controls.Add(labelValueNull, 1, 3);
            tableLayoutPanelMain.Controls.Add(checkBoxValueNull, 2, 3);
            tableLayoutPanelMain.Controls.Add(labelValueText, 1, 4);
            tableLayoutPanelMain.Controls.Add(textBoxValueText, 2, 4);
            tableLayoutPanelMain.Controls.Add(labelValueNumeric, 1, 5);
            tableLayoutPanelMain.Controls.Add(numericUpDownValueNumeric, 2, 5);
            tableLayoutPanelMain.Controls.Add(labelValueDateTime, 1, 6);
            tableLayoutPanelMain.Controls.Add(dateTimePickerValueDateTime, 2, 6);
            tableLayoutPanelMain.Controls.Add(labelValueYesNo, 1, 7);
            tableLayoutPanelMain.Controls.Add(checkBoxValueYesNo, 2, 7);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 8);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 10;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(108, 104);
            labelName.Name = "labelName";
            labelName.Size = new Size(78, 33);
            labelName.TabIndex = 0;
            labelName.Text = "Name:";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(192, 107);
            textBoxName.MaxLength = 128;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(400, 27);
            textBoxName.TabIndex = 1;
            textBoxName.Enter += ControlFocusEnter;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Dock = DockStyle.Fill;
            labelType.Location = new Point(108, 137);
            labelType.Name = "labelType";
            labelType.Size = new Size(78, 34);
            labelType.TabIndex = 2;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(192, 140);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(250, 28);
            comboBoxType.TabIndex = 3;
            comboBoxType.SelectedIndexChanged += TypeChanged;
            // 
            // labelValueNull
            // 
            labelValueNull.AutoSize = true;
            labelValueNull.Dock = DockStyle.Fill;
            labelValueNull.Location = new Point(108, 171);
            labelValueNull.Name = "labelValueNull";
            labelValueNull.Size = new Size(78, 23);
            labelValueNull.TabIndex = 4;
            labelValueNull.Text = "Null value:";
            labelValueNull.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxValueNull
            // 
            checkBoxValueNull.AutoSize = true;
            checkBoxValueNull.Location = new Point(192, 174);
            checkBoxValueNull.Name = "checkBoxValueNull";
            checkBoxValueNull.Size = new Size(18, 17);
            checkBoxValueNull.TabIndex = 5;
            checkBoxValueNull.UseVisualStyleBackColor = true;
            checkBoxValueNull.CheckedChanged += ValueNullChanged;
            // 
            // labelValueText
            // 
            labelValueText.AutoSize = true;
            labelValueText.Dock = DockStyle.Fill;
            labelValueText.Location = new Point(108, 194);
            labelValueText.Name = "labelValueText";
            labelValueText.Size = new Size(78, 66);
            labelValueText.TabIndex = 6;
            labelValueText.Text = "Value:";
            labelValueText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxValueText
            // 
            textBoxValueText.Dock = DockStyle.Fill;
            textBoxValueText.Location = new Point(192, 197);
            textBoxValueText.Multiline = true;
            textBoxValueText.Name = "textBoxValueText";
            textBoxValueText.ScrollBars = ScrollBars.Vertical;
            textBoxValueText.Size = new Size(400, 60);
            textBoxValueText.TabIndex = 7;
            textBoxValueText.Enter += ControlFocusEnter;
            // 
            // labelValueNumeric
            // 
            labelValueNumeric.AutoSize = true;
            labelValueNumeric.Dock = DockStyle.Fill;
            labelValueNumeric.Location = new Point(108, 260);
            labelValueNumeric.Name = "labelValueNumeric";
            labelValueNumeric.Size = new Size(78, 33);
            labelValueNumeric.TabIndex = 8;
            labelValueNumeric.Text = "Value:";
            labelValueNumeric.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownValueNumeric
            // 
            numericUpDownValueNumeric.Location = new Point(192, 263);
            numericUpDownValueNumeric.Name = "numericUpDownValueNumeric";
            numericUpDownValueNumeric.Size = new Size(150, 27);
            numericUpDownValueNumeric.TabIndex = 9;
            numericUpDownValueNumeric.TextAlign = HorizontalAlignment.Right;
            numericUpDownValueNumeric.ThousandsSeparator = true;
            numericUpDownValueNumeric.Enter += ControlFocusEnter;
            // 
            // labelValueDateTime
            // 
            labelValueDateTime.AutoSize = true;
            labelValueDateTime.Dock = DockStyle.Fill;
            labelValueDateTime.Location = new Point(108, 293);
            labelValueDateTime.Name = "labelValueDateTime";
            labelValueDateTime.Size = new Size(78, 33);
            labelValueDateTime.TabIndex = 10;
            labelValueDateTime.Text = "Value:";
            labelValueDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerValueDateTime
            // 
            dateTimePickerValueDateTime.Format = DateTimePickerFormat.Short;
            dateTimePickerValueDateTime.Location = new Point(192, 296);
            dateTimePickerValueDateTime.Name = "dateTimePickerValueDateTime";
            dateTimePickerValueDateTime.Size = new Size(189, 27);
            dateTimePickerValueDateTime.TabIndex = 11;
            // 
            // labelValueYesNo
            // 
            labelValueYesNo.AutoSize = true;
            labelValueYesNo.Dock = DockStyle.Fill;
            labelValueYesNo.Location = new Point(108, 326);
            labelValueYesNo.Name = "labelValueYesNo";
            labelValueYesNo.Size = new Size(78, 23);
            labelValueYesNo.TabIndex = 12;
            labelValueYesNo.Text = "Value:";
            labelValueYesNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxValueYesNo
            // 
            checkBoxValueYesNo.AutoSize = true;
            checkBoxValueYesNo.Location = new Point(192, 329);
            checkBoxValueYesNo.Name = "checkBoxValueYesNo";
            checkBoxValueYesNo.Size = new Size(18, 17);
            checkBoxValueYesNo.TabIndex = 13;
            checkBoxValueYesNo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelButtons.ColumnCount = 3;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButtons.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanelButtons.Controls.Add(buttonApply, 0, 0);
            tableLayoutPanelButtons.Controls.Add(buttonReset, 1, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(192, 352);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(279, 40);
            tableLayoutPanelButtons.TabIndex = 14;
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
            buttonDelete.Size = new Size(136, 30);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete parameter";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // PanelDatasourceParameter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelDatasourceParameter";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownValueNumeric).EndInit();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelType;
        private ComboBox comboBoxType;
        private Label labelValueNull;
        private CheckBox checkBoxValueNull;
        private Label labelValueText;
        private TextBox textBoxValueText;
        private Label labelValueNumeric;
        private NumericUpDown numericUpDownValueNumeric;
        private Label labelValueDateTime;
        private DateTimePicker dateTimePickerValueDateTime;
        private Label labelValueYesNo;
        private CheckBox checkBoxValueYesNo;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonApply;
        private Button buttonReset;
        private Button buttonDelete;
    }
}
