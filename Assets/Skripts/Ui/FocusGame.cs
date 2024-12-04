using UnityEngine;
using Entity;
using Sound;

namespace Ui
{
    public class FocusGame : MonoBehaviour
    {
        [SerializeField] private MusicObject _musicObject;
        [Space(10)]
        [SerializeField] private PauseObject _pauseObject;

        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                _pauseObject.FocusReturn();
                _musicObject.PlayOnFocus();
            }
            else
            {
                _pauseObject.FocusLose();
                _musicObject.MuteOnFocus();
            }
        }
    }
}