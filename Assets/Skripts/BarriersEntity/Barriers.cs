using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BarrierEntity;
using Ui;

namespace BarriersEntity
{
    public class Barriers : MonoBehaviour
    {
        [SerializeField] private int _barriersStart = 0;
        [SerializeField] private string _id;

        private List<Barrier> _barriers = new List<Barrier>();

        private ScoreCounter _score;
        private Transform _placeTransform;
        private Transform _transform;
        private int _barrierIndex;
        private int _point;

        public int MaxCountBarriers => _barriers.Count;
        public int BarrierIndex => _barrierIndex;
        public string Id => _id;

        private void Awake()
        {
            _transform = transform;
            _barrierIndex = _barriersStart;

            if (_transform.parent.TryGetComponent(out ScoreCounter score))
            {
                _score = score;
            }

            foreach (Transform child in _transform)
            {
                if (child != null)
                {
                    if (child.TryGetComponent(out Barrier barrier))
                    {
                        _barriers.Add(barrier);
                    }
                }
            }

            ActiveToIndex(_barriersStart);
        }

        public void SetPlace(BarriersPlace barriersPlace)
        {
            _placeTransform = barriersPlace.transform;
        }

        public void ResetPlace()
        {
            _transform.position = _placeTransform.position;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public bool TryActiveToIndex(int index)
        {
            if (index < _barriers.Count)
            {
                ActiveToIndex(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPoints(int point)
        {
            _point += point;

            _score.AddPoints(point);
        }

        public void ControCollider(bool active)
        {
            _barriers.FirstOrDefault(p => p.gameObject.activeSelf == true).ControlColliders(active);
        }

        public void SetSpeed(int speed)
        {
            foreach (Barrier barrier in _barriers)
            {
                if (barrier != null && barrier.TryGetComponent(out BarrierRotator barrierTurn) 
                    && barrierTurn.gameObject.activeSelf == true)
                {
                    barrierTurn.SetSpeed(speed);
                }
            }
        }

        private void ActiveToIndex(int index)
        {
            Disable();
            _barrierIndex = index;
            _barriers[index].gameObject.SetActive(true);
        }

        private void Disable()
        {
            foreach (var barrier in _barriers)
            {
                barrier.gameObject?.SetActive(false);
            }
        }
    }
}