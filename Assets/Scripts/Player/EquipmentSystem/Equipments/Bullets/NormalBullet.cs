using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    public override void Fire(Vector2 _direction)
    {
        base.Fire(_direction);
        Debug.Log($"speed: {speed}");
    }
}
