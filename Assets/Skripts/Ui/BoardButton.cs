using UnityEngine;
using Entity;

namespace Ui
{
    public class BoardButton : ParentButtons
    {
        [Space(10)]
        [SerializeField] private UiBoard _uiBoard;
        [Space(10)]
        [SerializeField] private PauseObject _pauseObject;

        protected override void Click()
        {
            if (_uiBoard.gameObject.activeSelf == false)
            {
                _uiBoard.gameObject.SetActive(true);
                _pauseObject.PauseGame();
            }
            else
            {
                _pauseObject.PlayGame();
                _uiBoard.gameObject.SetActive(false);
            }
        }
    }
}