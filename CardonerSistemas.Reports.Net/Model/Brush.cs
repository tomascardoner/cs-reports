using PdfSharp.Drawing;
using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Brush
    {
        public Brush(Report report)
        {
            BrushId = (short)(report.Brushes.Max(b => b.BrushId) + 1);
        }

        [JsonConstructor]
        public Brush(short brushId)
        {
            BrushId = brushId;
        }

        public short BrushId {  get; }

        public BrushTypes Type { get; set; }

        public byte Color1Red { get; set; }

        public byte Color1Green { get; set; }

        public byte Color1Blue { get; set; }

        [JsonIgnore]
        public string Color1Hex => $"#{Color1Red:X2}{Color1Green:X2}{Color1Blue:X2}";

        [JsonIgnore]
        public XColor Color1 => XColor.FromArgb(Color1Red, Color1Green, Color1Blue);

        public byte? Color2Red { get; set; }

        public byte? Color2Green { get; set; }

        public byte? Color2Blue { get; set; }

        [JsonIgnore]
        public string Color2Hex => Color2Red.HasValue && Color2Green.HasValue && Color2Blue.HasValue
            ? $"#{Color2Red.Value:X2}{Color2Green.Value:X2}{Color2Blue.Value:X2}"
            : string.Empty;

        [JsonIgnore]
        public XColor Color2 => Color2Red.HasValue && Color2Green.HasValue && Color2Blue.HasValue
            ? XColor.FromArgb(Color2Red.Value, Color2Green.Value, Color2Blue.Value)
            : XColor.Empty;

        public decimal? PositionX1 { get; set; }

        public decimal? PositionY1 { get; set; }

        public XPoint Point1 => new((double)(PositionX1 ?? 0), (double)(PositionY1 ?? 0));

        public decimal? PositionX2 { get; set; }

        public decimal? PositionY2 { get; set; }

        public XPoint Point2 => new((double)(PositionX2 ?? 0), (double)(PositionY2 ?? 0));

        [JsonIgnore]
        public XRect Rectangle => new((double)(PositionX1 ?? 0), (double)(PositionY1 ?? 0), (double)(PositionX2 ?? 0), (double)(PositionY2 ?? 0));

        public XLinearGradientMode LinearGradientMode { get; set; }

        public decimal? RadiusStart { get; set; }

        public decimal? RadiusEnd { get; set; }
    }
}