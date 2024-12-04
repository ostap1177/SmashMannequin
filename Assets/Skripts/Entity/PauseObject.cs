using UnityEngine;

namespace Entity
{
    public class PauseObject : MonoBehaviour
    {
        private bool _isPaused;

        public void PauseGame()
        {
            Time.timeScale = 0f;
            _isPaused = true;
        }

        public void PlayGame()
        {
            Time.timeScale = 1f;
            _isPaused = false;
        }

        public void FocusLose()
        {
            Time.timeScale = 0f;
        }

        public void FocusReturn()
        {
            if (_isPaused == false)
            {
                Time.timeScale = 1f;
            }
        }
    }
}