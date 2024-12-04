using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entity;

namespace BarriersEntity
{
    public class Switcher : EntityBuying
    {
        [Space(10)]
        [SerializeField] private int _countBarriersStart = 6;
        [SerializeField] private Barriers _barriersPrefab;
        [Space(10)]
        [SerializeField] private IdentifyBarriersPrefab _identifyBarriersPrefab;

        private List<BarriersPlace> _places = new List<BarriersPlace>();
        private List<Barriers> _activeBarriers = new List<Barriers>();
        private Transform _transform;

        public int BarrierCost => Cost;

        private void OnEnable()
        {
            ButtonClicker.BuildedBarriers += this.OnCreate;
            AdReward.BuildedBarrier += OnRewarded;
        }

        private void OnDisable()
        {
            ButtonClicker.BuildedBarriers -= this.OnCreate;
            AdReward.BuildedBarrier -= OnRewarded;
        }

        private void Awake()
        {
            _transform = transform;
            CostView.SetText(BarrierCost);

            foreach (Transform child in _transform)
            {
                if (child.TryGetComponent(out BarriersPlace barriersPlace))
                {
                    _places.Add(barriersPlace);
                }
            }

            if (_countBarriersStart > _places.Count)
            {
                _countBarriersStart = _places.Count;
            }
        }

        private void Start()
        {
            for (int i = 0; i < _countBarriersStart; i++)
            {
                EntityCreate();
            }
        }

        public void SetSpeedActiveBarriers(int speed)
        {
            foreach (Barriers barriers in _activeBarriers)
            {
                if (barriers != null)
                {
                    barriers.SetSpeed(speed);
                }
            }
        }

        public void RemoveActiveBarriers(Barriers barriers)
        {
            _activeBarriers.Remove(barriers);
        }

        protected override void EntityCreate()
        {
            if (_places.Count(place => place.IsFilled == false) > 0)
            {
                BarriersPlace tempPlace = _places.FirstOrDefault(place => 
                                                                 place.IsFilled == false);
                Barriers barriers = Instantiate(_identifyBarriersPrefab.ReturnBarriers(), 
                         tempPlace.transform.position, Quaternion.identity, _transform);

                tempPlace.SetBarriers(barriers);
                _activeBarriers.Add(barriers);
            }
        }
    }
}
