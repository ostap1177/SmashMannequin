using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using YG;

namespace Shop
{
    public class YandexPurchaseSpriteHolder
    {
        private static Sprite _sprite;
        private static bool _isLoading;

        public static IEnumerator Get(Action<Sprite> successCallback)
        {
            if (_sprite != null)
            {
                successCallback?.Invoke(_sprite);
                yield break;
            }

            if (_isLoading)
            {
                yield return new WaitUntil(() => _sprite != null);
                successCallback?.Invoke(_sprite);
                yield break;
            }

            _isLoading = true;

            string url = YandexGame.purchases[0].currencyImageURL;
            Debug.Log(url);

            if (string.IsNullOrEmpty(url))
            {
                yield break;
            }

            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                    webRequest.result == UnityWebRequest.Result.DataProcessingError)
                {
                    Debug.LogError($"Loading icon error");
                }
                else
                {
                    DownloadHandlerTexture handlerTexture = webRequest.downloadHandler as DownloadHandlerTexture;
                    _sprite = Sprite.Create((Texture2D)handlerTexture.texture,
                    new Rect(0, 0, handlerTexture.texture.width, handlerTexture.texture.height), Vector2.zero);
                }
            }

            successCallback?.Invoke(_sprite);
        }

        public static IEnumerator Get(PurchaseYG purchaseYG, Action<Sprite> successCallback)
        {
            if (_sprite != null)
            {
                successCallback?.Invoke(_sprite);
                yield break;
            }

            if (_isLoading)
            {
                yield return new WaitUntil(() => _sprite != null);
                successCallback?.Invoke(_sprite);
                yield break;
            }

            _isLoading = true;

            string url = purchaseYG.data.currencyImageURL;
            Debug.Log(url);

            if (string.IsNullOrEmpty(url))
            {
                yield break;
            }

            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                    webRequest.result == UnityWebRequest.Result.DataProcessingError)
                {
                    Debug.LogError($"Loading icon error");
                }
                else
                {
                    DownloadHandlerTexture handlerTexture = webRequest.downloadHandler as DownloadHandlerTexture;
                    _sprite = Sprite.Create((Texture2D)handlerTexture.texture,
                        new Rect(0, 0, handlerTexture.texture.width, handlerTexture.texture.height), Vector2.zero);
                }
            }

            successCallback?.Invoke(_sprite);
        }
    }
}