namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Text
    {
        public enum TextTypes
        {
            Static,
            DatasourceField,
            DatasourceParameter,
            ReportParameter,
            Formula
        }
    }
}
