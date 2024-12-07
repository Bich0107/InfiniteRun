using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float baseGravityScale;
    [SerializeField] float changeDirectionGravityScale;
    [SerializeField] float changeGravityDelay;
    WaitForSeconds changeGravityWait;
    bool isBusy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = baseGravityScale;
        changeGravityWait = new WaitForSeconds(changeGravityDelay);
    }

    public void Propel(Vector2 _force)
    {
        rb.AddForce(_force, ForceMode2D.Impulse);
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
            rb.gravityScale = -changeDirectionGravityScale;
            yield return changeGravityWait;
            rb.gravityScale = -baseGravityScale;
        }
        else
        {
            rb.gravityScale = changeDirectionGravityScale;
            yield return changeGravityWait;
            rb.gravityScale = baseGravityScale;
        }
        isBusy = false;
    }
}
