using System;
using Collectables;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeath :  MonoBehaviour
    {
        private HealthSystem _healthSystem;

        private void Start()
        {
            _healthSystem = GetComponent<HealthSystem>();
            _healthSystem.OnDeath += Die;
        }

        private void OnDestroy()
        {
            _healthSystem.OnDeath -= Die;
        }

        private void Die()
        {
            Debug.Log("enemy is die");
            Destroy(gameObject);
        }
        
    }
}