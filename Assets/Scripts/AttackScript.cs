using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private float timer = 0f;

    private float coolDownAfterAttack = 3f;
    public GameObject attackPoint;

    void Update()
    {
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    public void checkCollison(float damage, LayerMask enemyLayer)
    {
        Collider[] hits = Physics.OverlapSphere(attackPoint.transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            Debug.Log("worked!");

            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);
            CoolDown();

        }

    }
    private void CoolDown()
    {

        attackPoint.SetActive(false);
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > coolDownAfterAttack)
        {
            attackPoint.SetActive(true);
            // Remove the recorded 2 seconds.


        }
    }
}
