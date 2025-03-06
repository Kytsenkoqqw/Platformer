using System;
using ObjectBehaviour;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        
        [SerializeField] private int _damage;

        public void Attack(HealthSystem targetHealth)
        {
            if (targetHealth != null) 
            {
               targetHealth.TakeDamage(_damage);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<CharacterBehaviour>())
            {
                CharacterBehaviour character = other.gameObject.GetComponent<CharacterBehaviour>();
                if (character != null)
                {
                    HealthSystem characterHealth = character.GetComponent<HealthSystem>();
                    Attack(characterHealth); 
                }
            }
        }
    }
}