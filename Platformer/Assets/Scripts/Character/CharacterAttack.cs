using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private HealthSystem _healthSystem;
        
        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Attack");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<BrittleArcher>())
            {
                _healthSystem.TakeDamage(30);
            }
        }
    }
}