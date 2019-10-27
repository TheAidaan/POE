using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedUnit : MonoBehaviour
{
    Unit rangedUnit = new Unit();

    private UnitState ranged_State;
    public GameObject attackPoint;

    void Awake()
    {
        rangedUnit.navAgent = GetComponent<NavMeshAgent>();
        rangedUnit.target = GameObject.FindGameObjectWithTag("RedTeam").transform; // unit find unit on oposing team
        rangedUnit.attackRange = 1f;
        rangedUnit.coolDownAfterAttack = 2f;
        rangedUnit.attackTime = 1f;
        rangedUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        rangedUnit.speed = 3.5f;
    }
    void Start()
    {
        ranged_State = UnitState.MOVE; //unit is set to move initially
        rangedUnit.attackTime = rangedUnit.coolDownAfterAttack;
    }

    private void Update()
    {
        if (ranged_State == UnitState.MOVE)
        {
            rangedUnit.Move(transform.position);
        }
        if (ranged_State == UnitState.ATTACK)
        {
            rangedUnit.Attack(transform.position);
        }
    }


}
