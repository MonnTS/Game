using Data;
using UnityEngine;

namespace Combat
{
    public class EnemyCombat : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        private PlayerData _playerData;
        private Animator _animator;
        private GameObject _skeleton;

        private readonly float _attackTimer = 1.5f;
        private readonly float _collisionRadius = 2.5f;
        private float _nextTimeAttackTime;

        [SerializeField] private int enemyDamage = 1;

        private AudioSource _damageSound;
        [SerializeField] private AudioClip clip;

        private static readonly int Attack = Animator.StringToHash("Attack");
#pragma warning restore 0649

        #endregion
        
        private delegate void OnAttack();
        private event OnAttack OnAttackEvent;
        
        private void Start()
        {
            _skeleton = gameObject;
            _playerData = FindObjectOfType<PlayerData>();
            _animator = GetComponent<Animator>();
            _damageSound = GetComponent<AudioSource>();
            OnAttackEvent += EnemyAttack;
        }

        private void Update()
        {
            if (Time.time >= _nextTimeAttackTime && IsInCollision())
            {
                OnAttackEvent?.Invoke();
                _damageSound.PlayOneShot(clip);
                _nextTimeAttackTime = Time.time + 2f / _attackTimer;
            }
        }
        
        private void EnemyAttack()
        {
            _playerData.TakeDamage(enemyDamage);
            _animator.SetTrigger(Attack);
        }

        private bool IsInCollision()
        {
            return Vector3.Distance(_playerData.transform.position, _skeleton.transform.position) < _collisionRadius;
        }
    }
}