using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public List<string> _itemsBuy = new List<string>();

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
         
        public void SaveItem(string id)
        {
            if (_itemsBuy.Contains(id) == false)
            {
                _itemsBuy.Add(id);
            }
        }

        public string[] LoadItems()
        {
            return _itemsBuy.ToArray();
        }
    }
}
