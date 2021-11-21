using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class DeathMenu : MonoBehaviour
    {
        public void btn_Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void btn_Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }
}