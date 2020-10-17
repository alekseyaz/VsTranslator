using System;
using System.Text.RegularExpressions;
using VisualStudioTranslator;
using VisualStudioTranslator.Google;

namespace VisualStudioTranslator.Settings
{
    public class TranslatorFactory
    {

        public static string GetSourceLanguage(TranslateType type, string selectedText)
        {
            return GoogleTranslator.GetSourceLanguages()[OptionsSettings.Settings.GoogleSettings.SourceLanguageIndex].Code;
        }

        public static string GetTargetLanguage(TranslateType type, string selectedText)
        {
            return GoogleTranslator.GetTargetLanguages()[OptionsSettings.Settings.GoogleSettings.TargetLanguageIndex].Code;
        }

        public static ITranslatorAsync GetTranslator(TranslateType type)
        {
            return new GoogleTranslator();
        }

    }
}