using Data;
using UnityEngine;

namespace Combat
{
    public class EnemyCombat : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private PlayerData _playerData;
        private Animator _animator;
        private GameObject _skeleton;

        [SerializeField] private int enemyDamage = 1;
        [SerializeField] private int attackCoolDown = 100;
        private float _collisionRadius = 2.5f;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private delegate void OnAttack();
        private event OnAttack OnAttackEvent;
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _skeleton = gameObject;
            _playerData = FindObjectOfType<PlayerData>();
            _animator = GetComponent<Animator>();
            OnAttackEvent += EnemyAttack;
        }
        
        private void Update()
        {
            attackCoolDown--;
            attackCoolDown = attackCoolDown < 0 ? 0 : attackCoolDown;
            
            if (IsInCollision() && attackCoolDown == 0)
            {
                OnAttackEvent?.Invoke();
                attackCoolDown = 100;
            }
        }

        #endregion

        #region METHODS

        private void EnemyAttack()
        {
            _playerData.TakeDamage(enemyDamage);
            _animator.SetTrigger(Attack);
        }

        private bool IsInCollision()
        {
            return Vector3.Distance(_playerData.transform.position, _skeleton.transform.position) < _collisionRadius;
        }

        #endregion
    }
}