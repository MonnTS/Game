using Data;
using UnityEngine;

namespace Combat
{
    public class BossCombat : MonoBehaviour
    {
        #region FIELDS

        public Animator animator;
        private PlayerData _playerData;

        [SerializeField] private int enemyDamage = 10;
        [SerializeField] private float attackRate = 1.5f;

        private bool _isInCollision;

        private static readonly int Attack = Animator.StringToHash("Attack");

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _playerData = FindObjectOfType<PlayerData>();
        }

        private void Update()
        {
            if (!_isInCollision) return;
            attackRate -= Time.deltaTime;

            if (!(attackRate <= 0)) return;
            _playerData.TakeDamage(enemyDamage);
            attackRate = 1.5f;
            animator.SetTrigger(Attack);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            _playerData.TakeDamage(enemyDamage);
        }

        private void OnCollisionStay2D()
        {
            _isInCollision = true;
        }

        #endregion
    }
}