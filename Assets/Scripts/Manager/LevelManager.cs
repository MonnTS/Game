using UnityEngine;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
            {
                Destroy(gameObject);
            }
        }

        public void GameOver()
        {
            var ui = GetComponent<UIManager>();
            if (ui == null) return;
            ui.ToggleDeathPanel();
            Time.timeScale = 0f;
            audioSource.volume = 0;
        }
    }
}