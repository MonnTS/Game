﻿using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region FIELDS
        
        private Vector2 _movement;
        public Animator animator;
        public Rigidbody2D rigidBody;

        [SerializeField]private float movementSpeed = 5.0f;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        #endregion

        #region UNITYMETHODS

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
            rigidBody.MovePosition(rigidBody.position + _movement * (movementSpeed * Time.fixedDeltaTime));
        }

        #endregion
    }
}