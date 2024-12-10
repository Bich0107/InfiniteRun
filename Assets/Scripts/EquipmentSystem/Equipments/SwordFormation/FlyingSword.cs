using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    [SerializeField] RotateToTarget rotater;
    [SerializeField] MovingObject movingObject;
    [SerializeField] FlyingSwordState currentState;
    [SerializeField] AnimationController[] animations;
    [Space]
    [SerializeField] Transform body;
    [SerializeField] Transform target;
    [Header("Idle state settings")]
    [Header("Find target state settings")]
    [Header("Aim state settings")]
    [SerializeField] float aimRotateSpeed;
    [SerializeField] float aimDuration;
    [Header("Attack state settings")]
    [SerializeField] float attackSpeed;
    [SerializeField] float returnDelay;
    //[Header("Return state settings")]

    void Start()
    {
        ChangeState(FlyingSwordState.Idle);
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

    public void StateProcess_FindTarget()
    {
        if (target != null)
        {
            ChangeState(FlyingSwordState.Aim);
            return;
        }
    }

    public void StateProcess_Aim()
    {
        if (target == null)
        {
            ChangeState(FlyingSwordState.FindTarget);
            return;
        }

        rotater.SetRotateSpeed(aimRotateSpeed);
        rotater.SetTarget(target);

        StartCoroutine(CR_Delay(aimDuration, () => ChangeState(FlyingSwordState.Attack)));
    }

    public void StateProcess_Attack()
    {
        if (target == null)
        {
            ChangeState(FlyingSwordState.FindTarget);
            return;
        }

        rotater.SetTarget(null);
        movingObject.SetSpeed(attackSpeed);
        movingObject.SetDirection((target.position - body.position).normalized);
        movingObject.SetMoveStatus(true);

        StartCoroutine(CR_Delay(returnDelay, () => ChangeState(FlyingSwordState.Return)));
    }

    void ChangeState(FlyingSwordState _state)
    {
        animations[(int)currentState].Stop();
        currentState = _state;
        animations[(int)currentState].Play();

        switch (_state)
        {
            case FlyingSwordState.Idle:
                animations[(int)_state].Play();
                break;
            case FlyingSwordState.FindTarget:
                Debug.Log($"Change state: {_state}");
                break;
            case FlyingSwordState.Aim:
                Debug.Log($"Change state: {_state}");
                StateProcess_Aim();
                break;
            case FlyingSwordState.Attack:
                Debug.Log($"Change state: {_state}");
                StateProcess_Attack();
                break;
            case FlyingSwordState.Return:
                Debug.Log($"Change state: {_state}");
                break;
        }
    }

    IEnumerator CR_Delay(float _duration, Action _endAction = null)
    {
        yield return new WaitForSeconds(_duration);
        _endAction?.Invoke();
    }
}
