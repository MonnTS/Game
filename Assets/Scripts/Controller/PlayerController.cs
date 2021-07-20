using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region FIELDS
        
        private const float MovementSpeed = 5.0f;
        public Vector2 movement;
        public Rigidbody2D rigidBody;
        public Animator animator;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        #endregion

        #region METHODS

        public void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal"); 
            movement.y = Input.GetAxisRaw("Vertical");

            // Getting data for the player's animation.
            animator.SetFloat(Horizontal, movement.x);
            animator.SetFloat(Vertical, movement.y);
            animator.SetFloat(Speed, movement.sqrMagnitude);
        }

        public void FixedUpdate()
        {
            // Formula for movement of the object Player.
            rigidBody.MovePosition(rigidBody.position + movement * (MovementSpeed * Time.fixedDeltaTime));
        }

        #endregion
    }
}