using System.Security.Cryptography;
using UnityEngine;

namespace Data
{
    public class BossData : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private int currentHealth;
        private const int BossMAXHealth = 5;

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            currentHealth = BossMAXHealth;
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