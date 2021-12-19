using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyActualHp = enemyHp;
    }
    public virtual void RecibirDaño()
    {
        enemyActualHp--;
        if (enemyActualHp < 0)
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
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < enemyVisionDistance)
        {
            Vector3 direccionHaciaJugador = GameManager.Instance.Player.transform.position - transform.position;
            Vector3 direccionVisionEnemy = transform.forward;
            if (Vector3.Angle(direccionHaciaJugador, direccionVisionEnemy)<= enemyAngleVision * 0.5)
            {
                if(Physics.Raycast(transform.position,direccionHaciaJugador,out infoImpact, enemyVisionDistance))
                {
                    if(infoImpact.transform == GameManager.Instance.Player.transform)
                    {
                        Alerta();
                    }
                }
            }
        }
    }
    public virtual void DeteccionOido()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < enemyHearingDistance)
        {
            Alerta();
        }
    }
    public virtual void Morir()
    {
        animator.SetTrigger("morir");
        Destroy(gameObject,2);
    }
    public virtual void Alerta()
    {

    }
}
