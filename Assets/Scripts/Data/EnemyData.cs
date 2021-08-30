using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private int currentHealth;
        [SerializeField] private int enemyHealth = 2;
        public static int Count;

        #endregion

        #region UNITYMETHODS

        private void Awake()
        {
            Count++;
        }

        private void Start()
        {
            currentHealth = enemyHealth;
        }

        #endregion

        #region METHODS

        public void Damage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth > 0) return;
            Count--;
            Destroy(gameObject);

        }

        #endregion
    }
}