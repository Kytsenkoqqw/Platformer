using System;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterAttack : MonoBehaviour, IAttackable
    {
        private Animator _animator;
        [SerializeField] private GameObject _pointAttack;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _enemy;
        [SerializeField] private float _damage;

        private bool _isAttack;


        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartAttack()
        {
            _isAttack = true;
        }

        public void Attack()
        {
            if (_isAttack)
            {
                _animator.SetTrigger("Attack");
                Collider2D[] enemy = Physics2D.OverlapCircleAll(_pointAttack.transform.position, _radius, _enemy);

                foreach (Collider2D enemyGameObject in enemy)
                {
                    Debug.Log("Hit Enemy ");
                    HealthSystem enemyHealth = enemyGameObject.GetComponent<HealthSystem>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(_damage); // Теперь урон получает враг
                    }
                }

                _isAttack = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_pointAttack.transform.position, _radius);
        }
    }
}