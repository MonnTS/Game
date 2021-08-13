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
            _enemyLayer = LayerMask.GetMask("Enemies");
        }

        private void Update()
        {
            if (!(Time.time >= _nextAttackTime)) return;
            if (!Input.GetMouseButtonDown(0)) return;

            Combat();

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
            //TODO: Fix a bug that cause to hit without cd if there is no boss.
            //foreach (var enemy in hitEnemies) enemy.GetComponent<BossData>().Damage(attackDamage);
        }

        #endregion

    }
}