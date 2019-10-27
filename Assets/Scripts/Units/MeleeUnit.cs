using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
    Unit meleeUnit = new Unit();

    private UnitState melee_State;
    public GameObject attackPoint;

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
    }


}
