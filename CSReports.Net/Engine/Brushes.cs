using PdfSharp.Drawing;

namespace CSReports.Engine
{
    internal static class Brushes
    {
        internal static Dictionary<short, XBrush> Create(ICollection<Model.Brush> brushes)
        {
            try
            {
                Dictionary<short, XBrush> dictOfBrushes = [];
                foreach (Model.Brush brush in brushes)
                {
                    XBrush xBrush = brush.Type switch
                    {
                        Model.Brush.BrushTypes.Solid => new XSolidBrush(brush.Color1),
                        Model.Brush.BrushTypes.LinealGradient => new XLinearGradientBrush(brush.Rectangle, brush.Color1, brush.Color2, brush.LinearGradientMode),
                        Model.Brush.BrushTypes.RadialGradient => new XRadialGradientBrush(brush.Point1, brush.Point2, (double)(brush.RadiusStart ?? 0), (double)(brush.RadiusEnd ?? 0), brush.Color1, brush.Color2),
                        _ => throw new NotImplementedException($"Brush type {brush.Type} not implemented.")
                    };
                    dictOfBrushes.Add(brush.BrushId, xBrush);
                }
                return dictOfBrushes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return [];
            }
        }
    }
}
