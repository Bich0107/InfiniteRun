using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpike : ActivatableObject
{
    [SerializeField] MovingObject[] spikes;
    [SerializeField] float dropDelay;
    WaitForSeconds dropWait;

    void Start()
    {
        dropWait = new WaitForSeconds(dropDelay);
    }

    public override void Activate()
    {
        if (activated) return;
        StartCoroutine(CR_Activate());
    }

    IEnumerator CR_Activate()
    {
        activated = true;
        for (int i = 0; i < spikes.Length; i++)
        {
            spikes[i].SetMoveStatus(true);
            yield return dropWait;
        }
    }
}
