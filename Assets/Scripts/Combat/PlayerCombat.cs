using UnityEngine;

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        public Animator animator;
        // Getting a trigger with the name "Attack" in efficient way.
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        public void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            Combat();
            Debug.Log("You pressed left button.");
        }

        private void Combat()
        {
            animator.SetTrigger(Attack);
        }
    }
}