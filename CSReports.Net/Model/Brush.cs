using CSReports.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSReports
{
    public partial class Brush
    {
        public short ReportId { get; set; }

        public short BrushId { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        internal BrushTypes TypeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(BrushTypes), Type))
                {
                    return (BrushTypes)Type;
                }
                else
                {
                    return default;
                }
            }
        }

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

        public virtual Report ReportNavigation { get; set; }

        public virtual ICollection<Rectangle> Rectangles { get; set; } = [];

        public virtual ICollection<Text> Texts { get; set; } = [];
    }
}
