using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ButtonClicker : MonoBehaviour
    {
        [SerializeField] private Button _buildedBarriers;
        [SerializeField] private Button _dropedManikin;
        [SerializeField] private Button _boostedBarriers;

        public event Action BuildedBarriers;
        public event Action DropedManikin;
        public event Action BarriersBoosted;

        private void OnEnable()
        {
            _buildedBarriers.onClick.AddListener(BuildBarriers);
            _dropedManikin.onClick.AddListener(DropManikin);
            _boostedBarriers.onClick.AddListener(BoostBarriers);
        }

        private void OnDisable()
        {
            _buildedBarriers.onClick.RemoveListener(BuildBarriers);
            _dropedManikin.onClick.RemoveListener(DropManikin);
            _boostedBarriers.onClick.RemoveListener(BoostBarriers);
        }

        public void DropManikin()
        {
            DropedManikin?.Invoke();
        }

        public void BuildBarriers()
        {
            BuildedBarriers?.Invoke();
        }

        public void BoostBarriers()
        {
            BarriersBoosted?.Invoke();
        }
    }
}