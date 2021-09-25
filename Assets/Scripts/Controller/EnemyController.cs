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
            var enemyPosition = transform.position;
            var playerPosition = _target.position;

            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Horizontal, playerPosition.x - enemyPosition.x);
            _animator.SetFloat(Vertical, playerPosition.y - enemyPosition.y);

            enemyPosition = Vector3.MoveTowards(enemyPosition,
                _target.transform.position, movementSpeed * Time.deltaTime);
            transform.position = enemyPosition;
        }

        private void BackToThePoint()
        {
            var defaultEnemyPosition = defaultPosition.position;
            var enemyPosition = transform.position;
            var position = enemyPosition;

            _animator.SetFloat(Horizontal, defaultEnemyPosition.x - position.x);
            _animator.SetFloat(Vertical, defaultEnemyPosition.y - position.y);

            enemyPosition = Vector3.MoveTowards(enemyPosition, defaultEnemyPosition,
                movementSpeed * Time.deltaTime);

            transform.position = enemyPosition;

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