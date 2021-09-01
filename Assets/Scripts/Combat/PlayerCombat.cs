using Data;
using Objects;
using UnityEngine;

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private Animator _animator;
        private LayerMask _enemyLayer;

        private delegate void PlayerAttack();

        private event PlayerAttack EventAttack;

        [SerializeField] private float attackRate;
        [SerializeField] private int attackDamage;
        private float _nextAttackTime;

        private static readonly int Attack = Animator.StringToHash("Attack");
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _enemyLayer = LayerMask.GetMask("Enemies");
            EventAttack += Combat;
        }

        private void Update()
        {
            if (!(Time.time >= _nextAttackTime)) return;
            if (!Input.GetMouseButtonDown(0)) return;

            EventAttack?.Invoke();
            _nextAttackTime = Time.time + 1f / attackRate;
        }

        #endregion
        
        #region METHODS

        private void Combat()
        {
            _animator.SetTrigger(Attack);

            var hitEnemies = Physics2D.OverlapCircleAll(AttackRange.AttackPoint.position,
                AttackRange.Range,
                _enemyLayer);

            foreach (var enemy in hitEnemies) enemy.GetComponent<EnemyData>().Damage(attackDamage);
        }

        #endregion
    }
}