using UnityEngine;
using Ad;
using Ui;
using UiView;


namespace Entity
{
    public abstract class EntityBuying : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private ButtonClicker _buttonClicker;
        [SerializeField] private CostView _costView;
        [SerializeField] private int _cost = 100;
        [SerializeField] private float _costMultiplier = 1.1f;
        [SerializeField] private AdReward _reward;
        [SerializeField] private int _idEntity;

        public int Cost => _cost;
        public ButtonClicker ButtonClicker => _buttonClicker;
        public CostView CostView => _costView;  
        public AdReward AdReward => _reward;

        public virtual void AdView(bool isView)
        {
            _costView.EnableText(!isView);
            _costView.EnableImage(isView);
        }

        protected abstract void EntityCreate();

        protected void OnCreate()
        {
            if (_scoreCounter.TryRemovePoint(_cost))
            {
                EntityCreate();
                ChangePrice();
            }
            else
            {
                _reward.Reward(_idEntity);
            }
        }

        protected void OnRewarded()
        {
            EntityCreate();
        }

        protected void ChangePrice()
        {
            float tempValue = (float)_cost * _costMultiplier;

            _cost = (int)tempValue;
            _costView.SetText(_cost);
        }
    }
}
