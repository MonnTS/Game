using UnityEngine;

namespace Objects
{
    public class AttackRange : MonoBehaviour
    {
        #region FIELDS
        
        public static Transform AttackPoint;
        public static float Range = 0.75f;

        private Vector2 _vector;
        
        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            AttackPoint = GetComponent<Transform>();
        }

        private void OnDrawGizmosSelected()
        {
            if (AttackPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(AttackPoint.position, Range);
            }
        }

        #endregion
    }
}