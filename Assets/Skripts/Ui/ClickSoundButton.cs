using Ui;
using UnityEngine;

namespace Ui
{
    public class ClickSoundButton : ParentButtons
    {
        [Space(10)]
        [SerializeField] private AudioSource _audioSource;

        protected override void Click()
        {
            _audioSource.Stop();
            _audioSource.Play();
        }
    }
}