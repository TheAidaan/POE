using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WizardUnit : MonoBehaviour
{
    Unit wizardUnit = new Unit();
    public GameObject attackPoint;
    //public LayerMask layer;

    private UnitState wizard_State;
    
    private LayerMask enemyLayer;


    int enemyCode;

    private float timer = 0.0f;

    //private string enemyTag;

    void Awake()
    {
        wizardUnit.navAgent = GetComponent<NavMeshAgent>();
       // GetTarget();

        wizardUnit.attackRange = 1f;
        wizardUnit.coolDownAfterAttack = 20f;
        wizardUnit.attackTime = 1f;
        wizardUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        wizardUnit.speed = 3.5f;

        wizardUnit.damage = 2f;


    }
    void Start()
    {
        wizard_State = UnitState.MOVE; //unit is set to move initially
        wizardUnit.attackTime = wizardUnit.coolDownAfterAttack;

        GetTarget();
    }

    void Update()
    {
        if (GetComponent<HealthScript>().isDead())
        {
            gameObject.name = "Dead";
            Destroy(gameObject);
        }

        if (wizard_State == UnitState.MOVE)
        {
            if (gameObject.name == "Dead")
            {
                Destroy(gameObject);
            }
            else
            { wizardUnit.Move(transform.position, wizardUnit.target.position); }
        }

        if (wizard_State == UnitState.ATTACK)
        { 
            wizardUnit.Attack(transform.position);
        }
        timer += Time.deltaTime;
        checkCollison();

       

        if (wizardUnit.target.gameObject.name == ("Dead"))
        {
            GetTarget();
        }




    }

    // Update is called once per frame
    private void checkCollison()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<HealthScript>().ApplyDamage(wizardUnit.damage);

        }

    }

    private void CoolDown()
    {

        attackPoint.SetActive(false);
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > wizardUnit.coolDownAfterAttack)
        {
            attackPoint.SetActive(true);
            // Remove the recorded 2 seconds.


        }
    }

    private void GetTarget()
    {
        enemyCode = Random.Range(0, 1); // picks random target to attack 
        if (enemyCode == 1)
        {
            wizardUnit.target = GameObject.FindGameObjectWithTag("OrangeUnit").transform; // unit find unit on oposing team
            enemyLayer = LayerMask.GetMask("OrangeTeam");
        }
        else
        {
            wizardUnit.target = GameObject.FindGameObjectWithTag("PurpleUnit").transform; // unit find unit on oposing team
            enemyLayer = LayerMask.GetMask("PurpleTeam");
        }
    }



}
