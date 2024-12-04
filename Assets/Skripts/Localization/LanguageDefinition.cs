using UnityEngine;

namespace Localization
{
    public class LanguageDefinition : MonoBehaviour
    {
        private const string LanguageCode = "LanguageCode";

        public void SaveLanguage(string language)
        {
            PlayerPrefs.SetString(LanguageCode, language);
            PlayerPrefs.Save();
        }

        public string LoadLanguage()
        {
            return PlayerPrefs.GetString(LanguageCode);
        }
    }
}