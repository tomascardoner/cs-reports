using CSReports.Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.Common;

namespace CSReports.Engine
{
    internal static class Pages
    {
        internal static bool Create(Model.Report report, PdfDocument pdfDocument, Dictionary<short, XFont> fonts, Dictionary<short, XBrush> brushes, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            decimal detailSectionsTotalHeight = Units.ConvertCentimetersToPoints(report.Sections.Where(s => s.Type == Section.SectionTypes.Detail).Sum(s => s.Height));

            PdfPage pdfPage = pdfDocument.Pages.Add();
            Dictionary<Tuple<short, int>, PageLayoutItem> pageLayoutItems = PageLayouts.Create(report, pdfDocument, pdfPage, detailSectionsTotalHeight, 100);

            // Get an XGraphics object for drawing on this page.
            using XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);

            Lines.Create(xGraphics, pageLayoutItems, report.Lines);
            Rectangles.Create(xGraphics, pageLayoutItems, report.Rectangles, brushes);
            Texts.Create(xGraphics, pageLayoutItems, fonts, brushes, report.Texts, dbDataReader, fieldsOrdinals);

            return true;
        }
    }
}