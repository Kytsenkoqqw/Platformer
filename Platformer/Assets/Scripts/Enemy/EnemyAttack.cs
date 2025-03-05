using System;
using ObjectBehaviour;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, IAttackable
    {

        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private int _damage;
        
        
        public void Attack()
        {
            _healthSystem.TakeDamage((_damage));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<CharacterBehaviour>())
            {
                Attack();
            }
        }
    }
}