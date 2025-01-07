using System.ComponentModel.DataAnnotations.Schema;

namespace CSReports.Model
{
    public class Datasource
    {
        public short DatasourceId { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        internal System.Data.CommandType TypeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(System.Data.CommandType), Type))
                {
                    return (System.Data.CommandType)Type;
                }
                else
                {
                    return default;
                }
            }
        }

        public string Text { get; set; } = string.Empty;

        public virtual ICollection<Report> Reports { get; set; } = [];

        public virtual ICollection<DatasourceParameter> DatasourceParameters { get; set; } = [];

    }
}
