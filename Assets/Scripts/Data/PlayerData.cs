using Manager;
using UnityEngine;

namespace Data
{
    public class PlayerData : MonoBehaviour
    {
        #region FIELDS

        public static int CurrentHealth;
        public const int PlayerMAXHealth = 10;
        private PlayerManager _playerManager;

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            CurrentHealth = PlayerMAXHealth;
        }

        #endregion
        
        #region METHODS

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0) Death();
        }

        private void Death()
        {
            _playerManager.Death();
        }

        #endregion
    }
}