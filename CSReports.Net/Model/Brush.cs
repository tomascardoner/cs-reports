namespace CSReports.Model
{
    public partial class Brush
    {
        public Brush(Report report)
        {
            BrushId = (short)(report.Brushes.Max(b => b.BrushId) + 1);
        }

        public Brush(short brushId)
        {
            BrushId = brushId;
        }

        public short BrushId {  get; }

        public BrushTypes Type { get; set; }

        public byte Color1Red { get; set; }

        public byte Color1Green { get; set; }

        public byte Color1Blue { get; set; }

        public byte? Color2Red { get; set; }

        public byte? Color2Green { get; set; }

        public byte? Color2Blue { get; set; }

        public decimal? PositionX1 { get; set; }

        public decimal? PositionY1 { get; set; }

        public decimal? PositionX2 { get; set; }

        public decimal? PositionY2 { get; set; }

        public decimal? Angle { get; set; }

        public decimal? RadiusStart { get; set; }

        public decimal? RadiusEnd { get; set; }
    }
}
