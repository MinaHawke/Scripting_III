using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public override void Alerta()
    {
        base.Alerta();
        Disparar();
    }

    public void Disparar()
    {

    }
}
