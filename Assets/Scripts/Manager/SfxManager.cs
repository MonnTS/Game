using UnityEngine;

namespace Manager
{
    public class SfxManager : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private AudioSource audioSource;

        [SerializeField] private float musicVolume = 1f;

        #endregion
        
        #region UNITYMETHODS

        private void Update()
        {
            audioSource.volume = musicVolume;
        }

        #endregion

        #region METHODS

        public void UpdateVolume(float volume)
        {
            musicVolume = volume;
        }

        #endregion
    }
}