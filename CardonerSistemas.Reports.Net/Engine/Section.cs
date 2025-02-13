using System.Data.Common;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Section
    {
        internal static void CreateByType(XGraphics xGraphics, Model.Report report, Model.Section.SectionTypes type, Dictionary<short, XBrush> brushes, Dictionary<short, XFont> fonts, DbDataReader? dbDataReader, ref decimal sectionsPositionYStart)
        {
            foreach (Model.Section section in report.Sections.Where(s => s.Type == type).OrderBy(s => s.Order))
            {
                Lines.Create(xGraphics, report.Lines.Where(l => l.SectionId1 == section.SectionId), sectionsPositionYStart);
                Rectangles.Create(xGraphics, report.Rectangles.Where(r => r.SectionId1 == section.SectionId), brushes, sectionsPositionYStart);
                Texts.Create(xGraphics, report.Texts.Where(t => t.SectionId == section.SectionId), fonts, brushes, dbDataReader, report.Datasource, sectionsPositionYStart);
                sectionsPositionYStart += Units.ConvertCentimetersToPoints(section.Height);
            }
        }
    }
}