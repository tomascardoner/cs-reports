using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Section
    {
        private readonly Report _Report;

        public Section(Report report, SectionTypes type)
        {
            _Report = report;
            Type = type;
            SectionId = (short)(report.Sections.Where(s => s.Type == type).Max(s => s.SectionId) + 1);
        }

        public Section(Report report, SectionTypes type, short sectionId)
        {
            _Report = report;
            Type = type;
            SectionId = sectionId;
        }

        [JsonConstructor]
        public Section(SectionTypes type, short sectionId)
        {
            _Report = new();
            Type = type;
            SectionId = sectionId;
        }

        public short SectionId { get; }

        public SectionTypes Type { get; }

        public byte Order { get; set; }

        public decimal Height { get; set; }

        [JsonIgnore]
        public ICollection<Line> Lines => [.. _Report.Lines.Where(l => l.SectionId1 == SectionId || l.SectionId2 == SectionId)];

        [JsonIgnore]
        public ICollection<Rectangle> Rectangles => [.. _Report.Rectangles.Where(r => r.SectionId1 == SectionId || r.SectionId2 == SectionId)];

        [JsonIgnore]
        public ICollection<Text> TextsNavigation => [.. _Report.Texts.Where(t => t.SectionId == SectionId)];
    }
}