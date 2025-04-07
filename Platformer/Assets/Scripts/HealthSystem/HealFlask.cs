using System;
using UnityEngine;

public class HealFlask : MonoBehaviour
{
    [SerializeField] private float _healValue;
    [SerializeField] private HealthSystem _healthSystem;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterBehaviour>())
        {
            _healthSystem.Heal(_healValue);
            Destroy(gameObject);
        }
    }
}
