using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameTimer;
        [SerializeField] private TMP_Text _countdownTimer;

        private float _time = 0;
        private float _second = 1;

        private WaitForSeconds _waitForSeconds;

        public event Action ElapsedSecond;
        public event Action EndTime;

        public float SecondTime => _time;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_second);
        }

        private void Start()
        {
            StartCoroutine(Elapsed());
        }

        private void Update()
        {
            Display();
        }

        public void CountingDown(float secondTimer)
        {
            StartCoroutine(EndedTime(secondTimer));
        }

        private void Display()
        {
            _gameTimer.text = CountingTime();
        }

        private string CountingTime()
        {
            _time += Time.deltaTime;

            return FormatText(_time);
        }

        private string FormatText(float secondTime)
        {
            float minutes = Mathf.FloorToInt(secondTime / 60);
            float seconds = Mathf.FloorToInt(secondTime % 60);

            return string.Format("{00:00}:{01:00}", minutes, seconds);
        }

        private IEnumerator<WaitForSeconds> Elapsed()
        {
            while (true)
            {
                yield return _waitForSeconds;
                ElapsedSecond?.Invoke();
            }
        }

        private IEnumerator<WaitForSeconds> EndedTime(float secondTimer)
        {
            _countdownTimer.enabled = true;

            while (secondTimer > 0)
            {
                _countdownTimer.text = FormatText(secondTimer);
                secondTimer -= _second;

                yield return _waitForSeconds;
            }

            _countdownTimer.enabled = false;

            EndTime?.Invoke();
        }
    }
}