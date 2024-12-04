using System.Collections.Generic;
using UnityEngine;

namespace ManikinEntity
{
    public class ManikinPart : MonoBehaviour
    {
        private int _health = 10;

        private Transform _transform;
        private Joint _joint;
        private float _waiteDestroy = 10f;

        private void Awake()
        {
            _transform = transform;

            _joint = GetComponent<Joint>();
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public void TakeDamage(int damade)
        {
            if (_health > 0)
            {
                _health -= damade;
            }
            else
            {
                DisconnectPatr();
            }
        }

        private void DisconnectPatr()
        {
            if (_transform.parent != null && _joint != null)
            {
                Destroy(_joint);
                _transform.parent = null;
                Destroy(gameObject, _waiteDestroy);
            }
        }
    }
}