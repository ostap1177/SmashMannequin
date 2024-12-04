using UnityEngine;
using ManikinEntity;

namespace BarrierEntity
{
    [RequireComponent(typeof(Collider))]
    public class BarrierCollision : MonoBehaviour
    {
        [SerializeField] private Barrier _barrier;

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 contactPoint = contact.point;

            if (collision.gameObject.TryGetComponent(out ManikinPart manikinPart))
            {
                manikinPart.TakeDamage(_barrier.ApplyDamage(contactPoint));
            }
        }
    }
}
