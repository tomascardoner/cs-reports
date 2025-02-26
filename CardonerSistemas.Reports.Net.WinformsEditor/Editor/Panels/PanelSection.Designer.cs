namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    partial class PanelSection
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
            numericUpDownHeight = new NumericUpDown();
            labelType = new Label();
            comboBoxType = new ComboBox();
            labelHeight = new Label();
            labelOrder = new Label();
            numericUpDownOrder = new NumericUpDown();
            tableLayoutPanelButtons = new TableLayoutPanel();
            buttonDelete = new Button();
            buttonApply = new Button();
            buttonReset = new Button();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOrder).BeginInit();
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
            tableLayoutPanelMain.Controls.Add(numericUpDownHeight, 2, 3);
            tableLayoutPanelMain.Controls.Add(labelType, 1, 1);
            tableLayoutPanelMain.Controls.Add(comboBoxType, 2, 1);
            tableLayoutPanelMain.Controls.Add(labelHeight, 1, 3);
            tableLayoutPanelMain.Controls.Add(labelOrder, 1, 2);
            tableLayoutPanelMain.Controls.Add(numericUpDownOrder, 2, 2);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 2, 4);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 6;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.DecimalPlaces = 2;
            numericUpDownHeight.Location = new Point(273, 247);
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new Size(80, 27);
            numericUpDownHeight.TabIndex = 5;
            numericUpDownHeight.TextAlign = HorizontalAlignment.Right;
            numericUpDownHeight.ThousandsSeparator = true;
            numericUpDownHeight.Enter += ControlFocusEnter;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Dock = DockStyle.Fill;
            labelType.Location = new Point(176, 177);
            labelType.Name = "labelType";
            labelType.Size = new Size(91, 34);
            labelType.TabIndex = 0;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(273, 180);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(250, 28);
            comboBoxType.TabIndex = 1;
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Dock = DockStyle.Fill;
            labelHeight.Location = new Point(176, 244);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(91, 33);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "Height (cm):";
            labelHeight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Dock = DockStyle.Fill;
            labelOrder.Location = new Point(176, 211);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(91, 33);
            labelOrder.TabIndex = 2;
            labelOrder.Text = "Order:";
            labelOrder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownOrder
            // 
            numericUpDownOrder.Location = new Point(273, 214);
            numericUpDownOrder.Name = "numericUpDownOrder";
            numericUpDownOrder.Size = new Size(60, 27);
            numericUpDownOrder.TabIndex = 3;
            numericUpDownOrder.TextAlign = HorizontalAlignment.Right;
            numericUpDownOrder.ThousandsSeparator = true;
            numericUpDownOrder.Enter += ControlFocusEnter;
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
            tableLayoutPanelButtons.Location = new Point(273, 280);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle());
            tableLayoutPanelButtons.Size = new Size(206, 40);
            tableLayoutPanelButtons.TabIndex = 6;
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
            // PanelSection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "PanelSection";
            Size = new Size(700, 500);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOrder).EndInit();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelOrder;
        private Label labelType;
        private ComboBox comboBoxType;
        private Label labelHeight;
        private NumericUpDown numericUpDownOrder;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button buttonApply;
        private Button buttonReset;
        private Button buttonDelete;
        private NumericUpDown numericUpDownHeight;
    }
}
