using System;
using System.Collections.Generic;
using System.IO;

namespace VisualStudioTranslator.Settings
{
    public class Settings
    {
        /// <summary>
        /// The index of translate service (Google, Bing, Baidu, Youdao)
        /// </summary>
        public int ServiceIndex { get; set; }

        public TransSettings GoogleSettings { get; set; }

        //public TransSettings BingSettings { get; set; }

        //public TransSettings BaiduSettings { get; set; }

        //public TransSettings YoudaoSettings { get; set; }

        public List<Spliter> LetterSpliters { get; set; }

        /// <summary>
        /// After the selected text is automatically translated
        /// </summary>
        public bool IsAutoTranslate { get; set; } = false;

        public bool IsEnabledFirstJudgeChinese { get; set; } = false;

        public int DelayMilliOfAutoTranslate { get; set; } = 300;


        public bool AfterTranslateSuccessedAutoCopy { get; set; } = true;

        public bool AfterOpenWindowAutoPasteAndTranslate { get; set; } = true;

        public TranslateResultShowType TranslateResultShowType { get; set; } = TranslateResultShowType.Modal;

        /// <summary>
        /// Get a Settings's instance with some default setting
        /// </summary>
        /// <returns></returns>
        public static Settings Instance()
        {
            return new Settings()
            {
                ServiceIndex = 1,
                //BaiduSettings = new TransSettings()
                //{
                //    AppClient = new AppClient() { AppKey = "", ClientSecret = "" },
                //    LastLanguageIndex = 2,
                //    SourceLanguageIndex = 0,
                //    TargetLanguageIndex = 0
                //},
                //BingSettings = new TransSettings()
                //{
                //    AppClient = new AppClient()
                //    {
                //        AppKey = "",
                //        ClientSecret = ""
                //    },
                //    LastLanguageIndex = 12,
                //    SourceLanguageIndex = 0,
                //    TargetLanguageIndex = 5
                //}
                //    ,
                //YoudaoSettings = new TransSettings()
                //{
                //    AppClient = new AppClient() { AppKey = "", ClientSecret = "" },
                //    LastLanguageIndex = 1,
                //    SourceLanguageIndex = 0,
                //    TargetLanguageIndex = 0
                //},
                GoogleSettings = new TransSettings()
                {
                    LastLanguageIndex = 12,
                    SourceLanguageIndex = 0,
                    TargetLanguageIndex = 6
                },
                LetterSpliters = new List<Spliter>()
                {
                    new Spliter()
                    {
                        Example = "MicrosoftTranslator",
                        MatchRegex = "([a-z])([A-Z])",
                        ReplaceRegex = "$1 $2"
                    },
                    new Spliter()
                    {
                        Example = "Microsoft_Translator",
                        MatchRegex = "_",
                        ReplaceRegex = " "
                    }
                },
                AfterTranslateSuccessedAutoCopy = true,
                AfterOpenWindowAutoPasteAndTranslate = true
            };
        }
    }

    public class TransSettings
    {
        public int SourceLanguageIndex { get; set; }

        public int TargetLanguageIndex { get; set; }

        public int LastLanguageIndex { get; set; }
    }

    public class Spliter
    {
        /// <summary>
        /// When splite text, this will used to Regular match 
        /// </summary>
        public string MatchRegex { get; set; }
        /// <summary>
        /// When splite text this will used to replace the match
        /// </summary>
        public string ReplaceRegex { get; set; }
        /// <summary>
        /// Test example
        /// </summary>
        public string Example { get; set; }
    }

    [Flags]
    public enum TranslateResultShowType
    {
        Modal = 1,

        Output = 2,

        All = Modal | Output,
    }
}