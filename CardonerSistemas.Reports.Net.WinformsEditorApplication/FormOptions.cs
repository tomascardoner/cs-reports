namespace CardonerSistemas.Reports.Net.WinformsEditorApplication;

public partial class FormOptions : Form
{

    public FormOptions()
    {
        InitializeComponent();
        InitializeForm();
    }

    private void InitializeForm()
    {
        Program.s_options ??= new OptionsConfig();

        numericUpDownTreeIconSize.Value = Program.s_options.TreeIconSize;
        Font font = Program.s_options.TreeFont;
        textBoxFont.Tag = font;
        textBoxFont.Text = $"{font.Name} {font.Size}pt {font.Style}";
    }

    private void SelectFont(object sender, EventArgs e)
    {
        using FontDialog fontDialog = new();
        if (fontDialog.ShowDialog(this) == DialogResult.OK)
        {
            textBoxFont.Tag = fontDialog.Font;
            textBoxFont.Text = $"{fontDialog.Font.Name} {fontDialog.Font.Size}pt {fontDialog.Font.Style}";
        }
    }

    public void SaveOptions(object sender, EventArgs e)
    {
        if (textBoxFont.Tag is null)
        {
            MessageBox.Show("You must select a font for the tree.", Program.ApplicationInfo.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            buttonFont.Focus();
            return;
        }

        Program.s_options!.TreeIconSize = Convert.ToInt32(numericUpDownTreeIconSize.Value);
        Program.s_options.TreeFont = (Font)textBoxFont.Tag;
        Framework.Base.Configuration.Json.SaveFile(string.Empty, Program.OptionsFileName, ref Program.s_options, true);
        Close();
    }

    public void Close(object sender, EventArgs e)
    {
        Close();
    }
}
