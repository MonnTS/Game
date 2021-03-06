using Interfaces;
using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour, IMovable
    {
        #region FIELDS

#pragma warning disable 0649
        private Animator _animator;
        private Transform _playerLocation;
        private PlayerController _playerController;
        [SerializeField] private Transform defaultPosition;

        [SerializeField] private float movementSpeed;
        [SerializeField] private float maxRange;
        [SerializeField] private float minRange;

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
#pragma warning restore 0649

        #endregion
        
        public delegate void OnPlayerDeath();
        public event OnPlayerDeath PlayerDeathEvent;
        
        private void Start()
        {
            PlayerDeathEvent += CanMove;
            _animator = GetComponent<Animator>();
            _playerController = FindObjectOfType<PlayerController>();
            _playerLocation = _playerController.transform;
        }

        private void Update()
        {
            if (!_playerController.enabled) PlayerDeathEvent?.Invoke();

            if (Vector3.Distance(_playerLocation.position, transform.position) <= maxRange
                && Vector3.Distance(_playerLocation.position, transform.position) >= minRange)
                Follow();
            else if (Vector3.Distance(_playerLocation.position, transform.position) >= maxRange)
                BackToThePoint();
        }

        public void CanMove()
        {
            enabled = false;
            _animator.enabled = false;
        }

        private void Follow()
        {
            var enemyPosition = transform.position;
            var playerPosition = _playerLocation.position;

            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Horizontal, playerPosition.x - enemyPosition.x);
            _animator.SetFloat(Vertical, playerPosition.y - enemyPosition.y);

            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition,
                movementSpeed * Time.deltaTime);
        }

        private void BackToThePoint()
        {
            var defaultEnemyPosition = defaultPosition.position;
            var enemyPosition = transform.position;

            _animator.SetFloat(Horizontal, defaultEnemyPosition.x - enemyPosition.x);
            _animator.SetFloat(Vertical, defaultEnemyPosition.y - enemyPosition.y);

            transform.position = Vector3.MoveTowards(enemyPosition, defaultEnemyPosition,
                movementSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, defaultPosition.position) == 0)
                _animator.SetBool(IsMoving, false);
        }
    }
}