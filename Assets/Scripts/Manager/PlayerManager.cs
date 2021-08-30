using Controller;
using Interfaces;
using UnityEngine;

namespace Manager
{
    public class PlayerManager : MonoBehaviour, IMovable
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private GameObject deathScreen;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject player;
        
        private PlayerController _playerController;

        public delegate void OnDeath();
        public event OnDeath OnDeathEvent;
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            OnDeathEvent += CanMove;
            _playerController = player.GetComponent<PlayerController>();
        }     

        #endregion
        
        #region METHODS

        public void Death()
        {
            OnDeathEvent?.Invoke();
            deathScreen.SetActive(true);
            menuCanvas.SetActive(false);
            audioSource.volume = 0f;
        }

        public void CanMove()
        {
            _playerController.enabled = false;
        }
        
        #endregion
    }
}