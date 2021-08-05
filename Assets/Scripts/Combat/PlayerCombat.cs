using Data;
using UnityEngine;

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private Animator _animator;
        private Transform _attackPoint;
        private LayerMask _enemyLayer;

        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private float attackRate = 1.5f;
        [SerializeField] private int attackDamage = 15;
        private float _nextAttackTime;

        private static readonly int Attack = Animator.StringToHash("Attack");
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _animator = FindObjectOfType<Animator>();
            _attackPoint = GameObject.FindGameObjectWithTag("AttackPoint").transform;
            _enemyLayer = LayerMask.GetMask("Enemies");
        }

        private void Update()
        {
            if (!(Time.time >= _nextAttackTime)) return;
            if (!Input.GetMouseButtonDown(0)) return;

            Combat();

            _nextAttackTime = Time.time + 1f / attackRate;
        }

        // TODO: Fix the hitbox position.
        // Draws a white circle of hit range in unity inspector
        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null) return;
            Gizmos.DrawWireSphere(_attackPoint.position, attackRange);
        }

        #endregion
        
        #region METHODS

        private void Combat()
        {
            _animator.SetTrigger(Attack);

            var hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, attackRange,
                _enemyLayer);

            foreach (var enemy in hitEnemies) enemy.GetComponent<EnemyData>().Damage(attackDamage);
            foreach (var enemy in hitEnemies) enemy.GetComponent<BossData>().Damage(attackDamage);
        }

        #endregion
    }
}