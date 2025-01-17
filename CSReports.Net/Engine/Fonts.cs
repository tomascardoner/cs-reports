using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;

namespace CSReports.Engine
{
    internal static class Fonts
    {
        internal static Dictionary<short, XFont> Create(ICollection<Model.Font> fonts)
        {
            try
            {
                Dictionary<short, XFont> dictOfFonts = [];
                foreach (Model.Font font in fonts)
                {
                    dictOfFonts.Add(font.FontId, new(font.Name, (double)font.Size, font.Style));
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
}
