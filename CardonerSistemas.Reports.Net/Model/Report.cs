using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public partial class Report
{

    public Report()
    {
        ReportId = Guid.NewGuid();
    }

    [JsonConstructor]
    public Report(Guid reportId)
    {
        ReportId = reportId;
    }

    public Guid ReportId { get; }

    public decimal Version { get; set; } = Engine.Version.Report;

    public string Name { get; set; } = string.Empty;

    public string TemplateFileName { get; set; } = string.Empty;

    public PageSizes PageSize { get; set; } = PageSizes.A4;

    public PageOrientations PageOrientation { get; set; } = PageOrientations.Portrait;

    public decimal PageMarginTop { get; set; } = 1.5m;

    public decimal PageMarginLeft { get; set; } = 1.5m;

    public decimal PageMarginRight { get; set; } = 1.5m;

    public decimal PageMarginBottom { get; set; } = 1.5m;

    public short DetailSectionMaxRowCount { get; set; }

    public ICollection<ReportParameter> Parameters { get; set; } = [];

    public Datasource? Datasource { get; set; }

    public ICollection<Formula> Formulas { get; set; } = [];

    public ICollection<Section> Sections { get; set; } = [];

    public ICollection<Font> Fonts { get; set; } = [];

    public ICollection<Brush> Brushes { get; set; } = [];

    public ICollection<Line> Lines { get; set; } = [];

    public ICollection<Rectangle> Rectangles { get; set; } = [];

    public ICollection<Text> Texts { get; set; } = [];

    [JsonIgnore]
    public bool IsModified { get; set; }

    [JsonIgnore]
    public string DisplayName => string.IsNullOrWhiteSpace(Name) ? Properties.Resources.StringReportNameNew : Name;

}
