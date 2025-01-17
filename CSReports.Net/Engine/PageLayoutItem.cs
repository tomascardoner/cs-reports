using CSReports.Model;

namespace CSReports.Engine
{
    internal class PageLayoutItem
    {
        internal Section.SectionTypes SectionType { get; set; }
        internal int RowNumber { get; set; }
        internal decimal PositionYStart { get; set; }
        internal decimal PositionYEnd { get; set; }
    }
}