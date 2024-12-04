using UnityEngine;
using YG;

namespace Localization
{
    public class LocalizationSelect : MonoBehaviour
    {
        private const string English = "en";
        private const string Russian = "ru";
        private const string Turkish = "tr";
        private const string Hindi = "hi";

        [SerializeField] private LanguageDefinition _languageDefinition;

        private void Start()
        {
            ChangeLanguage(_languageDefinition.LoadLanguage());
        }

        public void ChangeLanguage(string languageCode)
        {
            switch (languageCode)
            {
                case English:
                    YandexGame.SwitchLanguage(English);
                    _languageDefinition.SaveLanguage(English);
                    break;
                case Russian:
                    YandexGame.SwitchLanguage(Russian);
                    _languageDefinition.SaveLanguage(Russian);
                    break;
                case Turkish:
                    YandexGame.SwitchLanguage(Turkish);
                    _languageDefinition.SaveLanguage(Turkish);
                    break;
                case Hindi:
                    YandexGame.SwitchLanguage(Hindi);
                    _languageDefinition.SaveLanguage(Hindi);
                    break;
            }
        }
    }
}