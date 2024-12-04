using System;
using System.Collections.Generic;
using UnityEngine;

namespace BarrierEntity
{
    [RequireComponent(typeof(BarrierRotator))]

    public class Barrier : MonoBehaviour
    {
        private int _coin = 15;

        private int _damage = 5;
        private List<Collider> _colliders = new List<Collider>();
        private Transform _transform;

        public event Action<int, Vector3> CreateCoin;

        private void Awake()
        {
            _transform = transform;
            TakeColliders();
        }

        public void ControlColliders(bool active)
        {
            foreach (Collider collider in _colliders)
            {
                collider.enabled = active;
            }
        }

        public int ApplyDamage(Vector3 contactPoint)
        {
            CreateCoin?.Invoke(_coin, contactPoint);
            return _damage;
        }

        public void SetDamaga(int damage)
        {
            _damage = damage;
        }

        private void TakeColliders()
        {
            if (_transform.TryGetComponent(out Collider collider))
            {
                _colliders.Add(collider);
            }
            else if (_transform.childCount > 0)
            {
                foreach (Transform child in _transform)
                {
                    if (child.TryGetComponent(out collider))
                    {
                        _colliders.Add(collider);
                    }
                }
            }
        }
    }
}
