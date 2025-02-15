namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelFont : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Font? _font;
        private readonly string _applicationTitle;

        public delegate void FontHandler(object sender, short fontId);

        public event FontHandler? FontUpdated;
        public event FontHandler? FontDeleted;

        #endregion Declarations

        #region Initialization

        public PanelFont(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;

            FillTypes();
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (System.Data.DbType dbType in Enum.GetValues<System.Data.DbType>())
            {
                items.Add(new KeyValuePair<int, string>((int)dbType, dbType.ToString()));
            }
            comboBoxType.DataSource = items;
        }

        #endregion Initialization

        #region Events

        private void ControlFocusEnter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_font is null)
            {
                return;
            }
            textBoxName.Text = _font.Name;
            //comboBoxType.SelectedValue = (int)_font.Type;
        }

        internal void ShowProperties(short fontId)
        {
            if (_report.Datasource is null)
            {
                return;
            }
            _font = _report.Fonts.FirstOrDefault(f => f.FontId == fontId);
            if (_font is null)
            {
                return;
            }
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_font is null)
            {
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                //MessageBox.Show(Properties.Resources.StringFontNameRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                //MessageBox.Show(Properties.Resources.StringFontTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (_report.Datasource is not null && _report.Datasource.Fields.Any(f => f.Name == textBoxName.Text.Trim() && f.FieldId != _font.FontId))
            {
                MessageBox.Show(Properties.Resources.StringFontNewAlreadyExists, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
            _font.Name = textBoxName.Text.Trim();
            if (FontUpdated is not null)
            {
                FontUpdated(this, _font.FontId);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_font is null || MessageBox.Show(string.Format(Properties.Resources.StringFontDeleteConfirmation, _font.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Fonts.Remove(_font);
            if (FontDeleted is not null)
            {
                FontDeleted(this, _font.FontId);
            }
        }

        #endregion Methods

    }
}
