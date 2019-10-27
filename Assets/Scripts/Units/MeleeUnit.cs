using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MeleeUnit : MonoBehaviour
{
    Unit meleeUnit = new Unit();

    HealthScript health = AddComponent<HealthScript>();
    //public LayerMask layer;

    private UnitState melee_State;
    public GameObject attackPoint1;
    public GameObject attackPoint2;
    public LayerMask enemyLayer;


    //private string enemyTag;

    void Awake()
    {       
        meleeUnit.navAgent = GetComponent<NavMeshAgent>();
        meleeUnit.target = GameObject.FindGameObjectWithTag("RedTeam").transform; // unit find unit on oposing team

        meleeUnit.attackRange = 1f;
        meleeUnit.coolDownAfterAttack = 20f;
        meleeUnit.attackTime = 1f;
        meleeUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        meleeUnit.speed = 3.5f;

        meleeUnit.damage = 2f;
        health.health = health.maxHealth;

    }

    void Start()
    {
        melee_State = UnitState.MOVE; //unit is set to move initially
        meleeUnit.attackTime = meleeUnit.coolDownAfterAttack;
    }

    void Update()
    {
        if (melee_State == UnitState.MOVE)
        {
            meleeUnit.Move(transform.position);
        }

        if (melee_State == UnitState.ATTACK)
        {
            
            attackPoint1.SetActive(true);
            attackPoint2.SetActive(true);
            meleeUnit.Attack(transform.position);
        }
       

        StartCoroutine(checkCollison());
       

    }

    // Update is called once per frame
    IEnumerator checkCollison()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            Debug.Log("worked!");

            hits[0].GetComponent<HealthScript>().ApplyDamage(meleeUnit.damage);
            attackPoint1.SetActive(false);
            attackPoint2.SetActive(false);
            yield return new WaitForSeconds(meleeUnit.coolDownAfterAttack);

        }

    }



}
