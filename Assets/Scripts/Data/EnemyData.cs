using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        private int _currentHealth;
        private int _enemyHealth = 100;
        private SpriteRenderer _spriteRenderer;
        void Start()
        {
            _currentHealth = _enemyHealth;
        }

        public void Damage(int damage)
        {
            _currentHealth -= damage;
            if(_currentHealth <= 0)
                Death();
        }

        private void Death()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(var enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}

