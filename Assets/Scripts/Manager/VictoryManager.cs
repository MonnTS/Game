using Controller;
using Data;
using Interfaces;
using UnityEngine;

namespace Manager
{
    public class VictoryManager : MonoBehaviour, IMovable
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject victoryMenu;
        [SerializeField] private AudioClip clip;

        private AudioSource _winSound;
        private PlayerController _playerController;

        private bool _isVictory;
#pragma warning restore 0649

        #endregion

        private delegate void VictoryPlay();
        private event VictoryPlay ShowVictoryPlay;
        
        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
            _winSound = GetComponent<AudioSource>();
            ShowVictoryPlay += Victory;
        }

        private void Update()
        {
            var enemyCounter = EnemyData.Count;

            if (enemyCounter == 0 && !_isVictory) ShowVictoryPlay?.Invoke();
        }

        private void Victory()
        {
            _isVictory = true;
            Time.timeScale = 0f;
            victoryMenu.SetActive(true);
            pauseMenu.SetActive(false);
            _winSound.PlayOneShot(clip);
        }
        
        public void CanMove()
        {
            _playerController.enabled = false;
        }
    }
}