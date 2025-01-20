namespace CardonerSistemas.Reports.Net.Engine
{
    internal class PageLayoutItem
    {
        internal Model.Section.SectionTypes SectionType { get; set; }
        internal int RowNumber { get; set; }
        internal decimal PositionYStart { get; set; }
        internal decimal PositionYEnd { get; set; }
    }
}