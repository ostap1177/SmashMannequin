using Entity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class OpenSceneButton : ParentButtons
    {
        [Space(10)]
        [SerializeField] private PauseObject _pauseObject;
        [SerializeField] private int _sceneNumber;

        protected override void Click()
        {
            SceneManager.LoadScene(_sceneNumber);
            _pauseObject.PlayGame();
        }
    }
}