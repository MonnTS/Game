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
            CurrentHealth = PlayerMAXHealth;
            _playerManager = GetComponent<PlayerManager>();
        }

        private void Update()
        {
            if (CurrentHealth > PlayerMAXHealth)
                CurrentHealth = PlayerMAXHealth;
        }

        #endregion

        #region METHODS

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                _playerManager.Death();
            }
        }
        #endregion
    }
}