using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Pages
    {
        internal static PdfPage CreateNewPage(PdfDocument pdfDocument, Model.Report report, int pageNumber, Dictionary<short, XBrush> brushes, Dictionary<short, XFont> fonts, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            ArgumentNullException.ThrowIfNull(report);
            ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);

            PdfPage pdfPage = pdfDocument.Pages.Add();
            pdfPage.Size = (PdfSharp.PageSize)report.PageSize;
            pdfPage.Orientation = (PdfSharp.PageOrientation)report.PageOrientation;

            // Get an XGraphics object for drawing on this page.
            using XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);

            decimal sectionsPositionYStart = 0;
            if (pageNumber == 1)
            {
                // Create report headers
                Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.ReportHeader, brushes, fonts, dbDataReader, fieldsOrdinals, ref sectionsPositionYStart);
            }

            // Create page headers
            Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.PageHeader, brushes, fonts, dbDataReader, fieldsOrdinals, ref sectionsPositionYStart);

            return pdfPage;
        }
    }
}