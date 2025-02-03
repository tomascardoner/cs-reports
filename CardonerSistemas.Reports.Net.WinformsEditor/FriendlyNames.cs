namespace CardonerSistemas.Reports.Net.WinformsEditor
{
    internal static class FriendlyNames
    {
        internal static string GetPageSize(Model.Report.PageSizes pageSize)
        {
            return pageSize switch
            {
                Model.Report.PageSizes.A0 => "A0",
                Model.Report.PageSizes.A1 => "A1",
                Model.Report.PageSizes.A2 => "A2",
                Model.Report.PageSizes.A3 => "A3",
                Model.Report.PageSizes.A4 => "A4",
                Model.Report.PageSizes.A5 => "A5",
                Model.Report.PageSizes.RA0 => "RA0",
                Model.Report.PageSizes.RA1 => "RA1",
                Model.Report.PageSizes.RA2 => "RA2",
                Model.Report.PageSizes.RA3 => "RA3",
                Model.Report.PageSizes.RA4 => "RA4",
                Model.Report.PageSizes.RA5 => "RA5",
                Model.Report.PageSizes.B0 => "B0",
                Model.Report.PageSizes.B1 => "B1",
                Model.Report.PageSizes.B2 => "B2",
                Model.Report.PageSizes.B3 => "B3",
                Model.Report.PageSizes.B4 => "B4",
                Model.Report.PageSizes.B5 => "B5",
                Model.Report.PageSizes.Quarto => "Quarto",
                Model.Report.PageSizes.Foolscap => "Foolscap",
                Model.Report.PageSizes.Executive => "Executive",
                Model.Report.PageSizes.GovernmentLetter => "Government Letter",
                Model.Report.PageSizes.Letter => "Letter",
                Model.Report.PageSizes.Legal => "Legal",
                Model.Report.PageSizes.Ledger => "Ledger",
                Model.Report.PageSizes.Tabloid => "Tabloid",
                Model.Report.PageSizes.Post => "Post",
                Model.Report.PageSizes.Crown => "Crown",
                Model.Report.PageSizes.LargePost => "Large Post",
                Model.Report.PageSizes.Demy => "Demy",
                Model.Report.PageSizes.Medium => "Medium",
                Model.Report.PageSizes.Royal => "Royal",
                Model.Report.PageSizes.Elephant => "Elephant",
                Model.Report.PageSizes.DoubleDemy => "Double Demy",
                Model.Report.PageSizes.QuadDemy => "Quad Demy",
                Model.Report.PageSizes.STMT => "STMT",
                Model.Report.PageSizes.Folio => "Folio",
                Model.Report.PageSizes.Statement => "Statement",
                Model.Report.PageSizes.Size10x14 => "10x14",
                _ => "Undefined"
            };
        }

        internal static string GetPageOrientation(Model.Report.PageOrientations pageOrientation)
        {
            return pageOrientation switch
            {
                Model.Report.PageOrientations.Portrait => Properties.Resources.StringPageOrientationPortrait,
                Model.Report.PageOrientations.Landscape => Properties.Resources.StringPageOrientationLandscape,
                _ => string.Empty
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
                _ => string.Empty
            };
        }

        internal static string GetDatasourceType(System.Data.CommandType type)
        {
            return type switch
            {
                System.Data.CommandType.Text => Properties.Resources.StringDatasourceTypeText,
                System.Data.CommandType.StoredProcedure => Properties.Resources.StringDatasourceTypeStoredProcedure,
                System.Data.CommandType.TableDirect => Properties.Resources.StringDatasourceTypeTableDirect,
                _ => string.Empty
            };
        }
    }
}
