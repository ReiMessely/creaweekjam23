using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthAmount = 10;
    private float _maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = _healthAmount;
    }

    public void TakeDamage(float damage)
    {
        _healthAmount -= damage;
    }

    public float HealthPercentage
    {
        get
        {
            return _healthAmount / _maxHealth;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return _healthAmount;
        }
    }

    public float MaxHealth
    {
        get 
        { 
            return _maxHealth; 
        }
    }

    public bool IsDead
    {
        get 
        {
            return (_healthAmount <= 0);
        }
    }
}
