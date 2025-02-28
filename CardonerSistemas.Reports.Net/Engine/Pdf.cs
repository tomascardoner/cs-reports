using System.Data.Common;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CardonerSistemas.Reports.Net.Engine
{
    public static class Pdf
    {
        public const int UnitsDecimalPlaces = 2;
        public const decimal ThicknessMaxValue = 10;
        public const decimal PositionMaxValue = 50;

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
                    Data.Datasource.GetDatasource(report.Datasource, ref dbDataReader);

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
                    Pages.CreateNewPage(pdfDocument, report, 1, brushes, fonts, dbDataReader);

                    // Close the datasource
                    if (dbDataReader is not null && !dbDataReader.IsClosed)
                    {
                        dbDataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pdfDocument;
        }

        private static void SaveTempAndPreviewInDefaultApp(PdfDocument pdfDocument)
        {
            ArgumentNullException.ThrowIfNull(pdfDocument);

            try
            {
                // Save the document
                string filename = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".pdf");
                pdfDocument.Save(filename);
                ProcessStartInfo startInfo = new(filename) { UseShellExecute = true };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool CreateSaveTempAndPreviewInDefaultApp(Model.Report report, string language = "")
        {
            ArgumentNullException.ThrowIfNull(report);

            using PdfDocument? pdfDocument = Create(report, language);
            if (pdfDocument is not null)
            {
                SaveTempAndPreviewInDefaultApp(pdfDocument);
                return true;
            }
            return false;
        }

        public static bool CreateAndSave(Model.Report report, string filename, string language = "")
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

        public static string CreateAndSaveTemp(Model.Report report, string language = "")
        {
            ArgumentNullException.ThrowIfNull(report);

            string filename = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".pdf");
            if (CreateAndSave(report, filename, language))
            {
                return filename;
            }
            return string.Empty;
        }
    }
}
