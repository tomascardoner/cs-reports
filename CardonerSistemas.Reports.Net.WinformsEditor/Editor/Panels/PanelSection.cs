namespace CardonerSistemas.Reports.Net.WinformsEditor.Editor.Panels
{
    public partial class PanelSection : UserControl
    {

        #region Declarations

        private readonly Model.Report _report;
        private Model.Section? _section;
        private readonly string _applicationTitle;

        public delegate void SectionHandler(object sender, short sectionId);

        public event SectionHandler? SectionUpdated;
        public event SectionHandler? SectionDeleted;

        #endregion Declarations

        #region Initialization

        public PanelSection(Model.Report report, string applicationTitle)
        {
            InitializeComponent();
            _report = report;
            _applicationTitle = applicationTitle;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Common.InitializeNumericUpDownControlForPoints(numericUpDownHeight);

            buttonApply.Text = Properties.Resources.StringApplyChanges;
            buttonReset.Text = Properties.Resources.StringResetChanges;
            buttonDelete.Text = Properties.Resources.StringSectionsDelete;

            FillTypes();
        }

        private void FillTypes()
        {
            comboBoxType.ValueMember = "Key";
            comboBoxType.DisplayMember = "Value";
            ICollection<KeyValuePair<int, string>> items = [];
            foreach (Model.Section.SectionTypes type in Enum.GetValues<Model.Section.SectionTypes>())
            {
                items.Add(new KeyValuePair<int, string>((int)type, FriendlyNames.GetSectionType(type)));
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
            else if (sender is NumericUpDown numericUpDown)
            {
                numericUpDown.Select(0, numericUpDown.Text.Length);
            }
        }

        #endregion Events

        #region Methods

        private void ShowProperties()
        {
            if (_section is null)
            {
                return;
            }
            comboBoxType.SelectedValue = (int)_section.Type;
            numericUpDownOrder.Value = _section.Order;
            numericUpDownHeight.Value = _section.Height;
        }

        internal void ShowProperties(short sectionId)
        {
            _section = _report.Sections.FirstOrDefault(s => s.SectionId == sectionId);
            ShowProperties();
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            if (_section is null)
            {
                return;
            }
            if (comboBoxType.SelectedValue is null)
            {
                MessageBox.Show(Properties.Resources.StringSectionTypeRequired, _applicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return;
            }
            if (SectionUpdated is not null)
            {
                SectionUpdated(this, _section.SectionId);
            }
        }

        private void ResetChanges(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_section is null || MessageBox.Show(string.Format(Properties.Resources.StringSectionDeleteConfirmation, _section.DisplayName), _applicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _report.Sections.Remove(_section);
            if (SectionDeleted is not null)
            {
                SectionDeleted(this, _section.SectionId);
            }
        }

        #endregion Methods

    }
}
