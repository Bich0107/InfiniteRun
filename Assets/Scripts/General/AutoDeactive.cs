using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactive : MonoBehaviour
{
    [SerializeField] float delay;
    WaitForSeconds delayWait;

    void Awake()
    {
        delayWait = new WaitForSeconds(delay);
    }

    void OnEnable()
    {
        StartCoroutine(CR_Countdown());
    }

    IEnumerator CR_Countdown()
    {
        yield return delayWait;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
