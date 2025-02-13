using System.Data.Common;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Pages
    {
        internal static PdfPage CreateNewPage(PdfDocument pdfDocument, Model.Report report, int pageNumber, Dictionary<short, XBrush> brushes, Dictionary<short, XFont> fonts, DbDataReader? dbDataReader)
        {
            ArgumentNullException.ThrowIfNull(report);
            ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);

            PdfPage pdfPage = pdfDocument.Pages.Add();
            pdfPage.Size = (PdfSharp.PageSize)report.PageSize;
            pdfPage.Orientation = (PdfSharp.PageOrientation)report.PageOrientation;
            pdfPage.TrimMargins.Top = new((double)report.PageMarginTop, XGraphicsUnit.Centimeter);
            pdfPage.TrimMargins.Left = new((double)report.PageMarginLeft, XGraphicsUnit.Centimeter);
            pdfPage.TrimMargins.Right = new((double)report.PageMarginRight, XGraphicsUnit.Centimeter);
            pdfPage.TrimMargins.Bottom = new((double)report.PageMarginBottom, XGraphicsUnit.Centimeter);
            pdfPage.Width = pdfPage.Width - (pdfPage.TrimMargins.Left + pdfPage.TrimMargins.Right);
            pdfPage.Height = pdfPage.Height - (pdfPage.TrimMargins.Top + pdfPage.TrimMargins.Bottom);

            // Get an XGraphics object for drawing on this page.
            using XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);

            decimal sectionsPositionYStart = 0;
            if (pageNumber == 1)
            {
                // Create report headers
                Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.ReportHeader, brushes, fonts, dbDataReader, ref sectionsPositionYStart);
            }

            // Create page headers
            Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.PageHeader, brushes, fonts, dbDataReader, ref sectionsPositionYStart);

            // Create details
            if (dbDataReader is not null)
            {
                try
                {
                    do
                    {
                        Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.Detail, brushes, fonts, dbDataReader, ref sectionsPositionYStart);
                    } while (dbDataReader.Read());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Create report footers
            if (pageNumber == 100)
            {
                Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.ReportFooter, brushes, fonts, dbDataReader, ref sectionsPositionYStart);
            }

            // Create page footers
            Section.CreateByType(xGraphics, report, Model.Section.SectionTypes.PageFooter, brushes, fonts, dbDataReader, ref sectionsPositionYStart);

            return pdfPage;
        }
    }
}