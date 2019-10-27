using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
    Unit meleeUnit = new Unit();

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
        meleeUnit.coolDownAfterAttack=2f;
        meleeUnit.attackTime=1f;
        meleeUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        meleeUnit.speed = 3.5f;
    }
    void Start()
    {
        melee_State = UnitState.MOVE; //unit is set to move initially
        meleeUnit.attackTime = meleeUnit.coolDownAfterAttack;
    }

    private void Update()
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

    void Activate_AttackPoint()
    {
        attackPoint1.SetActive(true);
        attackPoint1.SetActive(true);
    }
    void Deactivate_AttackPoint()
    {
        if (attackPoint1.activeInHierarchy)
        {
            attackPoint1.SetActive(false);
        }

        if (attackPoint2.activeInHierarchy)
        {
            attackPoint2.SetActive(false);
        }
    }

    
    public float damage = 1f;
    public float radius = .3f;

    // Update is called once per frame
    public void checkCollison()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f, enemyLayer);
        if (hits.Length > 0)
        {
            Debug.Log("worked!");

            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);
            //gameObject.SetActive(false);

        }

    }


}
