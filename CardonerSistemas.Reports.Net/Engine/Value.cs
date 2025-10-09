namespace CardonerSistemas.Reports.Net.Engine;

public static class Value
{
    public static Model.Value.Types GetTypeFromDbType(System.Data.DbType type)
    {
        return type switch
        {
            System.Data.DbType.String or System.Data.DbType.AnsiString or System.Data.DbType.AnsiStringFixedLength or System.Data.DbType.StringFixedLength or System.Data.DbType.Xml => Model.Value.Types.Text,
            System.Data.DbType.Boolean => Model.Value.Types.YesNo,
            System.Data.DbType.Byte or System.Data.DbType.SByte or System.Data.DbType.Int16 or System.Data.DbType.UInt16 or System.Data.DbType.Int32 or System.Data.DbType.UInt32 or System.Data.DbType.Int64 or System.Data.DbType.UInt64 or System.Data.DbType.VarNumeric => Model.Value.Types.Integer,
            System.Data.DbType.Single or System.Data.DbType.Double or System.Data.DbType.Decimal or System.Data.DbType.Currency => Model.Value.Types.Decimal,
            System.Data.DbType.Date or System.Data.DbType.Time or System.Data.DbType.DateTime or System.Data.DbType.DateTime2 or System.Data.DbType.DateTimeOffset => Model.Value.Types.DateTime,
            System.Data.DbType.Binary or System.Data.DbType.Guid or System.Data.DbType.Object => throw new NotImplementedException("The DbType is not supported."),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "The DbType is not supported."),
        };
    }
}
