using PdfSharp.Drawing;
using System.Data.Common;

namespace CSReports.Engine
{
    internal static class Texts
    {
        internal static void Create(XGraphics xGraphics, Dictionary<Tuple<short, int>, PageLayoutItem> pageLayoutItems, Dictionary<short, XFont> fonts, Dictionary<short, XBrush> brushes, ICollection<Model.Text> textos, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            // Crete static texts on sections that aren't details
            foreach (KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem in pageLayoutItems.Where(pli => pli.Value.SectionType != Model.Section.SectionTypes.Detail))
            {
                CreateSectionTexts(xGraphics, pageLayoutItem, fonts, brushes, [..textos.Where(t => t.TextType == Model.Text.TextTypes.Static)], null, fieldsOrdinals);
            }

            if (dbDataReader is not null && dbDataReader.Read())
            {
                int rowCount = 1;

                // Crete texts on sections that aren't details
                foreach (KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem in pageLayoutItems.Where(pli => pli.Value.SectionType != Model.Section.SectionTypes.Detail))
                {
                    CreateSectionTexts(xGraphics, pageLayoutItem, fonts, brushes, [.. textos.Where(t => t.TextType != Model.Text.TextTypes.Static)], dbDataReader, fieldsOrdinals);
                }

                do
                {
                    foreach (KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem in pageLayoutItems.Where(pli => pli.Value.SectionType == Model.Section.SectionTypes.Detail && pli.Value.RowNumber == rowCount))
                    {
                        CreateSectionTexts(xGraphics, pageLayoutItem, fonts, brushes, textos, dbDataReader, fieldsOrdinals);
                    }
                    rowCount++;
                } while (dbDataReader.Read());
            }
        }

        private static void CreateSectionTexts(XGraphics xGraphics, KeyValuePair<Tuple<short, int>, PageLayoutItem> pageLayoutItem, Dictionary<short, XFont> fonts, Dictionary<short, XBrush> brushes, ICollection<Model.Text> texts, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            if (pageLayoutItem.Value is null)
            {
                return;
            }
            foreach (Model.Text text in texts.Where(t => t.SectionId == pageLayoutItem.Key.Item1))
            {
                string valor = text.TextType switch
                {
                    Model.Text.TextTypes.Static => text.Value,
                    Model.Text.TextTypes.Field => TextFields.GetValue(text, dbDataReader, fieldsOrdinals),
                    Model.Text.TextTypes.Formula => string.Empty,
                    _ => string.Empty
                };
                Tuple<decimal, decimal, decimal, decimal> positions = Units.ConvertRelativeCentimetersToAbsolutePoints(pageLayoutItem.Value, text.PositionX, text.PositionY, pageLayoutItem.Value, text.Width, text.Height);
                XStringFormat xStringFormat = new()
                {
                    Alignment = text.StringAlignment,
                    LineAlignment = text.LineAlignment
                };
                xGraphics.DrawString(valor, fonts[text.FontId], brushes[text.BrushId], new XRect((float)positions.Item1, (float)positions.Item2, (float)positions.Item3, (float)positions.Item4), xStringFormat);
            }
        }
    }
}