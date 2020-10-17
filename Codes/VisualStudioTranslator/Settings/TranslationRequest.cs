using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VisualStudioTranslator;
using VisualStudioTranslator.Entities;

namespace VisualStudioTranslator.Settings
{
    public class TranslationRequest
    {
        public event Action<TranslateResult> OnTranslationComplete;

        public event Action OnAllTranslationComplete;

        private readonly string _selectedText;

        private readonly List<Trans> _translators;

        private readonly Queue _completeQueue= new Queue();

        public TranslationRequest(string selectedText, List<Trans> translators)
        {
            _selectedText = selectedText;
            _translators = translators ?? new List<Trans>();

            foreach (Trans translator in _translators)
            {
                new Thread(TranslationThread).Start(translator);
            }
        }


        private async void TranslationThread(object obj)
        {
            Trans trans = obj as Trans;
            if (trans != null)
            {
                TranslationResult result = await trans.Translator.TranslateAsync(_selectedText, trans.SourceLanguage, trans.TargetLanguage);

                TranslateResult translateResult = JsonConvert.DeserializeObject<TranslateResult>(JsonConvert.SerializeObject(result));

                translateResult.Translator = trans.Translator;

                translateResult.Identity = trans.Translator.GetIdentity();
                OnTranslationComplete?.Invoke(translateResult);
            }
            lock (_completeQueue)
            {
                _completeQueue.Enqueue(1);
                if (_completeQueue.Count== _translators.Count)
                {
                    OnAllTranslationComplete?.Invoke();
                }
            }
        }
    }

    public class Trans
    {
        public ITranslatorAsync Translator { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }
    }

    public class TranslateResult : TranslationResult
    {
        public ITranslatorAsync Translator { get; set; }

        public string Identity { get; set; }
    }
}