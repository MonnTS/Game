using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private int currentHealth;
        [SerializeField] private int enemyHealth = 2;

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

            if (currentHealth <= 0) Destroy(gameObject);
        }
        #endregion
    }
}