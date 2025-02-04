using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class TextFields
    {
        internal static string GetValue(Model.Text text, DbDataReader? dbDataReader, Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(text);

            if (text.FieldType is null || dbDataReader is null)
            {
                return string.Empty;
            }
            Model.DatasourceField? field = datasource.Fields.FirstOrDefault(f => f.Name == text.Value);
            if (field is null)
            {
                return string.Empty;
            }
            if (dbDataReader.IsDBNull(field.Position))
            {
                return string.Empty;
            }

            try
            {
                return text.FieldType switch
                {
                    Model.Value.Types.Text => field.DataTypeName switch
                    {
                        //"char" => dbDataReader.GetChars(field.Position).ToSqlString().Value,
                        "varchar" => dbDataReader.GetString(field.Position),
                        _ => string.Empty,
                    },
                    Model.Value.Types.Integer => field.DataTypeName switch
                    {
                        "bigint" => dbDataReader.GetInt64(field.Position).ToString(text.Format),
                        "int" => dbDataReader.GetInt32(field.Position).ToString(text.Format),
                        "smallint" => dbDataReader.GetInt16(field.Position).ToString(text.Format),
                        "tinyint" => dbDataReader.GetByte(field.Position).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Value.Types.Decimal => field.DataTypeName switch
                    {
                        "decimal" => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        "money" => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        "smallmoney" => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Value.Types.DateTime => field.DataTypeName switch
                    {
                        "datetime" => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        "smalldatetime" => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        "date" => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        "time" => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        _ => string.Empty,
                    },
                    Model.Value.Types.YesNo => field.DataTypeName switch
                    {
                        "bit" => dbDataReader.GetBoolean(field.Position) ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
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
