using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthAmount = 10;
    private float _maxHealth;

    public delegate void OnDeathAction();
    public static event OnDeathAction OnDeath;

    bool _isDying;

    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = _healthAmount;
    }

    public void TakeDamage(float damage)
    {
        if (_isDying) { return; }

        _healthAmount -= damage;
      
        Math.Clamp(_healthAmount, 0, _healthAmount);
        if (_healthAmount > 0)
            return;

        if (gameObject.tag == "Player")
        {
            if (!_isDying)
            {
                Invoke("Kill", 5f);
                _isDying= true;
            }
           
        }
        else if (OnDeath != null)
        {
            OnDeath();
            Destroy(gameObject);
        }



    }

    private void Kill()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);

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