using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavPursuit : MonoBehaviour 
{

    private EnemyMaster enemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EnemyDie += DisableThis;
    }

    private void OnDisable()
    {
        enemyMaster.EnemyDie -= DisableThis;
    }

    private void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            TryToChaseTarget();
        }
    }

    private void SetInitialReferences()
    {
        enemyMaster = GetComponent<EnemyMaster>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.1f, 0.2f);
    }

    public void TryToChaseTarget()
    {
        if (enemyMaster.target != null && myNavMeshAgent != null && !enemyMaster.isNavPaused)
        {
            myNavMeshAgent.SetDestination(enemyMaster.target.position);

            if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
            {
                enemyMaster.CallEnemyWalking();
                enemyMaster.isOnRoute = true;
            }
        }
    }



    void DisableThis()
    {
        if (myNavMeshAgent != null)
            myNavMeshAgent.enabled = true;
        enabled = this;
    }


}
