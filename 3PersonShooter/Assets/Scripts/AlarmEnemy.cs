using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEnemy : Enemy
{

    public override void ComprobarAlerta()
    {
        base.ComprobarAlerta();
        DarAlarma();
    }

    public void DarAlarma()
    {

    }
}
