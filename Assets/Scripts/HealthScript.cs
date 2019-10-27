using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100;
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

    private void Update()
    {
        if(playerDied)
        {
            print("murder");
        }
    }

}
