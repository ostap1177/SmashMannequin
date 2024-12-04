using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class SaveActiveItems : MonoBehaviour
    {
        private const string ItemName = "ItemName";

        [SerializeField] private List<ShopItem> _shopItem = new List<ShopItem>();

        private void OnDisable()
        {
            SeveActiveItem();
        }

        private void SeveActiveItem()
        {
            foreach (var item in _shopItem)
            {
                if (item.IsActive == true)
                {
                    PlayerPrefs.SetString(ItemName, item.Id);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
