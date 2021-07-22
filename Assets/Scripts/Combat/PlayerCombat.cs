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
        
        [SerializeField]private float attackRange = 0.5f;
        [SerializeField]private float attackRate = 2f;
        [SerializeField]private int attackDamage = 15;
        private float _nextAttackTime;

        private static readonly int Attack = Animator.StringToHash("Attack");

        #endregion

        #region UNITYMETHODS
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
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        
        #endregion

        #region METHODS
        
        private void Combat()
        {
            animator.SetTrigger(Attack);

            var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,
                enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyData>().Damage(attackDamage);
            }
        }
        
        #endregion
    }
}