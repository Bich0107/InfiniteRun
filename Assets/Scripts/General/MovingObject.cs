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
    Vector2 velocity = new Vector2();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            velocity.x = (direction * currentSpeed).x;
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        }
    }

    public void SetSpeed(float _value) => currentSpeed = _value;
    public void SetMoveStatus(bool _status) => isMoving = _status;
    public void Reset() => currentSpeed = baseSpeed;
}
