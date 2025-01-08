using System.Drawing;
using System.Text.Json.Serialization;

namespace CSReports.Model
{
    public class Font
    {
        public Font(Report report)
        {
            FontId = (short)(report.Fonts.Max(f => f.FontId) + 1);
        }

        public Font(short fontId)
        {
            FontId = fontId;
        }

        public short FontId { get; }

        public string Name { get; set; } = string.Empty;

        public decimal Size { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public bool Strikethrough { get; set; }

        [JsonIgnore]
        internal FontStyle Style
        {
            get
            {
                FontStyle fontStyle = new();
                if (Bold)
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
    }
}