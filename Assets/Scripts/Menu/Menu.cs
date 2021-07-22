using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    // TODO: Is it possible to not inherit MonoBehaviour?
    public class Menu : MonoBehaviour
    {
        #region METHODS

        public void btn_Play()
        {
            // Loads all scenes by index not only the chosen.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void btn_Exit()
        {
            Debug.Log("Yes");
            Application.Quit();
        }

        public void ck_FullScreen()
        {
            throw new NotImplementedException();
        }

        public void ck_Windowed()
        {
            throw new NotImplementedException();
        }

        public void ck_MuteMusic()
        {
            throw new NotImplementedException();
        }

        public void ck_MuteSounds()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}