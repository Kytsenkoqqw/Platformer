using System;
using System.Collections;
using System.Security.Cryptography;
using Animation;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterDie : MonoBehaviour, IDieable
    {
        private AnimationManager _animationManager;
        private HealthSystem _healthSystem;
        private CharacterBehaviour _characterBehaviour;
        [SerializeField] private GameManager _gameManager;
        private CircleCollider2D _circleCollider2D;
        
        private void Start()
        {
            _characterBehaviour = GetComponent<CharacterBehaviour>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _healthSystem = GetComponent<HealthSystem>();
            _animationManager = GetComponent<AnimationManager>();
            _healthSystem.OnDeath += Death;
        }

        private void OnDestroy()
        {
            _healthSystem.OnDeath -= Death;
        }

        public void Death()
        {
            StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            _circleCollider2D.enabled = false;
            _characterBehaviour.StopLife();
            _animationManager.PlayDeath();
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            _gameManager.ShowLoseMenu();
        }
    }
}