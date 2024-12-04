using UnityEngine;

namespace BarriersEntity
{
    public class IdentifyBarriersPrefab : MonoBehaviour
    {
        private const string ItemName = "ItemName";
       
        [SerializeField] private Barriers[] _barriers = new Barriers[4];

        public Barriers ReturnBarriers()
        {
            foreach (Barriers item in _barriers)
            {
                if (item.Id == PlayerPrefs.GetString(ItemName))
                {
                    return item;
                }
            }

            return _barriers[0];
        }
    }
}