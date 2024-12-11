using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingAxis
{
    Up, Right, Forward
}

public class SingleAxisMovingObject : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform trans;
    [SerializeField] MovingAxis axis;
    [SerializeField] float baseSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] bool isMoving;

    void Awake()
    {
        currentSpeed = baseSpeed;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            switch (axis)
            {
                case MovingAxis.Up:
                    rb.velocity = trans.up * currentSpeed;
                    break;
                case MovingAxis.Right:
                    rb.velocity = trans.right * currentSpeed;
                    break;
                case MovingAxis.Forward:
                    rb.velocity = trans.forward * currentSpeed;
                    break;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void SetSpeed(float _value) => currentSpeed = _value;
    public void SetMoveStatus(bool _status) => isMoving = _status;
    public void Reset() => currentSpeed = baseSpeed;
}
