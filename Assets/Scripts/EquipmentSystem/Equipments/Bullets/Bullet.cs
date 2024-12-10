using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("General settings")]
    [SerializeField] protected float speed;
    [SerializeField] protected MovingObject movingObject;

    public virtual void Fire(Vector2 _direction)
    {
        movingObject.SetDirection(_direction);
        movingObject.SetSpeed(speed);
        movingObject.SetMoveStatus(true);
    }
}
