namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
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
            tableLayoutPanelMain = new TableLayoutPanel();
            labelProvider = new Label();
            comboBoxProvider = new ComboBox();
            labelConnectionString = new Label();
            tableLayoutPanelConnectionString = new TableLayoutPanel();
            textBoxConnectionString = new TextBox();
            checkBoxConnectionStringSave = new CheckBox();
            checkBoxConnectionStringSavePassword = new CheckBox();
            labelType = new Label();
            comboBoxType = new ComboBox();
            labelText = new Label();
            textBoxText = new TextBox();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonApply = new Button();
            buttonReset = new Button();
            buttonDelete = new Button();
            buttonGetFields = new Button();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelConnectionString.SuspendLayout();
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
            tableLayoutPanelMain.Controls.Add(labelProvider, 1, 1);
            tableLayoutPanelMain.Controls.Add(comboBoxProvider, 2, 1);
            tableLayoutPanelMain.Controls.Add(labelConnectionString, 1, 2);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelConnectionString, 2, 2);
            tableLayoutPanelMain.Controls.Add(labelType, 1, 3);
            tableLayoutPanelMain.Controls.Add(comboBoxType, 2, 3);
            tableLayoutPanelMain.Controls.Add(labelText, 1, 4);
            tableLayoutPanelMain.Controls.Add(textBoxText, 2, 4);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 5);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 7;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelProvider
            // 
            labelProvider.AutoSize = true;
            labelProvider.Dock = DockStyle.Fill;
            labelProvider.Location = new Point(78, 47);
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
            comboBoxProvider.Location = new Point(212, 50);
            comboBoxProvider.Name = "comboBoxProvider";
            comboBoxProvider.Size = new Size(410, 28);
            comboBoxProvider.TabIndex = 1;
            // 
            // labelConnectionString
            // 
            labelConnectionString.AutoSize = true;
            labelConnectionString.Dock = DockStyle.Fill;
            labelConnectionString.Location = new Point(78, 81);
            labelConnectionString.Name = "labelConnectionString";
            labelConnectionString.Size = new Size(128, 186);
            labelConnectionString.TabIndex = 2;
            labelConnectionString.Text = "Connection string:";
            labelConnectionString.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelConnectionString
            // 
            tableLayoutPanelConnectionString.AutoSize = true;
            tableLayoutPanelConnectionString.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelConnectionString.ColumnCount = 2;
            tableLayoutPanelConnectionString.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelConnectionString.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelConnectionString.Controls.Add(textBoxConnectionString, 0, 0);
            tableLayoutPanelConnectionString.Controls.Add(checkBoxConnectionStringSave, 0, 1);
            tableLayoutPanelConnectionString.Controls.Add(checkBoxConnectionStringSavePassword, 1, 1);
            tableLayoutPanelConnectionString.Dock = DockStyle.Fill;
            tableLayoutPanelConnectionString.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelConnectionString.Location = new Point(209, 81);
            tableLayoutPanelConnectionString.Margin = new Padding(0);
            tableLayoutPanelConnectionString.Name = "tableLayoutPanelConnectionString";
            tableLayoutPanelConnectionString.RowCount = 2;
            tableLayoutPanelConnectionString.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelConnectionString.RowStyles.Add(new RowStyle());
            tableLayoutPanelConnectionString.Size = new Size(416, 186);
            tableLayoutPanelConnectionString.TabIndex = 3;
            // 
            // textBoxConnectionString
            // 
            tableLayoutPanelConnectionString.SetColumnSpan(textBoxConnectionString, 2);
            textBoxConnectionString.Dock = DockStyle.Fill;
            textBoxConnectionString.Location = new Point(3, 3);
            textBoxConnectionString.MaxLength = 500;
            textBoxConnectionString.Multiline = true;
            textBoxConnectionString.Name = "textBoxConnectionString";
            textBoxConnectionString.ScrollBars = ScrollBars.Vertical;
            textBoxConnectionString.Size = new Size(410, 150);
            textBoxConnectionString.TabIndex = 0;
            textBoxConnectionString.Enter += ControlFocusEnter;
            // 
            // checkBoxConnectionStringSave
            // 
            checkBoxConnectionStringSave.AutoSize = true;
            checkBoxConnectionStringSave.Checked = true;
            checkBoxConnectionStringSave.CheckState = CheckState.Checked;
            checkBoxConnectionStringSave.Location = new Point(3, 159);
            checkBoxConnectionStringSave.Name = "checkBoxConnectionStringSave";
            checkBoxConnectionStringSave.Size = new Size(62, 24);
            checkBoxConnectionStringSave.TabIndex = 1;
            checkBoxConnectionStringSave.Text = "Save";
            checkBoxConnectionStringSave.UseVisualStyleBackColor = true;
            checkBoxConnectionStringSave.CheckedChanged += SavePasswordChanged;
            // 
            // checkBoxConnectionStringSavePassword
            // 
            checkBoxConnectionStringSavePassword.AutoSize = true;
            checkBoxConnectionStringSavePassword.Location = new Point(71, 159);
            checkBoxConnectionStringSavePassword.Name = "checkBoxConnectionStringSavePassword";
            checkBoxConnectionStringSavePassword.Size = new Size(129, 24);
            checkBoxConnectionStringSavePassword.TabIndex = 2;
            checkBoxConnectionStringSavePassword.Text = "Save password";
            checkBoxConnectionStringSavePassword.UseVisualStyleBackColor = true;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Dock = DockStyle.Fill;
            labelType.Location = new Point(78, 267);
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
            comboBoxType.Location = new Point(212, 270);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(250, 28);
            comboBoxType.TabIndex = 5;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Dock = DockStyle.Fill;
            labelText.Location = new Point(78, 301);
            labelText.Name = "labelText";
            labelText.Size = new Size(128, 106);
            labelText.TabIndex = 6;
            labelText.Text = "Text:";
            labelText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxText
            // 
            textBoxText.Dock = DockStyle.Fill;
            textBoxText.Location = new Point(212, 304);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.ScrollBars = ScrollBars.Vertical;
            textBoxText.Size = new Size(410, 100);
            textBoxText.TabIndex = 7;
            textBoxText.Enter += ControlFocusEnter;
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
            tableLayoutPanelButtons.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanelButtons.Controls.Add(buttonGetFields, 3, 0);
            tableLayoutPanelButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelButtons.Location = new Point(212, 410);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(298, 40);
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
            // buttonGetFields
            // 
            buttonGetFields.AutoSize = true;
            buttonGetFields.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonGetFields.Location = new Point(211, 5);
            buttonGetFields.Margin = new Padding(5);
            buttonGetFields.Name = "buttonGetFields";
            buttonGetFields.Size = new Size(82, 30);
            buttonGetFields.TabIndex = 3;
            buttonGetFields.Text = "Get fields";
            buttonGetFields.UseVisualStyleBackColor = true;
            buttonGetFields.Click += GetFields;
            // 
            // PanelDatasource
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelDatasource";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tableLayoutPanelConnectionString.ResumeLayout(false);
            tableLayoutPanelConnectionString.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private TextBox textBoxText;
        private Label labelProvider;
        private Label labelConnectionString;
        private Label labelType;
        private Label labelText;
        private ComboBox comboBoxProvider;
        private ComboBox comboBoxType;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonDelete;
        private Button buttonGetFields;
        private Button buttonReset;
        private Button buttonApply;
        private TableLayoutPanel tableLayoutPanelConnectionString;
        private TextBox textBoxConnectionString;
        private CheckBox checkBoxConnectionStringSave;
        private CheckBox checkBoxConnectionStringSavePassword;
    }
}
