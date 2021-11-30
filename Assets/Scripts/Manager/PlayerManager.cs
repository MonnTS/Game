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
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject player;
        [SerializeField] private AudioClip clip;

        private AudioSource _looseSound;
        private PlayerController _playerController;
#pragma warning restore 0649

        #endregion

        public delegate void OnDeath();
        public event OnDeath OnDeathEvent;

        private void Start()
        {
            OnDeathEvent += CanMove;
            _playerController = player.GetComponent<PlayerController>();
            _looseSound = GetComponent<AudioSource>();
        }

        public void Death()
        {
            OnDeathEvent?.Invoke();
            deathScreen.SetActive(true);
            menuCanvas.SetActive(false);
            _looseSound.PlayOneShot(clip);
            Time.timeScale = 0f;
        }

        public void CanMove()
        {
            _playerController.enabled = false;
        }
    }
}