using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int enemyHp = 2;
    public int enemyActualHp;
    public float enemyActualSpeed;
    public float enemySpeedWalk;
    public float enemySpeedRun;
    public float enemyVisionDistance;
    public float enemyHearingDistance;
    public float enemyAngleVision;
    public Animator animator;
    public bool alertHearing;
    public bool alertVision;
    public bool alert;
    float maxSpeed;
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public float waitTimeOnArrival = 1;
    private bool isWaiting;
    Vector3 posicionUltimoFrame;

    // Start is called before the first frame update
    public virtual void Start()
    {
        posicionUltimoFrame = transform.position;
        if (!animator)
            animator = GetComponentInChildren<Animator>();
        enemyActualHp = enemyHp;
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
        maxSpeed = agent.speed;
    }
    public virtual void RecibirDaño()
    {
        enemyActualHp--;
        if (enemyActualHp <= 0)
        {
            Morir();
        }
    }
    public virtual void DetectarJugador()
    {
        DeteccionOido();
        DeteccionVision();
    }

    public virtual void DeteccionVision()
    {
        RaycastHit infoImpact;
        alertVision = false;
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < enemyVisionDistance)
        {
            Vector3 direccionHaciaJugador = GameManager.Instance.Player.transform.position - transform.position;
            Vector3 direccionVisionEnemy = transform.forward;
            if (Vector3.Angle(direccionHaciaJugador, direccionVisionEnemy) <= enemyAngleVision * 0.5)
            {
                if (Physics.Raycast(transform.position, direccionHaciaJugador, out infoImpact, enemyVisionDistance))
                {
                    if (infoImpact.transform == GameManager.Instance.Player.transform)
                    {
                        alertVision = true;
                    }
                }
            }
        }
        ComprobarAlerta();
    }

    public virtual void DeteccionOido()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < enemyHearingDistance)
        {
            alertHearing = true;
        }
        else
        {
            alertHearing = false;
        }
        ComprobarAlerta();
    }
    public virtual void Morir()
    {
        if (animator)
            animator.SetTrigger("morir");
        Destroy(gameObject, 2);
    }
    public virtual void ComprobarAlerta()
    {
        alert = (alertHearing || alertVision) && !GameManager.Instance.AlarmaDada;
        if (alert)
        {
            transform.forward = (GameManager.Instance.Player.transform.position - transform.position).normalized;/*Vector3.Lerp(transform.forward, (GameManager.Instance.Player.transform.position - transform.position).normalized,)*/
        }
    }

    public virtual void Update()
    {
        if (enemyActualHp <= 0)
            return;
        DeteccionOido();
        DeteccionVision();
        Patrullar();
        float velocidadActual = (transform.position - posicionUltimoFrame).magnitude / Time.deltaTime;
        //print(velocidadActual);
        animator.SetFloat("Movimiento", (velocidadActual) / agent.speed);
        posicionUltimoFrame = transform.position;
    }

    protected virtual void Patrullar()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !alert)
        {
            agent.isStopped = false;
            
            if (!isWaiting)
                StartCoroutine(WaitOnPatrol());
        }
        else if (alert)
        {
            Act();
        }
    }

    IEnumerator WaitOnPatrol()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeOnArrival);
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPatrolPoint].position);
        isWaiting = false;
    }


    protected virtual void Act()
    {

    }
}
