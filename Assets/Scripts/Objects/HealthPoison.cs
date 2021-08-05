using Data;
using UnityEngine;

namespace Objects
{
    public class HealthPoison : MonoBehaviour
    {
        #region FIELDS

        private static int _currentValue;
        private int _maxValue;

        #endregion

        #region UNITYMETHODS

        private void Update()
        {
            _currentValue = PlayerData.CurrentHealth;
            _maxValue = PlayerData.PlayerMAXHealth;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;
            if (_currentValue == _maxValue) return;
            Destroy(gameObject);
        }

        #endregion
    }
}