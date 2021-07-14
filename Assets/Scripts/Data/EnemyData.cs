using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        public int currentHealth;
        public int enemyHealth = 100;
        private SpriteRenderer _spriteRenderer;
        
        void Start()
        {
            currentHealth = enemyHealth;
        }

        public void Damage(int damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
                Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}

