using Controller;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        #region FIELDS

        private static bool IsPlaying;
        private static bool IsMuted;
        
        public GameObject pauseMenu;
        public GameObject player;
        public GameObject settingsMenu;
        public Slider slider;
        public Toggle toggle;

        #endregion

        #region UNITYMETHODS

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (IsPlaying)
            {
                btn_Resume();
            }
            
            else
            {
                Pause();
            }
        }
        
        #endregion

        #region METHODS

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponent<PlayerController>().enabled = false;
            IsPlaying = true;
        }
        
        public void btn_Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            player.GetComponent<PlayerController>().enabled = true;
            IsPlaying = false;
        }

        public void btn_Back()
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        
        public void btn_Settings()
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void btn_ExitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
        
        public void cb_FullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
            if (isFullScreen) return;
            var res = Screen.currentResolution;
            Screen.SetResolution(res.width, res.height, false);
        }
        
        public void cb_MuteMusic()
        {
            IsMuted = !IsMuted;
            AudioListener.pause = IsMuted;
            
            slider.enabled = toggle.isOn;
        }

        #endregion

    }
}