namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Text
    {
        public enum TextTypes : byte
        {
            Static,
            DatasourceField,
            DatasourceParameter,
            ReportParameter,
            Formula
        }
    }
}