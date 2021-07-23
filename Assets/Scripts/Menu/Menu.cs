using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        #region FIELDS

        public AudioMixer audioMixer;
        public Slider slider;
        public Toggle toggle;
        
        private bool _isMuted; 

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _isMuted = false;
        }

        #endregion
        
        #region METHODS

        public void btn_Play()
        {
            // Loads all scenes by index.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Exit()
        {
            Debug.Log("Yes");
            Application.Quit();
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
            _isMuted = !_isMuted;
            AudioListener.pause = _isMuted;
            
            slider.enabled = toggle.isOn;
        }

        #endregion
    }
}