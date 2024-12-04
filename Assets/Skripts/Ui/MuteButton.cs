using System;
using UnityEngine;
using Sound;

namespace Ui
{
    public class MuteButton : ParentButtons
    {
        [SerializeField] private MusicObject _musicObject;

        private bool isClicked;
    
        public event Action<bool> IsMuted;

        protected override void Click()
        {
            if (GetClicked() == true)
            {
                _musicObject.MuteOnGame();
                IsMuted?.Invoke(true);
            }
            else
            {
                _musicObject.PlayOnGame();
                IsMuted?.Invoke(false);
            }
        }

        private bool GetClicked()
        {
            return isClicked = !isClicked;
        }
    }
}