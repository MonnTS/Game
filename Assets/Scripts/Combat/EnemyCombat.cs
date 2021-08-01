using Data;
using UnityEngine;

namespace Combat
{
    public class EnemyCombat : MonoBehaviour
    {
        #region FIELDS

        private Animator _animator;
        private PlayerData _playerData;

        [SerializeField] private int enemyDamage = 10;
        [SerializeField] private float attackRate = 1.5f;

        private static bool _isInCollision;

        private static readonly int Attack = Animator.StringToHash("Attack");

        #endregion

        #region UNITYMETHOS

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerData = FindObjectOfType<PlayerData>();
        }

        private void Update()
        {
            if (!_isInCollision) return;
            attackRate -= Time.deltaTime;

            if (!(attackRate <= 0)) return;
            _playerData.TakeDamage(enemyDamage);
            _animator.SetTrigger(Attack);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            _playerData.TakeDamage(enemyDamage);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if(!other.collider.CompareTag("Player")) return;
            _isInCollision = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if(!other.collider.CompareTag("Player")) return;
            _isInCollision = false;
        }

        #endregion
    }
}