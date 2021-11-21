using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;
        [SerializeField] private Toggle toggle;

        private static bool _isMuted;
#pragma warning restore 0649

        #endregion

        public void btn_Play()
        {
            Time.timeScale = 1f;
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
    }
}