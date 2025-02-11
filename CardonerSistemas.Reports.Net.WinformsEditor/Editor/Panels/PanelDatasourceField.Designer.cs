namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    partial class PanelDatasourceField
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
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonDelete = new Button();
            buttonApply = new Button();
            buttonReset = new Button();
            tableLayoutPanelMain.SuspendLayout();
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
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 3);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 5;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(121, 193);
            labelName.Name = "labelName";
            labelName.Size = new Size(52, 33);
            labelName.TabIndex = 0;
            labelName.Text = "Name:";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(179, 196);
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
            labelType.Location = new Point(121, 226);
            labelType.Name = "labelType";
            labelType.Size = new Size(52, 34);
            labelType.TabIndex = 2;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(179, 229);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(250, 28);
            comboBoxType.TabIndex = 3;
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
            tableLayoutPanelButtons.Location = new Point(179, 263);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(240, 40);
            tableLayoutPanelButtons.TabIndex = 4;
            // 
            // buttonDelete
            // 
            buttonDelete.AutoSize = true;
            buttonDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDelete.Location = new Point(138, 5);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(97, 30);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete field";
            buttonDelete.UseVisualStyleBackColor = true;
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
            // PanelDatasourceField
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelDatasourceField";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonApply;
        private Button buttonReset;
        private Button buttonDelete;
    }
}
