using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class MusicObject : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        private string _mixerName = "MasteVolume";
        private int _minValue = -80;
        private int _maxValue = 0;

        private bool _isMuteInGame = false;

        public void PlayOnGame()
        {
            _isMuteInGame = false;
            Play();
        }

        public void MuteOnGame()
        {
            _isMuteInGame = true;
            Mute();
        }

        public void PlayOnFocus()
        {
            if (_isMuteInGame == false)
                Play();
        }

        public void MuteOnFocus()
        {
            Mute();
        }

        private void Play()
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, _maxValue);
        }

        private void Mute()
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, _minValue);
        }
    }
}