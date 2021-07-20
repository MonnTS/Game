using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        private const float MovementSpeed = 5.0f;
        private Vector2 _movement;
        public Rigidbody2D rigidBody;
        public Animator animator;
        
        // Getting X, Y and Speed in an efficient way.
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        public void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal"); 
            _movement.y = Input.GetAxisRaw("Vertical");

            // Getting data for the player's animation.
            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        public void FixedUpdate()
        {
            // Formula for movement of the object Player.
            rigidBody.MovePosition(rigidBody.position + _movement * (MovementSpeed * Time.fixedDeltaTime));
        }
    }
}