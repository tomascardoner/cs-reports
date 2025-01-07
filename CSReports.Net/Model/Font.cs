using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CSReports.Model
{
    public class Font
    {
        public short ReportId { get; set; }

        public short FontId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Size { get; set; }

        public bool Boold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public bool Strikethrough { get; set; }

        [NotMapped]
        internal FontStyle Style
        {
            get
            {
                FontStyle fontStyle = new();
                if (Boold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (Italic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (Underline)
                {
                    fontStyle |= FontStyle.Underline;
                }
                if (Strikethrough)
                {
                    fontStyle |= FontStyle.Strikeout;
                }
                return fontStyle;
            }
        }


        public virtual Report ReportNavigation { get; set; }

        public virtual ICollection<Text> Texts { get; set; } = new List<Text>();
    }
}