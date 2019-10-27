using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardUnit : MonoBehaviour
{
    Unit wizardUnit = new Unit();

    private UnitState wizard_State;
    public GameObject attackPoint;

    void Awake()
    {
        wizardUnit.navAgent = GetComponent<NavMeshAgent>();
        wizardUnit.target = GameObject.FindGameObjectWithTag("RedTeam").transform; // unit find unit on oposing team
        wizardUnit.attackRange = 1f;
        wizardUnit.coolDownAfterAttack = 2f;
        wizardUnit.attackTime = 1f;
        wizardUnit.chaseDistance = 1f; // distance the unit needs before chasing the attacking unit
        wizardUnit.speed = 3.5f;
    }
    void Start()
    {
        wizard_State = UnitState.MOVE; //unit is set to move initially
        wizardUnit.attackTime = wizardUnit.coolDownAfterAttack;
    }

    private void Update()
    {
        if (wizard_State == UnitState.MOVE)
        {
            wizardUnit.Move(transform.position);
        }
        if (wizard_State == UnitState.ATTACK)
        {
            wizardUnit.Attack(transform.position);
        }
    }


}