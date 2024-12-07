using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : ActivatableObject
{
    [SerializeField] Transform targetTrans;
    [SerializeField] float angle;
    [SerializeField] float duration;
    bool rotating = false;

    Quaternion baseRotation;

    void Start()
    {
        baseRotation = targetTrans.localRotation;
    }

    public override void Activate()
    {
        if (rotating) return;

        rotating = true;
        StartCoroutine(CR_Rotate());
    }

    IEnumerator CR_Rotate()
    {
        float tick = 0f;

        Quaternion startRotation = targetTrans.localRotation;
        Quaternion endRotation = targetTrans.localRotation * Quaternion.AngleAxis(angle, Vector3.forward);

        while (tick < duration)
        {
            tick += Time.deltaTime;
            targetTrans.localRotation = Quaternion.Lerp(startRotation, endRotation, tick / duration);
            yield return null;
        }

        rotating = false;
    }

    public void Reset()
    {
        targetTrans.localRotation = baseRotation;
    }
}
