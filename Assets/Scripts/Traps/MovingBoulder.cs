using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoulder : ActivatableObject
{
    [SerializeField] MovingObject movingObject;
    [SerializeField] DangerObject dangerObject;

    public override void Activate()
    {
        movingObject.SetMoveStatus(true);
        dangerObject.SetHurtStatus(true);
    }
}
