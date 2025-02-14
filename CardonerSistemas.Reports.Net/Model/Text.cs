using System.Text.Json.Serialization;
using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Text
    {
        private readonly Report _report;

        public Text(Report report)
        {
            _report = report;
            if (report.Texts.Count == 0)
            {
                TextId = 1;
            }
            else
            {
                TextId = (short)(report.Texts.Max(t => t.TextId) + 1);
            }
        }

        public Text(Report report, short textId)
        {
            _report = report;
            TextId = textId;
        }

        [JsonConstructor]
        public Text(short textId)
        {
            _report = new();
            TextId = textId;
        }

        public short TextId { get; }

        public TextTypes TextType { get; set; }

        public Value.Types? FieldType { get; set; }

        public string Value { get; set; } = string.Empty;

        public string Format { get; set; } = string.Empty;

        public short FontId { get; set; }

        public byte BorderColorRed { get; set; }

        public byte BorderColorGreen { get; set; }

        public byte BorderColorBlue { get; set; }

        [JsonIgnore]
        public XColor BorderColor => XColor.FromArgb(BorderColorRed, BorderColorGreen, BorderColorBlue);

        public decimal BorderThickness { get; set; }

        public short BrushId { get; set; }

        public short SectionId { get; set; }

        public decimal PositionX { get; set; }

        public decimal PositionY { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public HorizontalAlignments HorizontalAlignment { get; set; }

        [JsonIgnore]
        public XStringAlignment StringAlignment => (XStringAlignment)HorizontalAlignment;

        public VerticalAlignments VerticalAlignment { get; set; }

        [JsonIgnore]
        public XLineAlignment LineAlignment => (XLineAlignment)VerticalAlignment;

        public WordWrapTypes WordWrapType { get; set; }

        public decimal CharacterSpacing { get; set; }

        public decimal WordSpacing { get; set; }

        public decimal LineSpacing { get; set; }

        public SubSuperScripts SubSuperScript { get; set; }

        public decimal ParagraphIndent { get; set; }

        [JsonIgnore]
        public Brush? Brush => _report.Brushes.FirstOrDefault(b => b.BrushId == BrushId);

        [JsonIgnore]
        public Section? Section => _report.Sections.FirstOrDefault(s => s.SectionId == SectionId);

        [JsonIgnore]
        public Font? Font => _report.Fonts.FirstOrDefault(f => f.FontId == FontId);
    }
}
