using PdfSharp.Pdf;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class PageLayouts
    {
        internal static Dictionary<Tuple<short, int>, PageLayoutItem> Create(Model.Report report, PdfDocument pdfDocument, PdfPage pdfPage, decimal detailsTotalHeight, int remainingRecordsCount)
        {
            decimal positionYStart;
            decimal positionYEnd;
            decimal headersPositionYEnd;
            decimal footersPositionYStart;
            Dictionary<Tuple<short, int>, PageLayoutItem> dictOfSections = [];

            // Encabezados de reporte y de página
            positionYStart = 0;
            foreach (Model.Section section in report.Sections.Where(s => s.Type == Model.Section.SectionTypes.ReportHeader || s.Type == Model.Section.SectionTypes.PageHeader).OrderBy(s => s.Type).ThenBy(s => s.Order))
            {
                switch (section.Type)
                {
                    case Model.Section.SectionTypes.ReportHeader:
                        if (pdfDocument.Pages.Count == 1)
                        {
                            positionYEnd = positionYStart + Units.ConvertCentimetersToPoints(section.Height);
                            dictOfSections.Add(Tuple.Create(section.SectionId, 0), new() { SectionType = section.Type, PositionYStart = positionYStart, PositionYEnd = positionYEnd });
                            positionYStart = positionYEnd;
                        }
                        break;
                    case Model.Section.SectionTypes.PageHeader:
                        positionYEnd = positionYStart + Units.ConvertCentimetersToPoints(section.Height);
                        dictOfSections.Add(Tuple.Create(section.SectionId, 0), new() { SectionType = section.Type, PositionYStart = positionYStart, PositionYEnd = positionYEnd });
                        positionYStart = positionYEnd;
                        break;
                    default:
                        break;
                }
            }
            headersPositionYEnd = positionYStart;

            // Pies de página
            positionYEnd = (decimal)pdfPage.Height.Value;
            foreach (Model.Section section in report.Sections.Where(s => s.Type == Model.Section.SectionTypes.PageFooter).OrderByDescending(s => s.Order))
            {
                positionYStart = positionYEnd - Units.ConvertCentimetersToPoints(section.Height);
                dictOfSections.Add(Tuple.Create(section.SectionId, 0), new PageLayoutItem() { SectionType = section.Type, PositionYStart = positionYStart, PositionYEnd = positionYEnd });
                positionYEnd = positionYStart;
            }
            footersPositionYStart = positionYEnd;

            // Detalles
            positionYStart = headersPositionYEnd;
            for (int rowNumber = 1; rowNumber <= remainingRecordsCount && rowNumber <= (report.DetailSectionMaxRowCount ?? 0); rowNumber++)
            {
                if (detailsTotalHeight <= footersPositionYStart - positionYStart)
                {
                    foreach (Model.Section section in report.Sections.Where(s => s.Type == Model.Section.SectionTypes.Detail).OrderBy(s => s.Order))
                    {
                        positionYEnd = positionYStart + Units.ConvertCentimetersToPoints(section.Height);
                        dictOfSections.Add(Tuple.Create(section.SectionId, rowNumber), new() { SectionType = section.Type, RowNumber = rowNumber, PositionYStart = positionYStart, PositionYEnd = positionYEnd });
                        positionYStart = positionYEnd;
                    }
                }
            }

            return dictOfSections;
        }
    }
}
