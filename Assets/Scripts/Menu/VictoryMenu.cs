using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class VictoryMenu : MonoBehaviour
    {
        #region METHODS

        public void btn_NextLevel()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        #endregion
    }
}