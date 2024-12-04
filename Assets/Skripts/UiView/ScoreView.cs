using TMPro;
using UnityEngine;
using Ui;

namespace UiView
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TMP_Text _scoreText;

        private void OnEnable()
        {
            _scoreCounter.TransferadPoints += OnTransferadPoints;
        }

        private void OnDisable()
        {
            _scoreCounter.TransferadPoints -= OnTransferadPoints;
        }

        private void OnTransferadPoints(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}