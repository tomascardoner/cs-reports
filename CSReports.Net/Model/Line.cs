namespace CSReports.Model
{
    public class Line
    {
        public short ReportId { get; set; }

        public short LineId { get; set; }

        public byte ColorRed { get; set; }

        public byte ColorGreen { get; set; }

        public byte ColorBlue { get; set; }

        public decimal Thikness { get; set; }

        public byte SectionId1 { get; set; }

        public decimal PositionX1 { get; set; }

        public decimal PositionY1 { get; set; }

        public byte SectionId2 { get; set; }

        public decimal PosicionX2 { get; set; }

        public decimal PosicionY2 { get; set; }

        public virtual Report ReportNavigation { get; set; }

        public virtual Section Section1Navigation { get; set; }

        public virtual Section Section2Navigation { get; set; }

    }
}
