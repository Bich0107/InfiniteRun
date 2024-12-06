using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float gravityScale;
    public float GravityScale
    {
        get { return gravityScale; }
        set { gravityScale = value; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    public void Propel(Vector2 _force)
    {
        rb.AddForce(_force, ForceMode2D.Impulse);
    }

    IEnumerator CR_DisableGravity(float _duration)
    {
        float oldGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(_duration);
        rb.gravityScale = oldGravity;
    }

    public void ChangeGravity(float _direction)
    {
        if (_direction > Mathf.Epsilon)
        {
            rb.gravityScale = -gravityScale;
        }
        else rb.gravityScale = gravityScale;
    }
}
