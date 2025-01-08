using System.Text.Json.Serialization;

namespace CSReports.Model
{
    public class Rectangle
    {
        private readonly Report _Report;

        public Rectangle(Report report)
        {
            _Report = report;
            RectangleId = (short)(report.Rectangles.Max(r => r.RectangleId) + 1);
        }

        public Rectangle(Report report, short rectangleId)
        {
            _Report = report;
            RectangleId = rectangleId;
        }

        public short RectangleId { get; }

        public byte BorderColorRed { get; set; }

        public byte BorderColorGreen { get; set; }

        public byte BorderColorBlue { get; set; }

        public decimal BorderThickness { get; set; }

        public short? BrushId { get; set; }

        public byte SectionId1 { get; set; }

        public decimal PositionX1 { get; set; }

        public decimal PositionY1 { get; set; }

        public byte SectionId2 { get; set; }

        public decimal PosicionX2 { get; set; }

        public decimal PosicionY2 { get; set; }

        [JsonIgnore]
        public Brush? Brush => _Report.Brushes.FirstOrDefault(b => b.BrushId == BrushId);

        [JsonIgnore]
        public Section? Section1 => _Report.Sections.FirstOrDefault(s => s.SectionId == SectionId1);

        [JsonIgnore]
        public Section? Section2 => _Report.Sections.FirstOrDefault(s => s.SectionId == SectionId2);
    }
}