using UnityEngine;

public abstract class ActivatableObject : MonoBehaviour
{
    protected bool activated = false;

    public abstract void Activate();
}