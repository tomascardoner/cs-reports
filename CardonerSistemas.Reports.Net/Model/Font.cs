using System.Text.Json.Serialization;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Model;

public class Font
{
    public Font(Report report)
    {
        if (report.Fonts.Count == 0)
        {
            FontId = 1;
        }
        else
        {
            FontId = (short)(report.Fonts.Max(f => f.FontId) + 1);
        }
    }

    [JsonConstructor]
    public Font(short fontId)
    {
        FontId = fontId;
    }

    public short FontId { get; }

    public string Name { get; set; } = string.Empty;

    public decimal Size { get; set; }

    public bool Bold { get; set; }

    public bool Italic { get; set; }

    public bool Underline { get; set; }

    public bool Strikethrough { get; set; }

    [JsonIgnore]
    internal XFontStyleEx Style
    {
        get
        {
            if (Bold && Italic)
            {
                return XFontStyleEx.BoldItalic;
            }

            if (Bold)
            {
                return XFontStyleEx.Bold;
            }

            if (Italic)
            {
                return XFontStyleEx.Italic;
            }

            if (Underline)
            {
                return XFontStyleEx.Underline;
            }

            if (Strikethrough)
            {
                return XFontStyleEx.Strikeout;
            }

            return XFontStyleEx.Regular;
        }
    }

    [JsonIgnore]
    public string DisplayNameShort => Name == Properties.Resources.StringFontNameNew ? Properties.Resources.StringFontNameNew : $"{Name} {Size}pt {Style}";

    [JsonIgnore]
    public string DisplayName => $"#{FontId:00} - {DisplayNameShort}";
}
