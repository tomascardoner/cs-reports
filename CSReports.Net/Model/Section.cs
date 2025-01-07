using CSReports.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSReports
{
    public partial class Section
    {
        public short ReportId { get; set; }

        public byte SectionId { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        public SectionTypes TipoEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(SectionTypes), Type))
                {
                    return (SectionTypes)Type;
                }
                else
                {
                    return default;
                }
            }
        }

        public byte Order { get; set; }

        public decimal Height { get; set; }

        public virtual Report ReportNavigation { get; set; }

        public virtual ICollection<Line> LinesNavigation { get; set; } = [];

        public virtual ICollection<Rectangle> RectanglesNavigation { get; set; } = [];

        public virtual ICollection<Text> TextsNavigation { get; set; } = [];
    }
}
