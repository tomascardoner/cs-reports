using PdfSharp.Drawing;

namespace CardonerSistemas.Reports.Net;

public static class FriendlyNames
{
    public static string GetPageSize(Model.Report.PageSizes pageSize)
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

    public static string GetPageOrientation(Model.Report.PageOrientations pageOrientation)
    {
        return pageOrientation switch
        {
            Model.Report.PageOrientations.Portrait => Properties.Resources.StringPageOrientationPortrait,
            Model.Report.PageOrientations.Landscape => Properties.Resources.StringPageOrientationLandscape,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetDatasourceProvider(Model.Datasource.Providers provider)
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

    public static string GetDatasourceType(System.Data.CommandType type)
    {
        return type switch
        {
            System.Data.CommandType.Text => Properties.Resources.StringDatasourceTypeText,
            System.Data.CommandType.StoredProcedure => Properties.Resources.StringDatasourceTypeStoredProcedure,
            System.Data.CommandType.TableDirect => Properties.Resources.StringDatasourceTypeTableDirect,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetBrushType(Model.Brush.BrushTypes type)
    {
        return type switch
        {
            Model.Brush.BrushTypes.Solid => Properties.Resources.StringBrushTypeSolid,
            Model.Brush.BrushTypes.LinealGradient => Properties.Resources.StringBrushTypeLinealGradient,
            Model.Brush.BrushTypes.RadialGradient => Properties.Resources.StringBrushTypeRadialGradient,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetBrushLinearGradientMode(XLinearGradientMode mode)
    {
        return mode switch
        {
            XLinearGradientMode.Horizontal => Properties.Resources.StringBrushLinearGradientModeHorizontal,
            XLinearGradientMode.Vertical => Properties.Resources.StringBrushLinearGradientModeVertical,
            XLinearGradientMode.ForwardDiagonal => Properties.Resources.StringBrushLinearGradientModeForwardDiagonal,
            XLinearGradientMode.BackwardDiagonal => Properties.Resources.StringBrushLinearGradientModeBackwardDiagonal,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetSectionType(Model.Section.SectionTypes type)
    {
        return type switch
        {
            Model.Section.SectionTypes.ReportHeader => Properties.Resources.StringSectionTypeReportHeader,
            Model.Section.SectionTypes.PageHeader => Properties.Resources.StringSectionTypePageHeader,
            Model.Section.SectionTypes.GroupHeader => Properties.Resources.StringSectionTypeGroupHeader,
            Model.Section.SectionTypes.Detail => Properties.Resources.StringSectionTypeDetail,
            Model.Section.SectionTypes.GroupFooter => Properties.Resources.StringSectionTypeGroupFooter,
            Model.Section.SectionTypes.PageFooter => Properties.Resources.StringSectionTypePageFooter,
            Model.Section.SectionTypes.ReportFooter => Properties.Resources.StringSectionTypeReportFooter,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextType(Model.Text.TextTypes type)
    {
        return type switch
        {
            Model.Text.TextTypes.Static => Properties.Resources.StringTextTypeStatic,
            Model.Text.TextTypes.DatasourceField => Properties.Resources.StringTextTypeDatasourceField,
            Model.Text.TextTypes.DatasourceParameter => Properties.Resources.StringTextTypeDatasourceParameter,
            Model.Text.TextTypes.ReportParameter => Properties.Resources.StringTextTypeReportParameter,
            Model.Text.TextTypes.Formula => Properties.Resources.StringTextTypeFormula,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextTypeShort(Model.Text.TextTypes type)
    {
        return type switch
        {
            Model.Text.TextTypes.Static => Properties.Resources.StringTextTypeStatic,
            Model.Text.TextTypes.DatasourceField => Properties.Resources.StringTextTypeDatasourceFieldShort,
            Model.Text.TextTypes.DatasourceParameter => Properties.Resources.StringTextTypeDatasourceParameterShort,
            Model.Text.TextTypes.ReportParameter => Properties.Resources.StringTextTypeReportParameterShort,
            Model.Text.TextTypes.Formula => Properties.Resources.StringTextTypeFormula,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetValueType(Model.Value.Types type)
    {
        return type switch
        {
            Model.Value.Types.Text => Properties.Resources.StringValueTypeText,
            Model.Value.Types.Integer => Properties.Resources.StringValueTypeInteger,
            Model.Value.Types.Decimal => Properties.Resources.StringValueTypeDecimal,
            Model.Value.Types.DateTime => Properties.Resources.StringValueTypeDateTime,
            Model.Value.Types.YesNo => Properties.Resources.StringValueTypeYesNo,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextHorizontalAlignment(Model.Text.HorizontalAlignments horizontalAlignment)
    {
        return horizontalAlignment switch
        {
            Model.Text.HorizontalAlignments.Left => Properties.Resources.StringTextHorizontalAlignmentLeft,
            Model.Text.HorizontalAlignments.Center => Properties.Resources.StringTextHorizontalAlignmentCenter,
            Model.Text.HorizontalAlignments.Right => Properties.Resources.StringTextHorizontalAlignmentRight,
            Model.Text.HorizontalAlignments.Justify => Properties.Resources.StringTextHorizontalAlignmentJustify,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextVerticalAlignment(Model.Text.VerticalAlignments verticalAlignment)
    {
        return verticalAlignment switch
        {
            Model.Text.VerticalAlignments.Top => Properties.Resources.StringTextVerticalAlignmentTop,
            Model.Text.VerticalAlignments.Middle => Properties.Resources.StringTextVerticalAlignmentMiddle,
            Model.Text.VerticalAlignments.Bottom => Properties.Resources.StringTextVerticalAlignmentBottom,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextWordWrapType(Model.Text.WordWrapTypes type)
    {
        return type switch
        {
            Model.Text.WordWrapTypes.None => Properties.Resources.StringTextWordWrapTypeNone,
            Model.Text.WordWrapTypes.Word => Properties.Resources.StringTextWordWrapTypeWord,
            Model.Text.WordWrapTypes.WordOnly => Properties.Resources.StringTextWordWrapTypeWordOnly,
            Model.Text.WordWrapTypes.Character => Properties.Resources.StringTextWordWrapTypeCharacter,
            Model.Text.WordWrapTypes.DiscretionaryHyphen => Properties.Resources.StringTextWordWrapTypeDiscretionaryHyphen,
            _ => Properties.Resources.StringUndefined
        };
    }

    public static string GetTextSubSuperScript(Model.Text.SubSuperScripts subSuperScript)
    {
        return subSuperScript switch
        {
            Model.Text.SubSuperScripts.None => Properties.Resources.StringTextSubSuperScriptNone,
            Model.Text.SubSuperScripts.SuperScript => Properties.Resources.StringTextSubSuperScriptsSuperScript,
            Model.Text.SubSuperScripts.SubScript => Properties.Resources.StringTextSubSuperScriptsSubScript,
            _ => Properties.Resources.StringUndefined
        };
    }
}
