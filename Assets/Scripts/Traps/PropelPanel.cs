using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelPanel : ActivatableObject
{
    [SerializeField] Animator animator;
    [SerializeField] Vector2 propelDirection;
    [SerializeField] float propelForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        IPropelerTrigger target = other.GetComponentInParent<IPropelerTrigger>();
        if (target != null)
        {
            target.PropelerTrigger(propelDirection * propelForce);
            Activate();
        }
    }

    public override void Activate()
    {
        animator.SetTrigger("trigger");
    }
}
