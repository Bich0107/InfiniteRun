using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    [SerializeField] RotateToTarget rotater;
    [SerializeField] SingleAxisMovingObject movingObject;
    [SerializeField] FlyingSwordState currentState;
    [SerializeField] AnimationController[] animations;
    public FlyingSwordState CurrentState => currentState;
    Coroutine delayCoroutine;
    [Space]
    [SerializeField] Transform target;
    [Header("Idle state settings")]
    [Header("Find target state settings")]
    [Header("Aim state settings")]
    [SerializeField] float aimRotateSpeed;
    [SerializeField] float aimDuration;
    [Header("Attack state settings")]
    [SerializeField] float attackSpeed;
    [SerializeField] float returnDelay;
    [Header("Return state settings")]
    [SerializeField] Transform baseTrans;
    [SerializeField] Transform positionBody;
    [SerializeField] Transform rotationBody;
    [SerializeField] Quaternion baseRotation;
    [SerializeField] Vector3 basePos;
    [SerializeField] float stopDistance;
    [Tooltip("Sword will rotate this angle randomly on y or z axis before returning")]
    [SerializeField] float randomRotateAngle;
    [SerializeField] float returnRotateSpeed;
    [SerializeField] float returnDuration;

    void Start()
    {
        ChangeState(FlyingSwordState.Idle);
        basePos = positionBody.localPosition;
        baseRotation = rotationBody.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(FlyingSwordState.Aim);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(FlyingSwordState.Attack);
        }
    }

    #region State processes
    void StateProcess_FindTarget()
    {
        if (target != null)
        {
            ChangeState(FlyingSwordState.Aim);
            return;
        }
    }

    void StateProcess_Aim()
    {
        if (target == null)
        {
            ChangeState(FlyingSwordState.FindTarget);
            return;
        }

        rotater.SetRotateSpeed(aimRotateSpeed);
        rotater.SetRandomAngle(0f);
        rotater.SetTarget(target);

        delayCoroutine = StartCoroutine(CR_Delay(aimDuration, () => ChangeState(FlyingSwordState.Attack)));
    }

    void StateProcess_Attack()
    {
        if (target == null)
        {
            ChangeState(FlyingSwordState.FindTarget);
            return;
        }

        rotater.SetTarget(null);
        movingObject.SetSpeed(attackSpeed);
        movingObject.SetMoveStatus(true);

        // auto return sword if exceed a certain amount of time
        delayCoroutine = StartCoroutine(CR_Delay(returnDelay, () =>
        {
            if (currentState != FlyingSwordState.Return) ChangeState(FlyingSwordState.Return);
        }));
    }

    void StateProcess_Return()
    {
        rotater.SetRotateSpeed(returnRotateSpeed);
        rotater.SetRandomAngle(60f);
        rotater.SetTarget(baseTrans);

        StartCoroutine(CR_ReturnToBaseTransform(() => ChangeState(FlyingSwordState.Idle)));
    }

    IEnumerator CR_ReturnToBaseTransform(Action _endAction)
    {
        yield return new WaitUntil(() =>
        {
            return Vector2.Distance(positionBody.position, baseTrans.position) < stopDistance;
        });
        rotater.SetTarget(null);
        movingObject.SetMoveStatus(false);

        float tick = 0;
        Vector3 startPos = positionBody.localPosition;
        Quaternion startRotation = rotationBody.localRotation;

        rotationBody.localRotation = startRotation;
        while (tick < returnDuration)
        {
            tick += Time.deltaTime;
            positionBody.localPosition = Vector3.Lerp(startPos, basePos, tick / returnDuration);
            rotationBody.localRotation = Quaternion.Slerp(startRotation, baseRotation, tick / returnDuration);
            yield return null;
        }

        _endAction?.Invoke();
    }

    public void ChangeState(FlyingSwordState _state)
    {
        if (delayCoroutine != null) StopCoroutine(delayCoroutine);

        animations[(int)currentState].Stop();
        currentState = _state;
        animations[(int)currentState].Play();

        switch (_state)
        {
            case FlyingSwordState.Idle:
                break;
            case FlyingSwordState.FindTarget:
                break;
            case FlyingSwordState.Aim:
                StateProcess_Aim();
                break;
            case FlyingSwordState.Attack:
                StateProcess_Attack();
                break;
            case FlyingSwordState.Return:
                StateProcess_Return();
                break;
        }
        Debug.Log($"Change state: {_state}");
    }

    IEnumerator CR_Delay(float _duration, Action _endAction = null)
    {
        yield return new WaitForSeconds(_duration);
        _endAction?.Invoke();
    }
    #endregion
}
