using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region FIELDS
        
        public int currentHealth;
        public int enemyHealth = 100;
        private SpriteRenderer _spriteRenderer;

        #endregion

        #region METHODS

        private void Start()
        {
            currentHealth = enemyHealth;
        }

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

