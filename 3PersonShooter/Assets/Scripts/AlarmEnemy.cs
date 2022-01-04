using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEnemy : Enemy
{

    public override void Alerta()
    {
        base.Alerta();
        DarAlarma();
    }

    public void DarAlarma()
    {

    }
}
