using Manager;
using UnityEngine;

namespace Data
{
    public class PlayerData : MonoBehaviour
    {
        public const int PlayerMAXHealth = 10;

        private bool _isDead;
        private PlayerManager _playerManager;

        public static int CurrentHealth { get; set; }

        private void Start()
        {
            CurrentHealth = PlayerMAXHealth;
            _playerManager = GetComponent<PlayerManager>();
        }

        private void Update()
        {
            if (CurrentHealth > PlayerMAXHealth) CurrentHealth = PlayerMAXHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0 && !_isDead)
            {
                _isDead = true;
                _playerManager.Death();
            }
        }
    }
}