using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 direction;

    void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        direction = (target.position - transform.position).normalized;

        // this is the angle vector direction with vector right (0, 1)
        // - 90 because the base angle of the sprite is 90
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime);
    }
}
