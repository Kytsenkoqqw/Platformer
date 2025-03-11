using System;
using Animation;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterAttack : MonoBehaviour, IAttackable
    {
        private AnimationManager _animationManager;
        [SerializeField] private GameObject _pointAttack;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _enemy;
        [SerializeField] private float _damage;

        private bool _isAttack;


        private void Start()
        {
            _animationManager = GetComponent<AnimationManager>();
        }

        public void StartAttack()
        {
            _isAttack = true;
        }

        public void Attack()
        {
            if (_isAttack)
            {
                _animationManager.PlayAttack();
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