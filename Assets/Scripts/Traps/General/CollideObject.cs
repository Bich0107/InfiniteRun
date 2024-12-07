using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollideObject : MonoBehaviour
{
    [SerializeField] protected float collideCD;
    protected bool isInCD = false;
}
