using UnityEngine;

namespace Manager
{
    public class PlayerManager : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private GameObject deathScreen;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject menuCanvas;

        #endregion
        
        #region METHODS

        public void Death()
        {
            deathScreen.SetActive(true);
            menuCanvas.SetActive(false);
            gameObject.SetActive(false);
            audioSource.volume = 0f;
            Time.timeScale = 0f;
        }

        #endregion
    }
}