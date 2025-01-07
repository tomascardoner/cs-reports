using CSReports.Model;
using System.ComponentModel.DataAnnotations.Schema;
using static CSReports.Text;

namespace CSReports
{
    public partial class Text
    {
        public short ReportId { get; set; }

        public short TextId { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        internal TextTypes TextTypeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(TextTypes), Type))
                {
                    return (TextTypes)Type;
                }
                else
                {
                    return default;
                }
            }
        }

        public byte? FieldType { get; set; }

        [NotMapped]
        internal FieldTypes FieldTypeEnumValue
        {
            get
            {
                if (FieldType.HasValue && Enum.IsDefined(typeof(FieldTypes), FieldType))
                {
                    return (FieldTypes)FieldType;
                }
                else
                {
                    return default;
                }
            }
        }

        public string Value { get; set; } = string.Empty;

        public string Format { get; set; } = string.Empty;

        public short FontId { get; set; }

        public byte BorderColorRed { get; set; }

        public byte BorderColorGreen { get; set; }

        public byte BorderColorBlue { get; set; }

        public decimal BorderThickness { get; set; }

        public short BrushId { get; set; }

        public byte SectionId { get; set; }

        public decimal PositionX { get; set; }

        public decimal PositionY { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public byte HorizontalAlignment { get; set; }

        [NotMapped]
        internal HorizontalAlignments HorizontalAlignmentEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(HorizontalAlignments), HorizontalAlignment))
                {
                    return (HorizontalAlignments)HorizontalAlignment;
                }
                else
                {
                    return default;
                }
            }
        }

        public byte VerticalAlignment { get; set; }

        [NotMapped]
        internal VerticalAlignments VerticalAlignmentEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(VerticalAlignments), VerticalAlignment))
                {
                    return (VerticalAlignments)VerticalAlignment;
                }
                else
                {
                    return default;
                }
            }
        }

        public byte WordWrapType { get; set; }

        [NotMapped]
        internal WordWrapTypes WordWrapTypeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(WordWrapTypes), WordWrapType))
                {
                    return (WordWrapTypes)WordWrapType;
                }
                else
                {
                    return default;
                }
            }
        }

        public decimal CharacterSpacing { get; set; }

        public decimal WordSpacing { get; set; }

        public decimal LineSpacing { get; set; }

        public byte SubSuperScript { get; set; }

        [NotMapped]
        internal SubSuperScripts SubSuperScriptEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(SubSuperScripts), SubSuperScript))
                {
                    return (SubSuperScripts)SubSuperScript;
                }
                else
                {
                    return default;
                }
            }
        }

        public decimal ParagraphIndent { get; set; }

        public virtual Report ReportNavigation { get; set; }

        public virtual Brush BrushNavigation { get; set; }

        public virtual Section SectionNavigation { get; set; }

        public virtual Font FontNavigation { get; set; }
    }
}
