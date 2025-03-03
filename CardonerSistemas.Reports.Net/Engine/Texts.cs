using System.Data.Common;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Texts
    {
        internal static void Create(XGraphics xGraphics, IEnumerable<Model.Text> texts, Dictionary<short, XFont> fonts, Dictionary<short, XBrush> brushes, DbDataReader? dbDataReader, Model.Report report, decimal sectionPositionYStart)
        {
            // Create texts in type order (Statics -> Fields -> Formulas)
            foreach (Model.Text text in texts.OrderBy(t => t.TextType))
            {
                Tuple<decimal, decimal, decimal, decimal> positions = Units.ConvertRelativeCentimetersToAbsolutePoints(sectionPositionYStart, text.PositionX, text.PositionY, text.Width, text.Height);
                string textValue = text.TextType switch
                {
                    Model.Text.TextTypes.Static => text.Value,
                    Model.Text.TextTypes.DatasourceField => report.Datasource is null ? string.Empty : TextProcessor.GetDatasourceFieldValue(text, dbDataReader, report.Datasource),
                    Model.Text.TextTypes.DatasourceParameter => report.Datasource is null ? string.Empty : TextProcessor.GetDatasourceParameterValue(text, report.Datasource),
                    Model.Text.TextTypes.ReportParameter => TextProcessor.GetReportParameterValue(text, report),
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
