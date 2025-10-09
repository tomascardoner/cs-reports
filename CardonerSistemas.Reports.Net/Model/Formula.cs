using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public class Formula
{

    public Formula(Report report)
    {
        if (report.Formulas.Count == 0)
        {
            FormulaId = 1;
        }
        else
        {
            FormulaId = (short)(report.Formulas.Max(f => f.FormulaId) + 1);
        }
    }

    [JsonConstructor]
    public Formula(short formulaId)
    {
        FormulaId = formulaId;
    }

    public short FormulaId { get; }

    public string Name { get; set; } = string.Empty;

    public string Definition { get; set; } = string.Empty;

}
