using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform body;
    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] float randomAngle;
    [SerializeField] float randomAngleDuration;
    [SerializeField] bool isBusy = false;
    bool randomTrigger = false;

    void FixedUpdate()
    {
        RandomRotation();
        Rotate();
    }

    public void Rotate()
    {
        if (target == null || isBusy) return;

        direction = (target.position - body.position).normalized;

        Vector3 forwardVector = Vector3.Cross(direction, Vector3.up);
        Quaternion targetRotation = Quaternion.LookRotation(forwardVector, direction);

        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
    }

    void RandomRotation()
    {
        if (randomTrigger || target == null || Mathf.Abs(randomAngle) < Mathf.Epsilon) return;

        randomTrigger = true;
        isBusy = true;

        int randomAxis = Random.Range(0, 4);
        Quaternion rotation = Quaternion.identity;
        switch (randomAxis)
        {
            case 0:
                rotation = Quaternion.AngleAxis(randomAngle, body.right);
                break;
            case 1:
                rotation = Quaternion.AngleAxis(randomAngle, body.forward);
                break;
            case 2:
                rotation = Quaternion.AngleAxis(-randomAngle, body.right);
                break;
            case 3:
                rotation = Quaternion.AngleAxis(-randomAngle, body.forward);
                break;
        }
        StartCoroutine(CR_RandomRotation(rotation));
    }

    IEnumerator CR_RandomRotation(Quaternion _rotation)
    {
        float tick = 0;
        Quaternion startValue = body.localRotation;
        Quaternion endValue = startValue * _rotation;
        while (tick < randomAngleDuration)
        {
            tick += Time.fixedDeltaTime;
            body.localRotation = Quaternion.Slerp(startValue, endValue, tick / randomAngleDuration);
            yield return null;
        }

        isBusy = false;
    }

    public void SetTarget(Transform _target)
    {
        randomTrigger = false;
        target = _target;
    }
    public void SetRandomAngle(float _value) => randomAngle = _value;
    public void SetRotateSpeed(float _value) => rotateSpeed = _value;
}
