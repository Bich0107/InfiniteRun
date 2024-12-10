using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float baseMass;
    [SerializeField] float changeDirectionMass;
    [SerializeField] float changeMassDelay;
    WaitForSeconds changeGravityWait;
    bool isBusy;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = baseMass;
        changeGravityWait = new WaitForSeconds(changeMassDelay);
    }

    public void Propel(Vector3 _force)
    {
        rb.AddForce(_force, ForceMode.Impulse);
    }

    public void ChangeGravity(float _direction)
    {
        if (isBusy) return;
        StartCoroutine(CR_ChangeGravity(_direction));
    }

    IEnumerator CR_ChangeGravity(float _direction)
    {
        isBusy = true;

        if (_direction > Mathf.Epsilon)
        {
            rb.mass = -changeDirectionMass;
            yield return changeGravityWait;
            rb.mass = -baseMass;
        }
        else
        {
            rb.mass = changeDirectionMass;
            yield return changeGravityWait;
            rb.mass = baseMass;
        }
        isBusy = false;
    }
}
