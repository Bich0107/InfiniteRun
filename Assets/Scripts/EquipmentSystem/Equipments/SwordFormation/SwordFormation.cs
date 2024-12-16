using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFormation : Equipment
{
    [SerializeField] FlyingSword[] swords;
    [SerializeField] bool autoAttack = true;


    public override void Use()
    {
        if (!isUsing)
        {
            isUsing = true;
            foreach (FlyingSword sword in swords)
            {
                sword.AutoAttack = autoAttack;
                sword.ChangeState(FlyingSwordState.FindTarget);
            }
        }
        else Stop();
    }

    public void Stop()
    {
        foreach (FlyingSword sword in swords) sword.Stop();
        isUsing = false;
    }
}
