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


        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
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
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_pointAttack.transform.position, _radius);
        }
    }
}