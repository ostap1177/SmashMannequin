using Entity;
using System;
using UnityEngine;
using YG;

namespace Ad
{
    public class AdReward : MonoBehaviour
    {
        [SerializeField] private PauseObject _pauseObject;

        public event Action DropedManikin;
        public event Action BuildedBarrier;
        public event Action BoostedBarrier;
        public event Action ErrorVideo;

        public void Reward(int idEntity)
        {
            Closed();

            YandexGame.RewVideoShow(idEntity);
            _pauseObject.PauseGame();

            Open();
        }

        private void OnErrorVideoEvent()
        {
            Closed();

            _pauseObject.PlayGame();
            ErrorVideo?.Invoke();
        }

        private void OnRewardVideoEvent(int id)
        {
            Closed();

            switch (id)
            {
                case 1:
                    DropedManikin?.Invoke();
                    break;
                case 2:
                    BuildedBarrier?.Invoke();
                    break;
                case 3:
                    BoostedBarrier?.Invoke();
                    break;
            }
        }

        private void Open()
        {
            YandexGame.ErrorVideoEvent += OnErrorVideoEvent;
            YandexGame.RewardVideoEvent += OnRewardVideoEvent;
        }

        private void Closed()
        {
            YandexGame.ErrorVideoEvent -= OnErrorVideoEvent;
            YandexGame.RewardVideoEvent -= OnRewardVideoEvent;

            ErrorVideo?.Invoke();
        }
    }
}