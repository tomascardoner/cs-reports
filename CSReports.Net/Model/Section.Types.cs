namespace CSReports
{
    public partial class Section
    {
        public enum SectionTypes : byte
        {
            reportHeader,
            PageHeader,
            GroupHeader,
            Detail,
            GroupFooter,
            PageFooter,
            ReportFooter
        }
    }
}
