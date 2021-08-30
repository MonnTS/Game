using Interfaces;
using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour, IMovable
    {
        #region FIELDS

#pragma warning disable 0649
        private Animator _animator;
        private Transform _target;
        public Transform defaultPosition;
        
        private PlayerController _playerController;

        [SerializeField] private float movementSpeed;
        [SerializeField] private float maxRange;
        [SerializeField] private float minRange;

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        public delegate void OnPlayerDeath();
        public event OnPlayerDeath PlayerDeathEvent;
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODDS

        private void Start()
        {
            PlayerDeathEvent += CanMove;
            _animator = GetComponent<Animator>();
            _playerController = FindObjectOfType<PlayerController>();
            _target = _playerController.transform;
        }

        private void Update()
        {
            if (!_playerController.enabled)
            {
                PlayerDeathEvent?.Invoke();
            }
            
            /* If the distance is further than
            * value of range the enemy
            * will stop follow the player.
            * Due to the minimum range
            * he won't be able to push us
            * because of his big mass,
            * otherwise he will
            * return to the default position.
            */   
            if (Vector3.Distance(_target.position, transform.position) <= maxRange
                && Vector3.Distance(_target.position, transform.position) >= minRange)
                Follow();
            else if (Vector3.Distance(_target.position, transform.position) >= maxRange)
                BackToThePoint();
        }

        #endregion

        #region METHODS

        private void Follow()
        {
            var position = transform.position;
            var positionE = _target.position;

            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Horizontal, positionE.x - position.x);
            _animator.SetFloat(Vertical, positionE.y - position.y);

            position = Vector3.MoveTowards(position,
                _target.transform.position, movementSpeed * Time.deltaTime);
            transform.position = position;
        }

        private void BackToThePoint()
        {
            var position = defaultPosition.position;
            var positionT = transform.position;
            var positionE = positionT;

            _animator.SetFloat(Horizontal, position.x - positionE.x);
            _animator.SetFloat(Vertical, position.y - positionE.y);

            positionT = Vector3.MoveTowards(positionT, position,
                movementSpeed * Time.deltaTime);

            transform.position = positionT;

            if (Vector3.Distance(transform.position, defaultPosition.position) <= 0)
                _animator.SetBool(IsMoving, false);
        }

        public void CanMove()
        {
            enabled = false;
            _animator.enabled = false;
        }
        
        #endregion
    }
}