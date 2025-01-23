using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Report
    {
        public Report() {
            ReportId = Guid.NewGuid();
        }

        [JsonConstructor]
        public Report(Guid reportId)
        {
            ReportId = reportId;
        }

        public Guid ReportId { get; }

        public string Name { get; set; } = string.Empty;

        public string TemplateFilename { get; set; } = string.Empty;

        public PageSizes PageSize { get; set; }

        public PageOrientations PageOrientation { get; set; }

        public decimal PageMarginTop { get; set; }

        public decimal PageMarginLeft { get; set; }

        public decimal PageMarginRight { get; set; }

        public decimal PageMarginBottom { get; set; }

        public short? DetailSectionMaxRowCount { get; set; }

        public Datasource? Datasource { get; set; }

        public ICollection<Section> Sections { get; set; } = [];
        
        public ICollection<Font> Fonts { get; set; } = [];

        public ICollection<Brush> Brushes { get; set; } = [];

        public ICollection<Line> Lines { get; set; } = [];

        public ICollection<Rectangle> Rectangles { get; set; } = [];

        public ICollection<Text> Texts { get; set; } = [];
    }
}