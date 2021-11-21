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
#pragma warning restore 0649

        #endregion

        public delegate void OnDeath();
        public event OnDeath OnDeathEvent;

        private void Start()
        {
            OnDeathEvent += CanMove;
            _playerController = player.GetComponent<PlayerController>();
        }     

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
    }
}