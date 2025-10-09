namespace CardonerSistemas.Reports.Net.Model;

public partial class Section
{
    public enum SectionTypes
    {
        ReportHeader,
        PageHeader,
        GroupHeader,
        Detail,
        GroupFooter,
        PageFooter,
        ReportFooter
    }
}
