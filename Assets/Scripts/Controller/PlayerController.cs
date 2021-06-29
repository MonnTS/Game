using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        // Initialize current speed for the player
        private const float MovementSpeed = 5.0f;
        // Getting rigidbody of the object player
        public Rigidbody2D rigidBody;
        public Animator animator;
        // 2D Vector
        private Vector2 _movement;
        // String based property lookup is inefficient in animator, so we will refactor the code just a little.
        // Converting string to int, which is our variables in animator. 
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        // Update is called once per frame
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                Debug.Log("Left button pressed");
            }
            
            // Getting X, Y from the object
            _movement.x = Input.GetAxisRaw("Horizontal"); 
            _movement.y = Input.GetAxisRaw("Vertical");

            // Getting data for the player's animation
            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        // FixedUpdate called for physics calculation
        public void FixedUpdate()
        {
            // Formula for movement of the object Player
            rigidBody.MovePosition(rigidBody.position + _movement * (MovementSpeed * Time.fixedDeltaTime));
        }
        
        // Method for the attack
        private void Attack()
        {
            animator.SetTrigger(Attack1);
        }
    }
}