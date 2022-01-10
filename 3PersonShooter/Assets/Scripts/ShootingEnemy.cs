using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField]
    float distanciaDisparo;

    //[SerializeField]
    //LayerMask playerLayer;

    [SerializeField]
    float tiempoEntreDisparos;
    float timer;
    protected override void Act()
    {
        agent.isStopped = true;
        timer += Time.deltaTime;
        if (timer > tiempoEntreDisparos)
        {
            timer = 0;
            RaycastHit infoImpacto;
            Vector3 direccion = (GameManager.Instance.Player.transform.position - transform.position);
            animator.SetTrigger("Shooting");
            //Debug.DrawRay(transform.position + direccion.normalized, direccion, Color.red);
            if (Physics.Raycast(transform.position /*+ direccion.normalized*/, direccion, out infoImpacto, distanciaDisparo))
            {
                //print(infoImpacto.transform);
                if (infoImpacto.transform.TryGetComponent(out FPSCharacterController player))
                {                    
                    player.RecibirImpacto();
                }
            }
        }
    }
}
