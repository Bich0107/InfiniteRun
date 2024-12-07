using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour, ITriggerByPlayer
{
    [SerializeField] ActivatableObject activateTarget;
    [SerializeField] float activeDelay = 0f;
    bool activated = false;
    WaitForSeconds activateWait;

    void Start()
    {
        activateWait = new WaitForSeconds(activeDelay);
    }

    public void PlayerTrigger()
    {
        if (activated) return;
        StartCoroutine(CR_Activate());
    }

    IEnumerator CR_Activate()
    {
        activated = true;
        yield return activateWait;
        activateTarget?.Activate();
        activated = false;
    }
}
