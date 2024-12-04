using TMPro;
using UnityEngine;
using DG.Tweening;

namespace CoinSpawn
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _coinText;
        [SerializeField] private SpriteRenderer _coinRenderer;

        private int _distance = 1;
        private int _duration = 2;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetText(string text)
        {
            _coinText.text = text;
        }

        public void StartAnimation()
        {
            _transform.DOMoveY(_transform.position.y + _distance, _duration);
            _coinRenderer.DOFade(0, _duration);
            _coinText.DOFade(0, _duration);
        }

        public void ResetFade()
        {
            _coinRenderer.DOFade(1, 0);
            _coinText.DOFade(1, 0);
        }
    }
}