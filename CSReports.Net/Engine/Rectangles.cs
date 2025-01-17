using CSReports.Model;
using PdfSharp.Drawing;
using System.Reflection;

namespace CSReports.Engine
{
    internal static class Rectangles
    {
        internal static void Create(XGraphics xGraphics, Dictionary<Tuple<short, int>, PageLayoutItem> pageLayoutItems, ICollection<Model.Rectangle> rectangles, Dictionary<short, XBrush> brushes)
        {
            foreach (var (rectangle, positions) in from KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem in pageLayoutItems
                                                   from Model.Rectangle rectangle in rectangles.Where(r => r.SectionId1 == pageLayoutItem.Key.Item1)
                                                   let positions = Units.ConvertRelativeCentimetersToAbsolutePoints(pageLayoutItems[pageLayoutItem.Key], rectangle.PositionX1, rectangle.PositionY1, pageLayoutItems[pageLayoutItem.Key], rectangle.PositionX2, rectangle.PositionY2)
                                                   select (rectangle, positions))
            {
                if (rectangle.BrushId.HasValue)
                {
                    xGraphics.DrawRectangle(new XPen(rectangle.BorderColor, (double)rectangle.BorderThickness), brushes[rectangle.BrushId.Value], (float)positions.Item1, (float)positions.Item2, (float)(positions.Item3 - positions.Item1), (float)(positions.Item4 - positions.Item2));
                }
                else
                {
                    xGraphics.DrawRectangle(new XPen(rectangle.BorderColor, (double)rectangle.BorderThickness), (float)positions.Item1, (float)positions.Item2, (float)(positions.Item3 - positions.Item1), (float)(positions.Item4 - positions.Item2));
                }
            }
        }
    }
}