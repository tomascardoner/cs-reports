﻿namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Section
    {
        public enum SectionTypes : byte
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
}
