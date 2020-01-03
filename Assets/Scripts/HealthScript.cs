using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider healthIndicator;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        print(health.ToString());
    }

    private void Awake()
    {  
        healthIndicator.value = CalculateHealth();
    }

    void Update()
    {
        healthIndicator.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        isDead();

        if (health > maxHealth)
        {
            health = maxHealth;   //have health reset back to max health and not go over
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;  //if we have 100/100 then slider will return value of 1 (full)
    }

    public bool isDead()
    {
        if (health <= 0)
        {
            return true; 
        }
        else
            return false;
    }

}
