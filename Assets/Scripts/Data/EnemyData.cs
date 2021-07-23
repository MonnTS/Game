using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region UNITYMETHODS

        private void Start()
        {
            currentHealth = enemyHealth;
        }

        // TODO: Death Screen
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            other.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion

        #region FIELDS

        [SerializeField] private int currentHealth;
        [SerializeField] private int enemyHealth = 100;

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