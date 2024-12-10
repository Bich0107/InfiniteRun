using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : CustomAnimation
{
    [SerializeField] Vector3 offset;

    public override IEnumerator Play()
    {
        tick = 0f;
        Vector3 startValue = target.localPosition;
        Vector3 endValue = target.localPosition + offset;
        while (tick < duration)
        {
            tick += Time.deltaTime;
            target.localPosition = Vector3.Lerp(startValue, endValue, tick / duration);
            yield return null;
        }
    }
}
