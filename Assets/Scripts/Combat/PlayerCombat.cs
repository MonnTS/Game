using Data;
using UnityEngine;

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        public Animator animator;
        public Transform attackPoint;
        public LayerMask enemyLayer;
        
        private const float RangeAttack = 0.5f;
        private const float AttackRate = 2f;
        private float _nextAttackTime = 0f;
        private int _attackDamage = 15;
        
        // Getting a trigger with the name "Attack" in an efficient way.
        private static readonly int Attack = Animator.StringToHash("Attack");
        
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
            var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, RangeAttack,
                enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyData>().Damage(_attackDamage);
            }
        }

        public void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, RangeAttack);
        }
    }
}