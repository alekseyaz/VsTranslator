using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using VisualStudioTranslator.Entities;
using VisualStudioTranslator.Google;
using MessageBox = System.Windows.Forms.MessageBox;

namespace VisualStudioTranslator.Settings
{
    /// <summary>
    /// Interaction logic for TranslateOptionsControl2.xaml
    /// </summary>
    public partial class TranslateOptions : Window
    {

        public Action<Settings> OnSave;

        public readonly Settings Settings;


        public TranslateOptions(Settings settings)
        {
            Settings = settings ?? new Settings();

            InitializeComponent();

            //Bind settings to views
            grid.DataContext = Settings;


            cbSourceLanguage.Items.Clear();
            cbTargetLanguage.Items.Clear();
            AppendLang2Control(GoogleTranslator.GetSourceLanguages(), GoogleTranslator.GetTargetLanguages());
            SetLanguageSelectedIndex(Settings.GoogleSettings);

        }


        private void btnSave_OnClick(object sender, RoutedEventArgs e)
        {
            OnSave?.Invoke(Settings);
            this.Close();
        }

        private void btnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open Letter spliter's dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpliter_OnClick(object sender, RoutedEventArgs e)
        {
            new LetterSpliter(OptionsSettings.Settings.LetterSpliters) { Owner = this, ShowInTaskbar = false }.ShowDialog();
        }

        private void SetLanguageSelectedIndex(TransSettings transSettings)
        {
            cbSourceLanguage.SelectedIndex = transSettings.SourceLanguageIndex;
            cbTargetLanguage.SelectedIndex = transSettings.TargetLanguageIndex;
        }

        private void AppendLang2Control(List<TranslationLanguage> sourceLanguages, List<TranslationLanguage> targetLanguages)
        {
            AppendLang2SourceLanguage(sourceLanguages);
            AppendLang2TargetLanguage(targetLanguages);
        }

        private void AppendLang2SourceLanguage(List<TranslationLanguage> langs)
        {
            foreach (TranslationLanguage translationLanguage in langs)
            {
                cbSourceLanguage.Items.Add(translationLanguage);
            }
        }

        private void AppendLang2TargetLanguage(List<TranslationLanguage> langs)
        {
            foreach (TranslationLanguage translationLanguage in langs)
            {
                cbTargetLanguage.Items.Add(translationLanguage);
            }
        }

        private void cbTargetLanguage_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TranslationLanguage lang = cbTargetLanguage.SelectedValue as TranslationLanguage;
            //lblLastLanguage.Text = lang?.Name;
            SetTargetLanguageIndex(GetTransSettings());
        }

        private void SetTargetLanguageIndex(TransSettings transSettings)
        {
            if (transSettings != null && cbTargetLanguage.SelectedIndex != transSettings.TargetLanguageIndex && cbTargetLanguage.SelectedIndex != -1)
            {
                transSettings.TargetLanguageIndex = cbTargetLanguage.SelectedIndex;
            }
        }

        private TransSettings GetTransSettings()
        {
            return Settings.GoogleSettings;
        }

        private void cbSourceLanguage_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetSourceLanguageIndex(GetTransSettings());
        }


        private void SetSourceLanguageIndex(TransSettings transSettings)
        {
            if (transSettings != null && cbSourceLanguage.SelectedIndex != transSettings.SourceLanguageIndex && cbSourceLanguage.SelectedIndex != -1)
            {
                transSettings.SourceLanguageIndex = cbSourceLanguage.SelectedIndex;
            }
        }

        private void cbAutoTranslate_Checked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CbTranslateResultModal_OnChecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CbTranslateResultOutput_OnChecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}