using System.Collections;
using UnityEngine;

public class FlyingSwordCollideController : MonoBehaviour
{
    [SerializeField] FlyingSword flyingSword;
    [SerializeField] float returnDelay;
    bool isReturning;

    void OnTriggerEnter(Collider other)
    {
        if (flyingSword.CurrentState == FlyingSwordState.Attack)
        {
            Debug.Log($"{name} triggered!");
            Return();
        }
    }

    void Return()
    {
        if (isReturning) return;
        isReturning = true;
        StartCoroutine(CR_Return());
    }

    IEnumerator CR_Return()
    {
        yield return new WaitForSeconds(returnDelay);
        flyingSword.ChangeState(FlyingSwordState.Return);
        isReturning = false;
    }
}
