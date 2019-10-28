using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WizardUnit : MonoBehaviour
{
    Unit wizardUnit = new Unit();
    //public LayerMask layer;

    private UnitState wizard_State;
    public GameObject attackPoint1;
    public GameObject attackPoint2;
    public LayerMask enemyLayer;

    public string enemyTeam;

    int enemyCode;

    private float timer = 0.0f;

    //private string enemyTag;

    void Awake()
    {
        wizardUnit.navAgent = GetComponent<NavMeshAgent>();
        enemyCode = Random.RandomRange(0, 2);
        if (enemyCode == 1)
        {
            wizardUnit.target = GameObject.FindGameObjectWithTag("OrangeTeam").transform; // unit find unit on oposing team
        }else
        {
            wizardUnit.target = GameObject.FindGameObjectWithTag("PurpleTeam").transform; // unit find unit on oposing team
        }
       

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
    }

    void Update()
    {
        if (wizard_State == UnitState.MOVE)
        {
            wizardUnit.Move(transform.position);
        }

        if (wizard_State == UnitState.ATTACK)
        {


            wizardUnit.Attack(transform.position);
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

            hits[0].GetComponent<HealthScript>().ApplyDamage(wizardUnit.damage);

            CoolDown();

        }

    }

    private void CoolDown()
    {

        attackPoint1.SetActive(false);
        attackPoint2.SetActive(false);
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > wizardUnit.coolDownAfterAttack)
        {
            attackPoint1.SetActive(true);
            attackPoint2.SetActive(true);
            // Remove the recorded 2 seconds.


        }
    }



}
