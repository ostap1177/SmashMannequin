using UnityEngine;

namespace BarriersEntity
{
    [RequireComponent(typeof(Rigidbody))]

    public class BarriersPlace : MonoBehaviour
    {
        private Barriers _barriersObject = null;
        public bool IsFilled => _barriersObject != null;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Barriers component) && IsFilled)
            {
                if (_barriersObject != component && component.BarrierIndex == _barriersObject.BarrierIndex)
                {
                    if (_barriersObject.TryActiveToIndex(_barriersObject.BarrierIndex + 1))
                    {
                        Destroy(component.gameObject);
                    }
                }
            }
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.TryGetComponent(out Barriers component) && _barriersObject == null)
            {
                _barriersObject = component;
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out Barriers component))
            {
                _barriersObject = null;
            }
        }

        public void SetBarriers(Barriers barriers)
        {
            barriers.SetPlace(this);
            _barriersObject = barriers;
        }

        private void DestroyBarrier(Barriers barriers)
        {
            if (transform.parent.TryGetComponent(out Switcher switcher))
            {
                switcher.RemoveActiveBarriers(barriers);
            }

            Destroy(barriers.gameObject);
        }
    }
}
