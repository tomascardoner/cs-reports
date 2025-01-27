using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;
using System.Data;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class TextFields
    {
        internal static string GetValue(Model.Text text, DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            ArgumentNullException.ThrowIfNull(text);

            if (text.FieldType is null || dbDataReader is null)
            {
                return string.Empty;
            }
            if (!fieldsOrdinals.TryGetValue(text.Value, out int fieldIndex))
            {
                return string.Empty;
            }
            if (dbDataReader.IsDBNull(fieldIndex))
            {
                return string.Empty;
            }

            string dataTypeName = dbDataReader.GetDataTypeName(fieldIndex);
            try
            {
                return text.FieldType switch
                {
                    Model.Text.FieldTypes.Text => dataTypeName switch
                    {
                        //"char" => dbDataReader.GetChars(fieldIndex).ToSqlString().Value,
                        "varchar" => dbDataReader.GetString(fieldIndex),
                        _ => string.Empty,
                    },
                    Model.Text.FieldTypes.Integer => dataTypeName switch
                    {
                        "bigint" => dbDataReader.GetInt64(fieldIndex).ToString(text.Format),
                        "int" => dbDataReader.GetInt32(fieldIndex).ToString(text.Format),
                        "smallint" => dbDataReader.GetInt16(fieldIndex).ToString(text.Format),
                        "tinyint" => dbDataReader.GetByte(fieldIndex).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Text.FieldTypes.Decimal => dataTypeName switch
                    {
                        "decimal" => dbDataReader.GetDecimal(fieldIndex).ToString(text.Format),
                        "money" => dbDataReader.GetDecimal(fieldIndex).ToString(text.Format),
                        "smallmoney" => dbDataReader.GetDecimal(fieldIndex).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Text.FieldTypes.DateTime => dataTypeName switch
                    {
                        "datetime" => dbDataReader.GetDateTime(fieldIndex).ToString(text.Format),
                        "smalldatetime" => dbDataReader.GetDateTime(fieldIndex).ToString(text.Format),
                        "date" => dbDataReader.GetDateTime(fieldIndex).ToString(text.Format),
                        "time" => dbDataReader.GetDateTime(fieldIndex).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Text.FieldTypes.YesNo => dataTypeName switch
                    {
                        "bit" => dbDataReader.GetBoolean(fieldIndex) ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
                        _ => string.Empty,
                    },
                    _ => string.Empty,
                };
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233033)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
                return string.Empty;
            }
        }
    }
}
