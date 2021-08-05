using Data;
using UnityEngine;

namespace Combat
{
    public class BossCombat : MonoBehaviour
    {
        #region FIELDS
#pragma warning disable 0649
        private Animator _animator;
        private PlayerData _playerData;

        [SerializeField] private int enemyDamage = 10;
        [SerializeField] private float attackRate = 1.5f;

        private static bool _isInCollision;

        private static readonly int Attack = Animator.StringToHash("Attack");
#pragma warning restore 0649
        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _animator = FindObjectOfType<Animator>();
            _playerData = FindObjectOfType<PlayerData>();
        }

        private void Update()
        {
            if (!_isInCollision) return;
            attackRate -= Time.deltaTime;

            if (!(attackRate <= 0)) return;
            _playerData.TakeDamage(enemyDamage);
            attackRate = 1.5f;
            _animator.SetTrigger(Attack);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            _playerData.TakeDamage(enemyDamage);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;
            _isInCollision = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;
            _isInCollision = false;
        }

        #endregion
    }
}