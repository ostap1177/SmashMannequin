using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace UiView
{
    public class CostView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textOnButton;
        [SerializeField] private TMP_Text _textAd;
        [SerializeField] private UiBoard _uiBoard;

        public void SetText(int cost)
        {
            _textOnButton.text = cost.ToString();
            _textAd.text = cost.ToString();
        }

        public void EnableText(bool enable)
        {
            _textOnButton.enabled = enable;
        }

        public void EnableImage(bool enable)
        {
            _uiBoard.gameObject.SetActive(enable);
        }
    }
}