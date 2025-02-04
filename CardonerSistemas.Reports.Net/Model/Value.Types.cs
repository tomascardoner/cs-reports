namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Value
    {
        public enum Types : byte
        {
            Text,
            Integer,
            Decimal,
            DateTime,
            YesNo
        }
    }
}