using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MeleeUnit : MonoBehaviour
{
    Unit meleeUnit = new Unit();

    //public LayerMask layer;

    private UnitState melee_State;
    public GameObject attackPoint1;
    public GameObject attackPoint2;
    public LayerMask enemyLayer;

    public string enemyTeam;

    private float waitTime = 1223.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float scrollBar = 1.0f;


    //private string enemyTag;

    void Awake()
    {       
        meleeUnit.navAgent = GetComponent<NavMeshAgent>();
        meleeUnit.target = GameObject.FindGameObjectWithTag(enemyTeam).transform; // unit find unit on oposing team

        meleeUnit.attackRange = 1f;
        meleeUnit.coolDownAfterAttack = 20f;
        meleeUnit.attackTime = 1f;
        meleeUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        meleeUnit.speed = 3.5f;

        meleeUnit.damage = 2f;

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
            
           
            meleeUnit.Attack(transform.position);
        }
       

        checkCollison();
       

    }

    // Update is called once per frame
    private void checkCollison()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            Debug.Log("worked!");

            hits[0].GetComponent<HealthScript>().ApplyDamage(meleeUnit.damage);
            attackPoint1.SetActive(false);
            attackPoint2.SetActive(false);
            CoolDown();

        }

    }

    private void CoolDown()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;
            attackPoint1.SetActive(true);
            attackPoint2.SetActive(true);
            // Remove the recorded 2 seconds.
            waitTime += 3f;
            
        }
    }
}



