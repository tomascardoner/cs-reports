using CardonerSistemas.Reports.Net.Data;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Engine
{
    public static class Pdf
    {
        private static PdfDocument? Create(Model.Report report, string language = "")
        {
            ArgumentNullException.ThrowIfNull(report);
            
            PdfDocument? pdfDocument = null;

            try
            {
                // Check for elements in report definition
                if (report.Sections.Count > 0 && (report.Texts.Count + report.Lines.Count + report.Rectangles.Count) > 0)
                {
                    // Open the datasource
                    DbDataReader? dbDataReader = null;
                    Dictionary<string, int> fieldsOrdinals = [];
                    Datasource.GetDatasource(report, ref dbDataReader, fieldsOrdinals);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pdfDocument;
        }

        private static void Preview(PdfDocument pdfDocument)
        {
            ArgumentNullException.ThrowIfNull(pdfDocument);

            try
            {
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

        public static bool Preview(Model.Report report, string language = "")
        {
            ArgumentNullException.ThrowIfNull(report);

            using PdfDocument? pdfDocument = Create(report, language);
            if (pdfDocument is not null)
            {
                Preview(pdfDocument);
                return true;
            }
            return false;
        }

        public static bool Save(Model.Report report, string filename, string language = "")
        {
            ArgumentNullException.ThrowIfNull(report);
            ArgumentNullException.ThrowIfNullOrEmpty(filename);

            using PdfDocument? pdfDocument = Create(report, language);
            if (pdfDocument is not null)
            {
                try
                {
                    // Save the document
                    pdfDocument.Save(filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return true;
            }
            return false;
        }
    }
}