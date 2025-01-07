using System.ComponentModel.DataAnnotations.Schema;

namespace CSReports.Model
{
    public class DatasourceParameter
    {
        public short DatasourceId { get; set; }

        public byte ParameterId { get; set; }

        public string Name { get; set; } = string.Empty;

        public byte Type { get; set; }

        [NotMapped]
        internal System.Data.SqlDbType TypeEnumValue
        {
            get
            {
                if (Enum.IsDefined(typeof(System.Data.SqlDbType), Type))
                {
                    return (System.Data.SqlDbType)Type;
                }
                else
                {
                    return default;
                }
            }
        }

        [NotMapped]
        public object? Value { get; set; }

        public virtual required Datasource DatasourceNavigation { get; set; }
    }
}