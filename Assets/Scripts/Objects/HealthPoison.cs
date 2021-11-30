using Data;
using UnityEngine;

namespace Objects
{
    public class HealthPoison : MonoBehaviour
    {
        #region FIELDS

        private int _currentValue;
        private int _maxValue;

        #endregion

        private void Update()
        {
            _currentValue = PlayerData.CurrentHealth;
            _maxValue = PlayerData.PlayerMAXHealth;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var healthUp = 5;
            if (other.collider.CompareTag("Player") && _currentValue < _maxValue)
            {
                PlayerData.CurrentHealth += healthUp;
                Destroy(gameObject);
            }
        }
    }
}