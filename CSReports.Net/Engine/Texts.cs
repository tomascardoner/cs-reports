using PdfSharp.Drawing;
using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Texts
    {
        internal static void Create(XGraphics xGraphics, IEnumerable<Model.Text> texts, Dictionary<short, XFont> fonts, Dictionary<short, XBrush> brushes, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals, decimal sectionPositionYStart)
        {
            // Create texts in type order (Statics -> Fields -> Formulas)
            foreach (Model.Text text in texts.OrderBy(t => t.TextType))
            {
                Tuple<decimal, decimal, decimal, decimal> positions = Units.ConvertRelativeCentimetersToAbsolutePoints(sectionPositionYStart, text.PositionX, text.PositionY, text.Width, text.Height);
                string textValue = text.TextType switch
                {
                    Model.Text.TextTypes.Static => text.Value,
                    Model.Text.TextTypes.Field => TextFields.GetValue(text, dbDataReader, fieldsOrdinals),
                    Model.Text.TextTypes.Formula => string.Empty,
                    _ => string.Empty
                };
                XStringFormat xStringFormat = new()
                {
                    Alignment = text.StringAlignment,
                    LineAlignment = text.LineAlignment
                };
                xGraphics.DrawString(textValue, fonts[text.FontId], brushes[text.BrushId], new XRect((float)positions.Item1, (float)positions.Item2, (float)positions.Item3, (float)positions.Item4), xStringFormat);
            }
        }
    }
}