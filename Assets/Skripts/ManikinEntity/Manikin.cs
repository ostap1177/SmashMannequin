using System.Collections.Generic;
using UnityEngine;

namespace ManikinEntity
{
    public class Manikin : MonoBehaviour
    {
        [SerializeField] private int _healtPart = 10;
        [SerializeField] private int _waiteDestroy = 5;

        private List<ManikinPart> _manikinParts = new List<ManikinPart>();
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;

            CollectComponentsInChildren(_transform);

            Destroy(gameObject,_waiteDestroy);
        }

        private void CollectComponentsInChildren(Transform parent)
        {
            if (parent.TryGetComponent(out ManikinPart component))
            {
                component.SetHealth(_healtPart);
                _manikinParts.Add(component);
            }

            foreach (Transform child in parent)
            {
                CollectComponentsInChildren(child);
            }
        }
    }
}