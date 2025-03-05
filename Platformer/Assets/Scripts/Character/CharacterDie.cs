using System;
using System.Collections;
using System.Security.Cryptography;
using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterDie : MonoBehaviour, IDieable
    {
        private Animator _animator; 
        private HealthSystem _healthSystem;
        private CharacterBehaviour _characterBehaviour;
        [SerializeField] private GameManager _gameManager;
        
        private void Start()
        {
            _characterBehaviour = GetComponent<CharacterBehaviour>();
            _healthSystem = GetComponent<HealthSystem>();
            _animator = GetComponent<Animator>();
            _healthSystem.OnDeath += Die;
        }

        private void OnDestroy()
        {
            _healthSystem.OnDeath -= Die;
        }

        public void Die()
        {
            StartCoroutine(Death());
        }

        private IEnumerator Death()
        {
            _characterBehaviour.StopLife();
            _animator.SetTrigger("Death");
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            _gameManager.ShowLoseMenu();
        }
    }
}