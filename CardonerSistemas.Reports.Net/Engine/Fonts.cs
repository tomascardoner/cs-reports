using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Engine;

internal static class Fonts
{
    private static XFont? Create(string name, double size, XFontStyleEx style)
    {
        try
        {
            return new(name, size, style);
        }
        catch (System.InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return new("Arial", size, style);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    internal static Dictionary<short, XFont> Create(ICollection<Model.Font> fonts)
    {
        try
        {
            Dictionary<short, XFont> dictOfFonts = [];
            foreach (Model.Font font in fonts)
            {
                XFont? xFont = Create(font.Name, (double)font.Size, font.Style);
                if (xFont is not null)
                {
                    dictOfFonts.Add(font.FontId, xFont);
                }
            }

            return dictOfFonts;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }
}
