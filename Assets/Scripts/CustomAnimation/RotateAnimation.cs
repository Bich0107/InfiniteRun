using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateAnimation : CustomAnimation
{
    [SerializeField] float angle;
    [SerializeField] Vector3 axis;

    public override IEnumerator Play()
    {
        tick = 0f;
        Quaternion startValue = target.localRotation;
        Quaternion endValue = startValue * Quaternion.AngleAxis(angle, axis);
        while (tick < duration)
        {
            tick += Time.deltaTime;
            target.localRotation = Quaternion.Lerp(startValue, endValue, tick / duration);
            yield return null;
        }
    }
}