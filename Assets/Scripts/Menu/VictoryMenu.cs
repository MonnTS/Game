using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class VictoryMenu : MonoBehaviour
    {
        #region METHODS

        public void btn_NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Menu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        #endregion
    }
}