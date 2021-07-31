using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;
        [SerializeField] private Toggle toggle;

        private static bool _isMuted;

        #endregion
        
        #region METHODS

        public void btn_Play()
        {
            // Loads all scenes by index.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Exit()
        {
            Application.Quit();
        }

        public void cb_FullScreen(bool isFullScreen)
        {
            Screen.fullScreenMode = isFullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
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