using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float gravityScale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
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
