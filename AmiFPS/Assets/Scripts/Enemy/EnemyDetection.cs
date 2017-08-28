using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour 
{
    EnemyMaster enemyMaster;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    public float detectionRadius = 40;

    private float checkRate;
    private float nextCheck;
    private RaycastHit hit;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

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
        CarryOutDetection();
    }

    private void SetInitialReferences()
    {
        enemyMaster = GetComponent<EnemyMaster>();
        if (head == null)
            head = transform;
        checkRate = Random.Range(0.8f, 1.2f);
    }


    void CarryOutDetection()
    {
        if(Time.time > nextCheck )
        {
            nextCheck = Time.time + checkRate;
            Collider[] colliders = Physics.OverlapSphere(transform.position,
                detectionRadius, playerLayer);
            if (colliders.Length > 0)
            {
                foreach(Collider collider in colliders)
                {
                    if (collider.CompareTag("Player"))
                    {
                        if (CanTargetBeSeen(collider.transform))
                            break;
                    }
                }
            }
            else
            {
                enemyMaster.CallEnemyLostTarget();
            }
        }
    }

    bool CanTargetBeSeen(Transform potentialTarget)
    {
        if (Physics.Linecast(head.position, potentialTarget.position,
            out hit, sightLayer))
        {
            if (hit.transform == potentialTarget)
            {
                enemyMaster.CallEnemySetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                enemyMaster.CallEnemyLostTarget();
                return false;
            }
        }
        enemyMaster.CallEnemyLostTarget();
        return false;
    }

    void DisableThis()
    {
        enabled = this;
    }




}
