using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomAnimation : MonoBehaviour
{
    [Header("General settings")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float duration;
    protected float tick;

    public abstract IEnumerator Play();
}
