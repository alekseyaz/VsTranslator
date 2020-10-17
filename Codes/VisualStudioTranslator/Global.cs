using EnvDTE;

namespace VisualStudioTranslator
{
    public static class Global
    {
        public static DTE Dte = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(DTE)) as DTE;
    }
}