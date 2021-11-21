using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int enemyHealth;
        public static int Count;

        private void Awake()
        {
            Count++;
        }

        private void Start()
        {
            currentHealth = enemyHealth;
        }

        public void Damage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Count--;
                Destroy(gameObject);
            }
        }
    }
}