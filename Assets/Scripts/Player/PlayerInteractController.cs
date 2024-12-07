using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour, ITrapTrigger, ICollideWithEnemy, IPropelerTrigger
{
    [SerializeField] PlayerMovement movement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ITriggerByPlayer target = other.GetComponent<ITriggerByPlayer>();
        if (target != null)
        {
            target.PlayerTrigger();
        }
    }

    public void PropelerTrigger(Vector2 _force)
    {
        movement.Propel(_force);
    }

    public void Collide(object _obj)
    {
        Debug.Log("Get damage: " + (float)_obj);
    }
}
