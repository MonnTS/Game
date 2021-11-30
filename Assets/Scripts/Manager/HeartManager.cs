using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class HeartManager : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private Image[] hearts;
        [SerializeField] private Sprite fullHeart;
        [SerializeField] private Sprite emptyHeart;
        
        private int _maxHealth;
#pragma warning restore 0649

        #endregion

        private void Start()
        {
            _maxHealth = PlayerData.PlayerMAXHealth;
        }

        private void Update()
        {
            var currentHealth = PlayerData.CurrentHealth;

            for (var i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
                hearts[i].enabled = i < _maxHealth;
            }
        }
    }
}