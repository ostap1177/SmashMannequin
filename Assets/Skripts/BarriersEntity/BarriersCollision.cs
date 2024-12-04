using UnityEngine;
using Ui;

namespace BarriersEntity
{
    [RequireComponent(typeof(Barriers))]

    public class BarriersCollision : MonoBehaviour
    {
        [SerializeField] private DragHandler _clickHandlerNew;
        private Barriers _barriersObject;
        private bool _isDraging;

        public bool IsDraging => _isDraging;

        private void OnEnable()
        {
            _clickHandlerNew.Dragging += OnDragging;
        }

        private void OnDisable()
        {
            _clickHandlerNew.Dragging -= OnDragging;
        }

        private void Awake()
        {
            _barriersObject = GetComponent<Barriers>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BarriersPlace component) && component.IsFilled == false)
            {
                _barriersObject.SetPlace(component);
            }
        }

        private void OnDragging(bool drag)
        {
            _isDraging = drag;
            _barriersObject.ControCollider(!drag);

            if (drag == false)
            {
                _barriersObject.ResetPlace();
            }
        }
    }
}
