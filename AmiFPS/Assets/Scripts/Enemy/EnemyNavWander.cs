using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavWander : MonoBehaviour 
{
    private EnemyMaster enemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;
    private NavMeshHit navHit;
    private Vector3 wanderTarget;

    public float wanderRange = 10;

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
            CheckIfShouldWander();
        }
    }

    private void SetInitialReferences()
    {
        enemyMaster = GetComponent<EnemyMaster>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.1f, 0.2f);
    }

    public void CheckIfShouldWander()
    {
       if (enemyMaster.target == null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused)
        {
            if (RandomWanderTarget(transform.position, wanderRange, out wanderTarget))
            {
                myNavMeshAgent.SetDestination(wanderTarget);
                enemyMaster.isOnRoute = true;
                enemyMaster.CallEnemyWalking();
            }
        }
    }

    bool RandomWanderTarget(Vector3 centre, float range, out Vector3 result)
    {
        Vector3 randomPoint = centre + Random.insideUnitSphere * wanderRange;
        if (NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        result = centre;
        return false;

    }



    void DisableThis()
    {
        if (myNavMeshAgent != null)
            myNavMeshAgent.enabled = true;
        enabled = this;
    }

}
