using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private int enemyHealth;
#pragma warning restore 0649

        [SerializeField] private int currentHealth;

        public static int Count { get; private set; }
        
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