namespace CSReports.Model
{
    public class Rectangle
    {
        public short ReportId { get; set; }

        public short RectangleId { get; set; }

        public byte BorderColorRed { get; set; }

        public byte BorderColorGreen { get; set; }

        public byte BorderColorBlue { get; set; }

        public decimal BorderThikness { get; set; }

        public short? BrushId { get; set; }

        public byte SectionId1 { get; set; }

        public decimal PositionX1 { get; set; }

        public decimal PositionY1 { get; set; }

        public byte SectionId2 { get; set; }

        public decimal PosicionX2 { get; set; }

        public decimal PosicionY2 { get; set; }

        public virtual Report ReportNavigation { get; set; }

        public virtual Brush BrushNavigation { get; set; }

        public virtual Section Section1Navigation { get; set; }

        public virtual Section Section2Navigation { get; set; }
    }
}
