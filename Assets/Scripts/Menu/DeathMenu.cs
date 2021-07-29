using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class DeathMenu : MonoBehaviour
    {
        #region METHODS

        public void btn_Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void btn_Menu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        #endregion
        
    }
}