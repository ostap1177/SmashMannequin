using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private string _id;
        [Space(10)]
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Button _buyButton;
        [Space(10)]
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _yansImage;

        private string _idDefault = "red";
        private bool _isBuy = false;
        private bool _isActive;

        public string Id => _id;
        public bool IsBuy => _isBuy;
        public bool IsActive => _isActive;

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnActivate);
            _buyButton.onClick.AddListener(BuyPurchase);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnActivate);
            _buyButton.onClick.RemoveListener(BuyPurchase);
        }

        private void Awake()
        {
            if (_id != _idDefault)
            {
                _toggle.gameObject.SetActive(false);
                _toggle.isOn = false;
            }
            else
            {
                _buyButton.gameObject.SetActive(false);
            }

            if (_isBuy)
            {
                Purchase();
            }

            if (YandexGame.PurchaseByID(_id) != null)
            {
                _priceText.text = YandexGame.PurchaseByID(_id).priceValue;
            }

            StartCoroutine(YandexPurchaseSpriteHolder.Get(SetImage));
        }

        public void Purchase()
        {
            _isBuy = true;
            _buyButton.gameObject.SetActive(false);
            _toggle.gameObject.SetActive(true);

            Switch(true);
        }

        public void Switch(bool isActive)
        {
            _isActive = isActive;
            _toggle.isOn = isActive;
        }

        public void Refund()
        {
            _isBuy = false;
        }

        private void OnActivate(bool activate)
        {
            _isActive = _toggle.isOn;
        }

        private void SetImage(Sprite image)
        {
            _yansImage.sprite = image;
        }

        private void BuyPurchase()
        {
            YandexGame.BuyPayments(_id);
        }
    }
}