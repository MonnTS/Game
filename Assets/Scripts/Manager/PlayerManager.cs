using UnityEngine;

namespace Manager
{
    public class PlayerManager : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private GameObject deathScreen;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject menuCanvas;
#pragma warning restore 0649

        #endregion

        #region METHODS

        public void Death()
        {
            deathScreen.SetActive(true);
            menuCanvas.SetActive(false);
            audioSource.volume = 0f;
            Time.timeScale = 0f;
        }

        #endregion
    }
}