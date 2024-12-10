using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    [SerializeField] RotateToTarget rotater;
    [SerializeField] MovingObject movingObject;
    [SerializeField] FlyingSwordState currentState;

    [SerializeField] AnimationController[] animations;

    void Start()
    {

    }

    // void ChangeState(FlyingSwordState _state)
    // {
    //     animations[(int)currentState].Stop();
    // }
}
