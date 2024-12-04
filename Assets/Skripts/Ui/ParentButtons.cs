using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [RequireComponent(typeof(Button))]
    public abstract class ParentButtons : MonoBehaviour
    {
        private Button _button;

        protected void OnEnable()
        {
            _button.onClick.AddListener(Click);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveListener(Click);
        }

        protected void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected abstract void Click();
    }
}