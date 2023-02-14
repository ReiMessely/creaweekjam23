using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAmount = 10;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
    }

    public float HealthPercentage
    {
        get
        {
            return healthAmount / maxHealth;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return healthAmount;
        }
    }

    public float MaxHealth
    {
        get 
        { 
            return maxHealth; 
        }
    }

    public bool IsDead
    {
        get 
        {
            return (healthAmount <= 0);
        }
    }
}
