using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Lines
    {
        internal static void Create(XGraphics xGraphics, IEnumerable<Model.Line> lines, decimal sectionPositionYStart)
        {
            foreach (Model.Line line in lines)
            {
                Tuple<decimal, decimal, decimal, decimal> positions = Units.ConvertRelativeCentimetersToAbsolutePoints(sectionPositionYStart, line.PositionX1, line.PositionY1, line.PositionX2, line.PositionY2);
                xGraphics.DrawLine(new XPen(line.Color, (double)line.Thickness), (double)positions.Item1, (double)positions.Item2, (double)positions.Item3, (double)positions.Item4);
            }
        }
    }
}