using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public partial class Section
{
    private readonly Report _report;

    public Section(Report report)
    {
        _report = report;
        if (report.Sections.Count == 0)
        {
            SectionId = 1;
        }
        else
        {
            SectionId = (short)(report.Sections.Max(s => s.SectionId) + 1);
        }
    }

    public Section(Report report, short sectionId)
    {
        _report = report;
        SectionId = sectionId;
    }

    [JsonConstructor]
    public Section(short sectionId)
    {
        _report = new();
        SectionId = sectionId;
    }

    public short SectionId { get; }

    public SectionTypes Type { get; set; }

    public byte Order { get; set; }

    public decimal Height { get; set; }

    [JsonIgnore]
    public ICollection<Line> Lines => [.. _report.Lines.Where(l => l.SectionId1 == SectionId || l.SectionId2 == SectionId)];

    [JsonIgnore]
    public ICollection<Rectangle> Rectangles => [.. _report.Rectangles.Where(r => r.SectionId1 == SectionId || r.SectionId2 == SectionId)];

    [JsonIgnore]
    public ICollection<Text> TextsNavigation => [.. _report.Texts.Where(t => t.SectionId == SectionId)];

    [JsonIgnore]
    public string DisplayName => $"{FriendlyNames.GetSectionType(Type)} - #{SectionId:00}";
}
