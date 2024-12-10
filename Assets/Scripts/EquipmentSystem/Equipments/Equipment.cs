using System.Collections;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    [Header("General settings")]
    [SerializeField] protected float useCD;
    [SerializeField] protected bool usable = true;
    protected WaitForSeconds cdWait;

    void Start()
    {
        cdWait = new WaitForSeconds(useCD);
    }

    public abstract void Use();
    protected virtual IEnumerator CR_RefreshCD()
    {
        usable = false;
        yield return cdWait;
        usable = true;
    }
}
