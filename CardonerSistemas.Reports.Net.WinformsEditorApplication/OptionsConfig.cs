namespace CardonerSistemas.Reports.Net.WinformsEditorApplication;

public class OptionsConfig
{
    public int TreeIconSize { get; set; } = 32;
    public string TreeFontName { get; set; } = SystemFonts.DefaultFont.Name;
    public float TreeFontSize { get; set; } = SystemFonts.DefaultFont.Size;
    public FontStyle TreeFontStyle { get; set; } = SystemFonts.DefaultFont.Style;

    private Font? _treeFont;

    internal Font TreeFont
    {
        get
        {
            _treeFont ??= new Font(TreeFontName, TreeFontSize, TreeFontStyle);
            return _treeFont;
        }
        set
        {
            _treeFont = value;
            TreeFontName = value.Name;
            TreeFontSize = value.Size;
            TreeFontStyle = value.Style;
        }
    }
}
