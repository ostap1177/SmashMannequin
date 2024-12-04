using Shop;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ToggleControl : MonoBehaviour
    {
       [SerializeField] private Toggle[] _toggles;

        private void OnEnable()
        {
            foreach (Toggle toggle in _toggles)
            {
                toggle.onValueChanged.AddListener(on => SwitchAllToggle(toggle));
            }
        }

        private void OnDisable()
        {
            foreach (Toggle toggle in _toggles)
            {
                toggle.onValueChanged.RemoveAllListeners();
            }
        }

        private void SwitchAllToggle(Toggle selectToggle)
        {
            if (selectToggle.isOn == true)
            {
                foreach (var toggle in _toggles)
                {
                    if (toggle != selectToggle)
                    {
                        toggle.isOn = false;
                    }
                }
            }
        }
    }
}