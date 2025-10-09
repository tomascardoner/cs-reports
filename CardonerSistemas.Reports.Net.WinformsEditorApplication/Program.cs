using System.Reflection;

namespace CardonerSistemas.Reports.Net.WinformsEditorApplication;

internal static class Program
{
    internal static readonly Framework.Base.Application.Info ApplicationInfo = new(Assembly.GetExecutingAssembly());
    internal const string OptionsFileName = "Options.json";
#pragma warning disable S2223 // Non-constant static fields should not be visible
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    internal static OptionsConfig s_options;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore S2223 // Non-constant static fields should not be visible

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if (!Framework.Base.Configuration.Json.LoadFile(string.Empty, OptionsFileName, ref s_options, true))
        {
            s_options = new();
        }

        Application.Run(new FormMdi());
    }
}
