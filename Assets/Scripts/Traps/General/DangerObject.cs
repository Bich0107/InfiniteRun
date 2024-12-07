using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObject : CollideObject
{
    [SerializeField] float damage;
    bool isActive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isInCD || !isActive) return;
        ICollideWithEnemy target = other.GetComponentInParent<ICollideWithEnemy>();
        if (target != null)
        {
            target.Collide(damage);
            StartCoroutine(CR_Cooldown());
        }
    }

    IEnumerator CR_Cooldown()
    {
        isInCD = true;
        yield return new WaitForSeconds(collideCD);
        isInCD = false;
    }

    public void SetHurtStatus(bool _isActive) => isActive = _isActive;
}
