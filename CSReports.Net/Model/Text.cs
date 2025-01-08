﻿using System.Text.Json.Serialization;

namespace CSReports.Model
{
    public partial class Text
    {
        private readonly Report _Report;

        public Text(Report report)
        {
            _Report = report;
            TextId = (short)(report.Texts.Max(t => t.TextId) + 1);
        }

        public Text(Report report, short textId)
        {
            _Report = report;
            TextId = textId;
        }

        public short TextId { get; }

        public TextTypes TextType { get; set; }

        public FieldTypes? FieldType { get; set; }

        public string Value { get; set; } = string.Empty;

        public string Format { get; set; } = string.Empty;

        public short FontId { get; set; }

        public byte BorderColorRed { get; set; }

        public byte BorderColorGreen { get; set; }

        public byte BorderColorBlue { get; set; }

        public decimal BorderThickness { get; set; }

        public short BrushId { get; set; }

        public short SectionId { get; set; }

        public decimal PositionX { get; set; }

        public decimal PositionY { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public HorizontalAlignments HorizontalAlignment { get; set; }

        public VerticalAlignments VerticalAlignment { get; set; }

        public WordWrapTypes WordWrapType { get; set; }

        public decimal CharacterSpacing { get; set; }

        public decimal WordSpacing { get; set; }

        public decimal LineSpacing { get; set; }

        public SubSuperScripts SubSuperScript { get; set; }

        public decimal ParagraphIndent { get; set; }

        [JsonIgnore]
        public Brush? Brush => _Report.Brushes.FirstOrDefault(b => b.BrushId == BrushId);

        [JsonIgnore]
        public Section? Section => _Report.Sections.FirstOrDefault(s => s.SectionId == SectionId);

        [JsonIgnore]
        public Font? Font => _Report.Fonts.FirstOrDefault(f => f.FontId == FontId);
    }
}