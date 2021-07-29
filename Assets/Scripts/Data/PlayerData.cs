using Manager;
using UnityEngine;

namespace Data
{
    public class PlayerData : MonoBehaviour
    {
        #region FIELDS
        
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth = 10;

        #endregion

        #region UNITYMETHODS
        
        private void Start()
        {
            currentHealth = maxHealth;
        }

        #endregion

        #region METHODS

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth > 0) return;
            Death();
        }

        private void Death()
        {
            LevelManager.Instance.GameOver();
            gameObject.SetActive(false);
        }

        #endregion
    }
}