﻿using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        #region FIELDS
        
        private Animator _animator;
        private Transform _target;
        public Transform defaultPosition;

        #endregion
        
        #region PROPERTIES

        [SerializeField] private float movementSpeed;
        [SerializeField] private float maxRange;
        [SerializeField] private float minRange;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        #endregion

        #region METHODDS

        private void Start()
        {
            _animator = GetComponent<Animator>();
            
            // Find the player by his script.
            _target = FindObjectOfType<PlayerController>().transform;

            movementSpeed = 2.0f;
            maxRange = 5.0f;
            minRange = 1.0f;
        }
        
        private void Update()
        {
            /*
             * If the distance is further than
             * value of range the enemy
             * will stop follow the player.
             * And due to the minimum range
             * he won't be able to push us
             * because of his big mass.
             * If the enemy loses the player
             * he will return to the
             * default position.
             */
            if (Vector3.Distance(_target.position, transform.position) <= maxRange
                && Vector3.Distance(_target.position, transform.position) >= minRange)
            {
                Follow();
            }
            else if(Vector3.Distance(_target.position, transform.position) >= maxRange)
            {
                BackToThePoint();
            }
        }

        private void Follow()
        {
            var position = transform.position;
            var positionE = _target.position;
            
            _animator.SetFloat(Horizontal, positionE.x - position.x);
            _animator.SetFloat(Vertical, positionE.y - position.y);
            _animator.SetBool(IsMoving, true);
            
            position = Vector3.MoveTowards(position,
                _target.transform.position, movementSpeed * Time.deltaTime);
            transform.position = position;
        }

        private void BackToThePoint()
        {
            var position = defaultPosition.position;
            var position1 = transform.position;
            var positionE = position1;
            
            _animator.SetFloat(Horizontal, position.x - positionE.x);
            _animator.SetFloat(Vertical, position.y - positionE.y);   
            
            position1 = Vector3.MoveTowards(position1, position,
                movementSpeed * Time.deltaTime);
            transform.position = position1;

            if (Vector3.Distance(transform.position, defaultPosition.position) == 0)
            {
                _animator.SetBool(IsMoving, false);
            }
        }
        
        #endregion
    }
}