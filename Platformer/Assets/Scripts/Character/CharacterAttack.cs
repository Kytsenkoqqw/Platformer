using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private HealthSystem _healthSystem;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Attack");
                _animator.SetTrigger("Attack");
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