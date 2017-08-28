using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour 
{
    public Transform target;
    public bool isOnRoute;
    public bool isNavPaused;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EnemyDie;
    public event GeneralEventHandler EnemyWalking;
    public event GeneralEventHandler EnemyReachedTarget;
    public event GeneralEventHandler EnemyAttack;
    public event GeneralEventHandler EnemyLostTarget;

    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler DeductHealth;

    public delegate void NavTargetEventTarget(Transform targetTarnsform);
    public event NavTargetEventTarget EnemySetNavTarget;


    public void CallEnemyDie()
    {
        if (EnemyDie != null)
        {
            EnemyDie();
        }
    }

    public void CallEnemyWalking()
    {
        if (EnemyWalking != null)
        {
            EnemyWalking();
        }
    }

    public void CallEnemyAttack()
    {
        if (EnemyAttack != null)
        {
            EnemyAttack();
        }
    }

    public void CallEnemyReachedTarget()
    {
        if (EnemyReachedTarget != null)
        {
            EnemyReachedTarget();
        }
    }


    public void CallEnemyLostTarget()
    {
        if (EnemyLostTarget != null)
            EnemyLostTarget();
        target = null;
    }

    public void CallEnemySetNavTarget(Transform targetTarnsform)
    {
        if (EnemySetNavTarget != null)
            EnemySetNavTarget(targetTarnsform);
        target = targetTarnsform;
    }

    public void CallDeductHealth(int health)
    {
        if (DeductHealth != null)
        {
            DeductHealth(health);
        }
    }






}
