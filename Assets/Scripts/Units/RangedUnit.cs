using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RangedUnit : MonoBehaviour
{
    Unit rangedUnit = new Unit();
    //public LayerMask layer;

    private UnitState ranged_State;
    public GameObject attackPoint1;
    public GameObject attackPoint2;
    public LayerMask enemyLayer;

   

    //private string enemyTag;

    void Awake()
    {
        rangedUnit.navAgent = GetComponent<NavMeshAgent>();
        rangedUnit.target = GameObject.FindGameObjectWithTag("RedTeam").transform; // unit find unit on oposing team

        rangedUnit.attackRange = 1f;
        rangedUnit.coolDownAfterAttack = 20f;
        rangedUnit.attackTime = 1f;
        rangedUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        rangedUnit.speed = 3.5f;

        rangedUnit.damage = 2f;




    }
    void Start()
    {
        ranged_State = UnitState.MOVE; //unit is set to move initially
        rangedUnit.attackTime = rangedUnit.coolDownAfterAttack;
    }

    void Update()
    {
        if (ranged_State == UnitState.MOVE)
        {
            rangedUnit.Move(transform.position);
        }

        if (ranged_State == UnitState.ATTACK)
        {

            attackPoint1.SetActive(true);
            attackPoint2.SetActive(true);
            rangedUnit.Attack(transform.position);
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

            hits[0].GetComponent<HealthScript>().ApplyDamage(rangedUnit.damage);
            attackPoint1.SetActive(false);
            attackPoint2.SetActive(false);
            yield return new WaitForSeconds(rangedUnit.coolDownAfterAttack);

        }

    }



}
