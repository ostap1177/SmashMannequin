using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace InitializYG
{
    public class InitializSDK : MonoBehaviour
    {
        private static readonly int SceneNumber = 1;

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= OnInitialized;
        }

        private void Awake()
        {
            if (YandexGame.SDKEnabled == true)
            {
                OnInitialized();
            }
            else
            {
                YandexGame.GetDataEvent += OnInitialized;
            }
        }

        private void OnInitialized()
        {
            if (YandexGame.SDKEnabled == true)
            {
                YandexGame.GameReadyAPI();
                SceneManager.LoadScene(SceneNumber);
            }
        }
    }
}