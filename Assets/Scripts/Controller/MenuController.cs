using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    namespace Controller
    {
        public class MenuController : MonoBehaviour
        {
            public void btn_Play()
            {
                // TODO: Make Load Scene with index by implementing next thing: SceneManager.(SceneManager.GetActiveScene().buildIndex + 1); 
                SceneManager.LoadScene("FirstLevel");
            }

            public void btn_Exit()
            {
                Debug.Log("Yes");
                Application.Quit();
            }
        }    
    }
}