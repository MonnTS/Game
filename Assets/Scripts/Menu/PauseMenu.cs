using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        #region FIELDS

        private static bool _isPlaying;
        private static bool _isMuted;

        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private Toggle fullScreenToggle;

        [SerializeField] private Slider slider;
        [SerializeField] private Toggle toggle;
        
        private PlayerController _playerController;

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;

            if (_isPlaying)
                btn_Resume();

            else
                Pause();
        }

        #endregion

        #region METHODS

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _playerController.enabled = false;
            _isPlaying = true;
        }

        public void btn_Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _playerController.enabled = true;
            _isPlaying = false;
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
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void cb_FullScreen()
        {
            Screen.fullScreenMode = fullScreenToggle.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
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