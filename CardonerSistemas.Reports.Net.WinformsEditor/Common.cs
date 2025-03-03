namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    internal static class Common
    {
        internal static void InitializeNumericUpDownControlForPoints(NumericUpDown numericUpDown)
        {
            numericUpDown.DecimalPlaces = Engine.Pdf.PointsDecimalPlaces;
            numericUpDown.Maximum = Engine.Pdf.ThicknessMaxValue;
        }

        internal static void InitializeNumericUpDownControlForCentimeters(NumericUpDown numericUpDown)
        {
            numericUpDown.DecimalPlaces = Engine.Pdf.CentimetersDecimalPlaces;
            numericUpDown.Maximum = Engine.Pdf.CentimetersMaxValue;
        }

        internal static void FillComboBoxSections(ComboBox comboBox, Model.Report report)
        {
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            ICollection<KeyValuePair<short, string>> items = [];
            foreach (Model.Section section in report.Sections.OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                items.Add(new KeyValuePair<short, string>(section.SectionId, section.DisplayName));
            }
            comboBox.DataSource = items;
        }

        internal static void FillComboBoxBrushes(ComboBox comboBox, Model.Report report, bool addNoneItem)
        {
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            ICollection<KeyValuePair<short, string>> items = [];
            if (addNoneItem)
            {
                items.Add(new KeyValuePair<short, string>(0, Properties.Resources.StringBrushNone));
            }
            foreach (Model.Brush brush in report.Brushes.OrderBy(b => b.DisplayName))
            {
                items.Add(new KeyValuePair<short, string>(brush.BrushId, brush.DisplayName));
            }
            comboBox.DataSource = items;
            if (addNoneItem)
            {
                comboBox.SelectedIndex = 0;
            }
        }
    }
}
