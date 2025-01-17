using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CSReports.Engine
{
    internal static class Lines
    {
        internal static void Create(XGraphics xGraphics, Dictionary<Tuple<short, int>, PageLayoutItem> pageLayoutItems, ICollection<Model.Line> lines)
        {

            foreach (var (line, positions) in from KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem in pageLayoutItems
                                                                                                       from Model.Line line in lines.Where(l => l.SectionId1 == pageLayoutItem.Key.Item1)
                                                                                                       let positions = Units.ConvertRelativeCentimetersToAbsolutePoints(pageLayoutItems[pageLayoutItem.Key], line.PositionX1, line.PositionY1, pageLayoutItems[pageLayoutItem.Key], line.PositionX2, line.PositionY2)
                                                                                                       select (line, positions))
            {
                xGraphics.DrawLine(new XPen(line.Color, (double)line.Thickness), (float)positions.Item1, (float)positions.Item2, (float)positions.Item3, (float)positions.Item4);
            }
        }
    }
}