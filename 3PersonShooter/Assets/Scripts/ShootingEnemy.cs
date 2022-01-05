using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public override void ComprobarAlerta()
    {
        base.ComprobarAlerta();
        Disparar();
    }

    public void Disparar()
    {

    }
}
