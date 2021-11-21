using UnityEngine;

namespace Manager
{
    public class SfxManager : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private float musicVolume = 1f;
#pragma warning restore 0649

        #endregion

        private void Update()
        {
            audioSource.volume = musicVolume;
        }
        
        public void UpdateVolume(float volume)
        {
            musicVolume = volume;
        }

    }
}