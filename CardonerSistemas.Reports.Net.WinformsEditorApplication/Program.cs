using System.Reflection;

namespace CardonerSistemas.Reports.Net.WinformsEditorApplication
{
    internal static class Program
    {
        internal static readonly Framework.Base.Application.Info s_applicationInfo = new(Assembly.GetExecutingAssembly());

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMdi());
        }
    }
}
