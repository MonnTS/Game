using Data;
using UnityEngine;

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        #region FIELDS
        
        public Animator animator;
        public Transform attackPoint;
        public LayerMask enemyLayer;
        
        public float attackRange = 0.5f;
        private const float AttackRate = 2f;
        private float _nextAttackTime;
        private int _attackDamage = 15;
        
        private static readonly int Attack = Animator.StringToHash("Attack");

        #endregion

        #region METHODS
        public void Update()
        {
            if (!(Time.time >= _nextAttackTime)) return;
            if (!Input.GetMouseButtonDown(0)) return;
            
            Combat();
            
            _nextAttackTime = Time.time + 1f / AttackRate;
        }

        private void Combat()
        {
            animator.SetTrigger(Attack);
            // ReSharper disable once Unity.PreferNonAllocApi
            var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,
                enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyData>().Damage(_attackDamage);
            }
        }

        // Draws a white circle of hit range in unity inspector
        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        #endregion
    }
}