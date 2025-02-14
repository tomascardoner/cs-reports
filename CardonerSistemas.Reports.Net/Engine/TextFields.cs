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
                    Model.Value.Types.Text => field.Type switch
                    {
                        System.Data.DbType.AnsiString => dbDataReader.GetString(field.Position),
                        System.Data.DbType.String => dbDataReader.GetString(field.Position),
                        System.Data.DbType.AnsiStringFixedLength => dbDataReader.GetString(field.Position),
                        System.Data.DbType.StringFixedLength => dbDataReader.GetString(field.Position),
                        System.Data.DbType.Xml => dbDataReader.GetString(field.Position),
                        _ => string.Empty
                    },
                    Model.Value.Types.Integer => field.Type switch
                    {
                        System.Data.DbType.Byte => dbDataReader.GetByte(field.Position).ToString(text.Format),
                        System.Data.DbType.Int16 => dbDataReader.GetInt16(field.Position).ToString(text.Format),
                        System.Data.DbType.Int32 => dbDataReader.GetInt32(field.Position).ToString(text.Format),
                        System.Data.DbType.Int64 => dbDataReader.GetInt64(field.Position).ToString(text.Format),
                        System.Data.DbType.SByte => dbDataReader.GetByte(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt16 => dbDataReader.GetInt16(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt32 => dbDataReader.GetInt32(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt64 => dbDataReader.GetInt64(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.Decimal => field.Type switch
                    {
                        System.Data.DbType.Currency => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        System.Data.DbType.Decimal => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        System.Data.DbType.Double => dbDataReader.GetDouble(field.Position).ToString(text.Format),
                        System.Data.DbType.Single => dbDataReader.GetFloat(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.DateTime => field.Type switch
                    {
                        System.Data.DbType.Date => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTime => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.Time => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTime2 => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTimeOffset => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.YesNo => field.Type switch
                    {
                        System.Data.DbType.Boolean => dbDataReader.GetBoolean(field.Position) ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
                        _ => string.Empty
                    },
                    _ => string.Empty
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
