using TMPro;
using UnityEngine;

namespace Localization
{
    public class LocalizationView : MonoBehaviour
    {
        private const string EnglishCode = "en";
        private const string RussianCode = "ru";
        private const string TurkishCode = "tr";
        private const string HindiCohe = "hi";

        [SerializeField] private TMP_Text _textRU;
        [SerializeField] private TMP_Text _textEN;
        [SerializeField] private TMP_Text _textTR;
        [SerializeField] private TMP_Text _textHI;

        public void View(string languageCode)
        {
            switch (languageCode)
            {
                case EnglishCode:
                    _textRU.enabled = false;
                    _textEN.enabled = true;
                    _textTR.enabled = false;
                    _textHI.enabled = false;
                    break;
                case RussianCode:
                    _textRU.enabled = true;
                    _textEN.enabled = false;
                    _textTR.enabled = false;
                    _textHI.enabled = false;
                    break;
                case TurkishCode:
                    _textRU.enabled = false;
                    _textEN.enabled = false;
                    _textTR.enabled = true;
                    _textHI.enabled = false;
                    break;
                case HindiCohe:
                    _textRU.enabled = false;
                    _textEN.enabled = false;
                    _textTR.enabled = false;
                    _textHI.enabled = true;
                    break;
            }
        }
    }
}