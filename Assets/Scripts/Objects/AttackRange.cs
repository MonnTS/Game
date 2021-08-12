using UnityEngine;

namespace Objects
{
    public class AttackRange : MonoBehaviour
    {
        public static Transform AttackPoint;
        public static float Range = 0.75f;

        private Vector2 _vector;
        private void Start()
        {
            AttackPoint = GetComponent<Transform>();
        }

        // TODO: Fix the hitbox position.
        // Draws a white circle of hit range in unity inspector
        private void OnDrawGizmosSelected()
        {
            if (AttackPoint == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AttackPoint.position, Range);
        }
    }
}