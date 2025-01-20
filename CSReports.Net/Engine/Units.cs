namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class Units
    {
        // PDF uses the same basic measurement unit as PostScript: 72 points == 1 inch.
        private const decimal FactorInchToCentimeter = 2.54m;
        private const decimal FactorPointsToInch = 72;
        private const decimal FactorPointsToCentimeter = FactorPointsToInch / FactorInchToCentimeter;

        internal static decimal ConvertCentimetersToPoints(decimal value)
        {
            return value * FactorPointsToCentimeter;
        }

        internal static decimal ConvertPointsToCentimeters(decimal value)
        {
            return value / FactorPointsToCentimeter;
        }

        internal static Tuple<decimal, decimal, decimal, decimal> ConvertRelativeCentimetersToAbsolutePoints(PageLayoutItem pageLayout1, decimal value1, decimal value2, PageLayoutItem pageLayout2, decimal value3, decimal value4)
        {
            return Tuple.Create(ConvertCentimetersToPoints(value1), pageLayout1.PositionYStart + ConvertCentimetersToPoints(value2), ConvertCentimetersToPoints(value3), pageLayout2.PositionYStart + ConvertCentimetersToPoints(value4));
        }
    }
}
