using UnityEngine;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        #region FIELDS

        public static LevelManager Instance;
        [SerializeField] private AudioSource audioSource;
        
        #endregion

        #region UNITYMETHODS

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region METHODS

        public void GameOver()
        {
            var ui = GetComponent<UIManager>();
            if (ui == null) return;
            ui.ToggleDeathPanel();
            Time.timeScale = 0f;
            audioSource.volume = 0f;
        }

        #endregion
        
    }
}