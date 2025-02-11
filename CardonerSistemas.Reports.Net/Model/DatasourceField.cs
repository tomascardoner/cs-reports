using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public class DatasourceField
    {

        public DatasourceField(Datasource datasource)
        {
            if (datasource.Fields.Count ==  0)
            {
                FieldId = 1;
            }
            else
            {
                FieldId = (short)(datasource.Fields.Max(f => f.FieldId) + 1);
            }
        }

        [JsonConstructor]
        public DatasourceField(short fieldId)
        {
            FieldId = fieldId;
        }

        public short FieldId { get; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public int Position { get; set; }

        public Type Type { get; set; } = typeof(object);

        [JsonIgnore]
        public string DataTypeName { get; set; } = string.Empty;

        [JsonIgnore]
        public bool Verified { get; set; }

    }
}