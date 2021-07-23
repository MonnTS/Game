using Data;
using UnityEngine;

namespace Combat
{
    public class BossCombat : MonoBehaviour
    {
        public Animator animator;
        private PlayerData _playerData;
        
        [SerializeField] private int enemyDamage = 10;
        [SerializeField] private float attackRate = 2.0f;
        
        private bool _isInCollision;
        
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Start()
        {
            _playerData = FindObjectOfType<PlayerData>();
        }

        private void Update()
        {
            if (!_isInCollision) return;
            attackRate -= Time.deltaTime;
            
            if (!(attackRate <= 0)) return;
            _playerData.TakeDamage(enemyDamage);
            attackRate = 2f;
            animator.SetTrigger(Attack);
        }

        // TODO: Death Screen
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            _playerData.TakeDamage(enemyDamage);
        }

        private void OnCollisionStay2D()
        {
            _isInCollision = true;
        }
    }
}