namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    internal static class FriendlyNames
    {
        internal static string GetPageSize(Model.Report.PageSizes pageSize)
        {
            return pageSize switch
            {
                Model.Report.PageSizes.A0 => Properties.Resources.StringReportPageSizeA0,
                Model.Report.PageSizes.A1 => Properties.Resources.StringReportPageSizeA1,
                Model.Report.PageSizes.A2 => Properties.Resources.StringReportPageSizeA2,
                Model.Report.PageSizes.A3 => Properties.Resources.StringReportPageSizeA3,
                Model.Report.PageSizes.A4 => Properties.Resources.StringReportPageSizeA4,
                Model.Report.PageSizes.A5 => Properties.Resources.StringReportPageSizeA5,
                Model.Report.PageSizes.RA0 => Properties.Resources.StringReportPageSizeRA0,
                Model.Report.PageSizes.RA1 => Properties.Resources.StringReportPageSizeRA1,
                Model.Report.PageSizes.RA2 => Properties.Resources.StringReportPageSizeRA2,
                Model.Report.PageSizes.RA3 => Properties.Resources.StringReportPageSizeRA3,
                Model.Report.PageSizes.RA4 => Properties.Resources.StringReportPageSizeRA4,
                Model.Report.PageSizes.RA5 => Properties.Resources.StringReportPageSizeRA5,
                Model.Report.PageSizes.B0 => Properties.Resources.StringReportPageSizeB0,
                Model.Report.PageSizes.B1 => Properties.Resources.StringReportPageSizeB1,
                Model.Report.PageSizes.B2 => Properties.Resources.StringReportPageSizeB2,
                Model.Report.PageSizes.B3 => Properties.Resources.StringReportPageSizeB3,
                Model.Report.PageSizes.B4 => Properties.Resources.StringReportPageSizeB4,
                Model.Report.PageSizes.B5 => Properties.Resources.StringReportPageSizeB5,
                Model.Report.PageSizes.Quarto => Properties.Resources.StringReportPageSizeQuarto,
                Model.Report.PageSizes.Foolscap => Properties.Resources.StringReportPageSizeFoolscap,
                Model.Report.PageSizes.Executive => Properties.Resources.StringReportPageSizeExecutive,
                Model.Report.PageSizes.GovernmentLetter => Properties.Resources.StringReportPageSizeGovernmentLetter,
                Model.Report.PageSizes.Letter => Properties.Resources.StringReportPageSizeLetter,
                Model.Report.PageSizes.Legal => Properties.Resources.StringReportPageSizeLegal,
                Model.Report.PageSizes.Ledger => Properties.Resources.StringReportPageSizeLedger,
                Model.Report.PageSizes.Tabloid => Properties.Resources.StringReportPageSizeTabloid,
                Model.Report.PageSizes.Post => Properties.Resources.StringReportPageSizePost,
                Model.Report.PageSizes.Crown => Properties.Resources.StringReportPageSizeCrown,
                Model.Report.PageSizes.LargePost => Properties.Resources.StringReportPageSizeLargePost,
                Model.Report.PageSizes.Demy => Properties.Resources.StringReportPageSizeDemy,
                Model.Report.PageSizes.Medium => Properties.Resources.StringReportPageSizeMedium,
                Model.Report.PageSizes.Royal => Properties.Resources.StringReportPageSizeRoyal,
                Model.Report.PageSizes.Elephant => Properties.Resources.StringReportPageSizeElephant,
                Model.Report.PageSizes.DoubleDemy => Properties.Resources.StringReportPageSizeDoubleDemy,
                Model.Report.PageSizes.QuadDemy => Properties.Resources.StringReportPageSizeQuadDemy,
                Model.Report.PageSizes.STMT => Properties.Resources.StringReportPageSizeSTMT,
                Model.Report.PageSizes.Folio => Properties.Resources.StringReportPageSizeFolio,
                Model.Report.PageSizes.Statement => Properties.Resources.StringReportPageSizeStatement,
                Model.Report.PageSizes.Size10x14 => Properties.Resources.StringReportPageSizeSize10x14,
                _ => Properties.Resources.StringUndefined
            };
        }

        internal static string GetPageOrientation(Model.Report.PageOrientations pageOrientation)
        {
            return pageOrientation switch
            {
                Model.Report.PageOrientations.Portrait => Properties.Resources.StringPageOrientationPortrait,
                Model.Report.PageOrientations.Landscape => Properties.Resources.StringPageOrientationLandscape,
                _ => Properties.Resources.StringUndefined
            };
        }

        internal static string GetDatasourceProvider(Model.Datasource.Providers provider)
        {
            return provider switch
            {
                Model.Datasource.Providers.SqlServer => Properties.Resources.StringDatasourceProvidersSqlServer,
                Model.Datasource.Providers.OleDb => Properties.Resources.StringDatasourceProvidersOleDb,
                Model.Datasource.Providers.Odbc => Properties.Resources.StringDatasourceProvidersOdbc,
                Model.Datasource.Providers.Oracle => Properties.Resources.StringDatasourceProvidersOracle,
                Model.Datasource.Providers.DataSet => Properties.Resources.StringDatasourceProvidersDataSet,
                _ => Properties.Resources.StringUndefined
            };
        }

        internal static string GetDatasourceType(System.Data.CommandType type)
        {
            return type switch
            {
                System.Data.CommandType.Text => Properties.Resources.StringDatasourceTypeText,
                System.Data.CommandType.StoredProcedure => Properties.Resources.StringDatasourceTypeStoredProcedure,
                System.Data.CommandType.TableDirect => Properties.Resources.StringDatasourceTypeTableDirect,
                _ => Properties.Resources.StringUndefined
            };
        }
    }
}
