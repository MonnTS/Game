using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private Vector2 _movement;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float movementSpeed = 5.0f;

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
#pragma warning restore 0649

        #endregion

        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            rigidBody.MovePosition(rigidBody.position + _movement * (movementSpeed * Time.fixedDeltaTime));
        }
    }
}