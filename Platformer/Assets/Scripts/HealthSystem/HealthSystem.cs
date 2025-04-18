using System;
using Character;
using ObjectBehaviour;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Action OnDeath;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _hp;
    
    public float currentHeath;

    private void Start()
    {
        currentHeath = _maxHealth;
        
        ValueHealthChanged();
    }

    public void Heal(float heal)
    {
        currentHeath += heal;

        if (currentHeath >= 100)
        {
            currentHeath = 100;
        }
        ValueHealthChanged();
    }

    public void TakeDamage(float damage)
    {
        currentHeath -= damage;

        if (currentHeath <= 0)
        {
            currentHeath = 0;
            Die();
        }
        
        ValueHealthChanged();
    }

    public void ValueHealthChanged()
    {
        float fillAmount = (float)currentHeath / _maxHealth;
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
