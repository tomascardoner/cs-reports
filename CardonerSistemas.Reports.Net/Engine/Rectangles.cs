using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Engine;

internal static class Rectangles
{
    internal static void Create(XGraphics xGraphics, IEnumerable<Model.Rectangle> rectangles, Dictionary<short, XBrush> brushes, decimal sectionPositionYStart)
    {
        foreach (Model.Rectangle rectangle in rectangles)
        {
            Tuple<decimal, decimal, decimal, decimal> positions = Units.ConvertRelativeCentimetersToAbsolutePoints(sectionPositionYStart, rectangle.PositionX1, rectangle.PositionY1, rectangle.PositionX2, rectangle.PositionY2);
            if (rectangle.BrushId.HasValue)
            {
                xGraphics.DrawRectangle(new XPen(rectangle.BorderColor, (double)rectangle.BorderThickness), brushes[rectangle.BrushId.Value], (double)positions.Item1, (double)positions.Item2, (double)(positions.Item3 - positions.Item1), (double)(positions.Item4 - positions.Item2));
            }
            else
            {
                xGraphics.DrawRectangle(new XPen(rectangle.BorderColor, (double)rectangle.BorderThickness), (double)positions.Item1, (double)positions.Item2, (double)(positions.Item3 - positions.Item1), (double)(positions.Item4 - positions.Item2));
            }
        }
    }
}