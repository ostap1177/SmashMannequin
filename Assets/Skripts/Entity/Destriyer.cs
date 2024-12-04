using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entity
{
    public class Destriyer : MonoBehaviour
    {
        public event Action Destroed;

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
            Destroed?.Invoke();
        }
    }
}