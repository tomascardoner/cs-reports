using System.ComponentModel.DataAnnotations.Schema;

namespace CSReports
{
    public partial class Report
    {
        public short ReportId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string TemplateFilename { get; set; } = string.Empty;

        public short? DatasourceId { get; set; }

        public byte PageSize { get; set; }

        [NotMapped]
        public PageSizes PageSizeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(PageSizes), PageSize))
                {
                    return (PageSizes)PageSize;
                }
                else
                {
                    return default;
                }
            }
        }

        public byte PageOrientation { get; set; }

        [NotMapped]
        public PageOrientations PageOrientationEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(PageOrientations), (int)PageOrientation))
                {
                    return (PageOrientations)PageOrientation;
                }
                else
                {
                    return default;
                }
            }
        }

        public decimal PageMarginTop { get; set; }

        public decimal PageMarginLeft { get; set; }

        public decimal PageMarginRight { get; set; }

        public decimal PageMarginBottom { get; set; }

        public short? SectionDetailMaxRows { get; set; }
    }
}