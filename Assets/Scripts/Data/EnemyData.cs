using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region FIELDS
        
        [SerializeField]private int currentHealth;
        [SerializeField]private int enemyHealth = 100;

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            currentHealth = enemyHealth;
        }

        #endregion

        #region METHODS

        public void Damage(int damage)
        {
            currentHealth -= damage;
            
            if (currentHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}

