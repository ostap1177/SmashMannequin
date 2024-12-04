using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui
{
    public class DragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        private Camera mainCamera;
        private Vector3 offset;
        private bool isDragging;

        public event Action<bool> Dragging;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, 
                    eventData.position.y, mainCamera.WorldToScreenPoint(transform.position).z));
            offset = transform.position - worldPosition;

            isDragging = true;
            Dragging?.Invoke(isDragging);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isDragging)
            {
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x,
                        eventData.position.y, mainCamera.WorldToScreenPoint(transform.position).z));
                transform.position = worldPosition + offset;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
            Dragging?.Invoke(isDragging);
        }
    }
}