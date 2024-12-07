using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrap : ActivatableObject
{
    [SerializeField] Transform trapBody;
    [SerializeField] float popDistance;
    [SerializeField] float popDuration;
    float popDirection;

    void Start()
    {
        popDirection = transform.position.y > Mathf.Epsilon ? -1f : 1f;
    }

    public override void Activate()
    {
        activated = true;
        StartCoroutine(CR_MoveBody());
    }

    IEnumerator CR_MoveBody()
    {
        float tick = 0f;
        Vector2 startPos = trapBody.localPosition;
        Vector2 endPos = trapBody.localPosition + Vector3.up * popDirection * popDistance;
        while (tick < popDuration)
        {
            tick += Time.deltaTime;
            trapBody.localPosition = Vector2.Lerp(startPos, endPos, tick / popDuration);
            yield return null;
        }
    }

    void OnDisable()
    {
        activated = false;
    }
}
