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

    public bool playerDied;
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        print(health.ToString());

        if (health<=0)
        {
            playerDied = true;
        }
    }

    private void Awake()
    {
        maxHealth = 10f;
        healthIndicator.value = CalculateHealth();
    }

    void Update()
    {
        if(playerDied)
        {
            print("murder");
            Destroy(gameObject);
        }

        healthIndicator.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;   //have health reset back to max health and not go over
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;  //if we have 100/100 then slider will return value of 1 (full)
    }

}
