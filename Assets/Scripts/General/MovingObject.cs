using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 direction;
    [SerializeField] float baseSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            rb.velocity = direction * currentSpeed;
        }
    }

    public void SetSpeed(float _value) => currentSpeed = _value;
    public void SetDirection(Vector2 _direction) => direction = _direction;
    public void SetMoveStatus(bool _status) => isMoving = _status;
    public void Reset() => currentSpeed = baseSpeed;
}
