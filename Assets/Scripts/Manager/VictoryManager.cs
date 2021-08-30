using Controller;
using Data;
using UnityEngine;

namespace Manager
{
    public class VictoryManager : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private PlayerController _playerController;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject victoryMenu;
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
        }

        private void Update()
        {
            var enemyCounter = EnemyData.Count;
            
            if (enemyCounter != 0) return;
            
            Time.timeScale = 0f;
            _playerController.enabled = false;
            pauseMenu.SetActive(false);
            victoryMenu.SetActive(true);
        }

        #endregion
    }
}