using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using System.Data.Common;

namespace CSReports.Engine
{
    public static class Pdf
    {
        public static PdfDocument? Create(Model.Report report, string language = "")
        {
            PdfDocument? pdfDocument = null;

            try
            {
                ArgumentNullException.ThrowIfNull(report);

                // Check for elements in report definition
                if (report.Sections.Count == 0 || (report.Texts.Count + report.Lines.Count + report.Rectangles.Count) == 0)
                {
                    return null;
                }

                // Open the datasource
                DbDataReader? dbDataReader = null;
                Dictionary<string, int> fieldsOrdinals = [];
                Data.Datasource.GetDatasource(report, ref dbDataReader, fieldsOrdinals);

                // Create a new PDF document
                pdfDocument = new();
                pdfDocument.Info.Author = "CS-Reports.Net";
                pdfDocument.Info.CreationDate = DateTime.Now;
                pdfDocument.Info.Title = report.Name;
                pdfDocument.Language = language;

                // Create fonts
                Dictionary<short, XFont> fonts = Fonts.Create(report.Fonts);

                // Create brushes
                Dictionary<short, XBrush> brushes = Brushes.Create(report.Brushes);

                // Generate report
                Pages.Create(report, pdfDocument, fonts, brushes, dbDataReader, fieldsOrdinals);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pdfDocument;
        }

        public static void Save(PdfDocument pdfDocument, string filename)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(pdfDocument);
                ArgumentNullException.ThrowIfNullOrEmpty(filename);
                // Save the document
                pdfDocument.Save(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Preview(PdfDocument pdfDocument)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(pdfDocument);

                // Save the document
                string filename = PdfFileUtility.GetTempPdfFullFileName("CS-Reports.Net");
                pdfDocument.Save(filename);
                PdfFileUtility.ShowDocument(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}