using UnityEngine;

namespace Data
{
    public class BossData : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private int currentHealth;
        [SerializeField] private int bossHealth = 100;

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            currentHealth = bossHealth;
        }

        #endregion
        
        #region METHODS

        public void Damage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0) Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}