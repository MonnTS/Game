using UnityEngine;
using Controller;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class VictoryMenu : MonoBehaviour
    {
        #region FIELDS
        
        private PlayerController _playerController;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject victoryMenu;
        
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