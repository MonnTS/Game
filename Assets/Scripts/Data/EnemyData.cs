﻿using UnityEngine;

namespace Data
{
    public class EnemyData : MonoBehaviour
    {
        #region FIELDS

        [SerializeField] private int currentHealth;
        [SerializeField] private int enemyHealth = 100;
        [SerializeField] private int enemyDamage = 10;
        [SerializeField] private float attackRate = 2.0f;
        private bool isInCollision;
        
        private PlayerData _playerData;
        public Animator animator;
        
        private static readonly int Attack = Animator.StringToHash("Attack");

        #endregion
        
        #region UNITYMETHODS

        private void Start()
        {
            currentHealth = enemyHealth;
            _playerData = FindObjectOfType<PlayerData>();
        }

        private void Update()
        {
            if (!isInCollision) return;
            attackRate -= Time.deltaTime;
            
            if (!(attackRate <= 0)) return;
            _playerData.TakeDamage(enemyDamage);
            attackRate = 2.0f;
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
            isInCollision = true;
            
        }
        
        #endregion

        #region METHODS
        
        public void Damage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0) Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}