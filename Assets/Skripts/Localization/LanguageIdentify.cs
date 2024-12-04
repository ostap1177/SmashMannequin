using UnityEngine;
using YG;

namespace Localization
{
    public class LanguageIdentify : MonoBehaviour
    {
        [SerializeField] private LanguageDefinition _languageDefinition;

        private void Awake()
        {
            _languageDefinition.SaveLanguage(YandexGame.lang);
        }
    }
}