using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float damage = 1f;
    public float radius = .3f;

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);
        if (hits.Length > 0)
        {
            print("worked!");
            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);
            gameObject.SetActive(false);
            
        }

    }
}
