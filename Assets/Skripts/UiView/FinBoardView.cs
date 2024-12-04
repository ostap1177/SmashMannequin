using TMPro;
using UnityEngine;
using Ui;

namespace UiView
{
    public class FinBoardView : MonoBehaviour
    {
        [SerializeField] private UiBoard _uiBoard;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TMP_Text _bestTime;
        [SerializeField] private TMP_Text _bestScore;

        private void OnEnable()
        {
            _scoreCounter.FinalizeTime += OnFinalizeTime;
        }

        private void OnDisable()
        {
            _scoreCounter.FinalizeTime -= OnFinalizeTime;
        }

        private void OnFinalizeTime(float minutes, float seconds, int bestScore)
        {
            _bestTime.text = string.Format("{00:00}:{01:00}", minutes, seconds);
            _bestScore.text = bestScore.ToString();
        }
    }
}