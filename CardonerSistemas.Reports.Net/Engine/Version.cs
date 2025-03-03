namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Version
    {
        internal const decimal Report = 1.0m;

        internal static bool Update(Model.Report report)
        {
            // From version 1.0 to 1.1
            if (report.Version == 1.0m)
            {
                foreach (Model.Brush brush in report.Brushes)
                {
                    if (brush.Type == Model.Brush.BrushTypes.Solid)
                    {
                        brush.Color2Red = null;
                        brush.Color2Green = null;
                        brush.Color2Blue = null;
                        brush.PositionX1 = null;
                        brush.PositionY1 = null;
                        brush.PositionX2 = null;
                        brush.PositionY2 = null;
                    }
                    if (brush.Type != Model.Brush.BrushTypes.LinealGradient)
                    {
                        brush.LinearGradientMode = null;
                    }
                    if (brush.Type != Model.Brush.BrushTypes.RadialGradient)
                    {
                        brush.RadiusStart = null;
                        brush.RadiusEnd = null;
                    }
                }
                foreach (Model.Text text in report.Texts)
                {
                    switch (text.TextType)
                    {
                        case Model.Text.TextTypes.Static:
                            text.DatasourceFieldId = null;
                            text.DatasourceParameterId = null;
                            text.ReportParameterId = null;
                            text.FormuladId = null;
                            break;
                        case Model.Text.TextTypes.DatasourceField:
                            text.DatasourceParameterId = null;
                            text.ReportParameterId = null;
                            text.FormuladId = null;
                            text.StaticText = null!;
                            break;
                        case Model.Text.TextTypes.DatasourceParameter:
                            text.DatasourceFieldId = null;
                            text.ReportParameterId = null;
                            text.FormuladId = null;
                            text.StaticText = null!;
                            break;
                        case Model.Text.TextTypes.ReportParameter:
                            text.DatasourceFieldId = null;
                            text.DatasourceParameterId = null;
                            text.FormuladId = null;
                            text.StaticText = null!;
                            break;
                        case Model.Text.TextTypes.Formula:
                            text.DatasourceFieldId = null;
                            text.DatasourceParameterId = null;
                            text.ReportParameterId = null;
                            text.StaticText = null!;
                            break;
                        default:
                            break;
                    }
                }
                report.Version = 1.1m;
            }
            return true;
        }
    }
}
