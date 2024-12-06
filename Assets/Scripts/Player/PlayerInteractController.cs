using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour, ITrapTrigger, ICollideWithEnemy, IPropelerTrigger
{
    [SerializeField] PlayerMovement movement;

    public void PropelerTrigger(Vector2 _force)
    {
        movement.Propel(_force);
    }
}
