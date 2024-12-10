using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;
    [SerializeField] float baseSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] bool isMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            rb.velocity = direction * currentSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void SetSpeed(float _value) => currentSpeed = _value;
    public void SetDirection(Vector2 _direction) => direction = _direction;
    public void SetMoveStatus(bool _status) => isMoving = _status;
    public void Reset() => currentSpeed = baseSpeed;
}
