using System;
using ObjectBehaviour;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Action OnDeath;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _hp;
    
    public float _currentHeath;

    private void Start()
    {
        _currentHeath = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHeath -= damage;

        if (_currentHeath <= 0)
        {
            _currentHeath = 0;
            Die();
        }
        
        ValueHealthChanged();
    }

    public void ValueHealthChanged()
    {
        float fillAmount = (float)_currentHeath / _maxHealth;
        _hp.fillAmount = fillAmount;
    }

    public void Die()
    {
        OnDeath?.Invoke();
        
        if (TryGetComponent<IDieable>(out var dieable))
        {
            dieable.Death();
        }
    }
}
