using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : CustomAnimation
{
    [SerializeField] Vector3 endPos;
    [SerializeField] Vector3 offset;

    void Start()
    {
        endPos = target.localPosition + offset;
    }

    public override IEnumerator Play()
    {
        tick = 0f;
        Vector3 startValue = target.localPosition;
        while (tick < duration)
        {
            tick += Time.deltaTime;
            target.localPosition = Vector3.Lerp(startValue, endPos, tick / duration);
            yield return null;
        }
    }
}
