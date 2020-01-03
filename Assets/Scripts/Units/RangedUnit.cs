using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RangedUnit : MonoBehaviour
{
    public Unit rangedUnit = new Unit();
    //public LayerMask layer;

    private UnitState ranged_State;
    public GameObject attackPoint;
    public LayerMask enemyLayer;

    public string enemyBuilding;
    public string enemyUnit;

    int enemyCode;

    private float timer = 0.0f;

    //private string enemyTag;

    void Awake()
    {
        rangedUnit.navAgent = GetComponent<NavMeshAgent>();
        //GetTarget();

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

        GetTarget();
    }

    void Update()
    {
        if (ranged_State == UnitState.MOVE)
        {
            rangedUnit.Move(transform.position, rangedUnit.target.position);
        }

        if (ranged_State == UnitState.ATTACK)
        {

            
            rangedUnit.Attack(transform.position);
        }
        timer += Time.deltaTime;
        checkCollison();


    }

    // Update is called once per frame
    private void checkCollison()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            Debug.Log("worked!");

            hits[0].GetComponent<HealthScript>().ApplyDamage(rangedUnit.damage);

            //CoolDown();

            if (GetComponent<HealthScript>().isDead())
            {
                GetTarget();
            }

        }

    }

    private void CoolDown()
    {

        attackPoint.SetActive(false);
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > rangedUnit.coolDownAfterAttack)
        {
            attackPoint.SetActive(true);
            // Remove the recorded 2 seconds.


        }
    }

    private void GetTarget()
    {
        enemyCode = Random.Range(0, 2); // picks random target to attack 
        if (enemyCode == 1)
        {
            rangedUnit.target = GameObject.FindGameObjectWithTag(enemyBuilding).transform; // unit find unit on oposing team
        }
        else
        {
            if (enemyCode == 2)
            {
                rangedUnit.target = GameObject.FindGameObjectWithTag(enemyUnit).transform; // unit find unit on oposing team
            }
            else
            {
                rangedUnit.target = GameObject.FindGameObjectWithTag("WizardTeam").transform; // unit find unit on  wizard team
            }


        }
    }



}
