using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEnemy : Enemy
{
    [SerializeField] Transform alarma;


    protected override void Act()
    {
        agent.SetDestination(alarma.position);
    }

    public override void Update()
    {
        base.Update();
        if(alert && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GameManager.Instance.AlertarATodosLosEnemigos();
        }
    }
}
