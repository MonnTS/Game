using UnityEngine;
using Controller;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class VictoryMenu : MonoBehaviour
    {
        #region FIELDS
        
#pragma warning disable 0649
        private PlayerController _playerController;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject victoryMenu;
#pragma warning restore 0649
        
        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
        }
        
        #endregion
        
        #region METHODS

        public void btn_NextLevel()
        {
            Time.timeScale = 1f;
            _playerController.enabled = true;
            victoryMenu.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Menu()
        {
            Time.timeScale = 1f;
            _playerController.enabled = true;
            victoryMenu.SetActive(false);
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        #endregion
    }
}