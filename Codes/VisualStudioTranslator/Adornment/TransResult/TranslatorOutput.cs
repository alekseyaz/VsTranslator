﻿using VisualStudioTranslator.Translator.Enums;
using VisualStudioTranslator.Core.Utils;
using VisualStudioTranslator.Settings;

namespace VisualStudioTranslator.Adornment.TransResult
{
    public class TranslatorOutput
    {
        public TranslatorOutput(TranslationRequest transRequest)
        {
            transRequest.OnTranslationComplete += TransRequest_OnTranslationComplete; ;

            transRequest.OnAllTranslationComplete += TransRequest_OnAllTranslationComplete; ;
        }

        private void TransRequest_OnAllTranslationComplete()
        {
          
        }

        private void TransRequest_OnTranslationComplete(TranslateResult translationResult)
        {
            var lang = $"[{translationResult.Identity}]({translationResult.SourceLanguage} - {translationResult.TargetLanguage})";
            Output.OutputString(translationResult.TranslationResultTypes == TranslationResultTypes.Successed
                ? $"{lang}\r\n{translationResult.TargetText}"
                : translationResult.FailedReason);
        }
    }
}