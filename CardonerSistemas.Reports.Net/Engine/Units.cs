namespace CardonerSistemas.Reports.Net.Engine;

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

    internal static Tuple<decimal, decimal, decimal, decimal> ConvertRelativeCentimetersToAbsolutePoints(decimal startPositionY, decimal valueX1, decimal valueY1, decimal valueX2, decimal valueY2)
    {
        return Tuple.Create(ConvertCentimetersToPoints(valueX1), startPositionY + ConvertCentimetersToPoints(valueY1), ConvertCentimetersToPoints(valueX2), startPositionY + ConvertCentimetersToPoints(valueY2));
    }
}
