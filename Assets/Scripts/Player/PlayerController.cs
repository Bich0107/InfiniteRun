using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    Touch touch;
    Vector2 touchPos;
    Vector2 releasedPos;

    void Update()
    {
        GetTouchInfo();
    }

    void GetTouchInfo()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    releasedPos = touch.position;
                    CheckPlayerAction();
                    break;
            }
        }
    }

    void CheckPlayerAction()
    {
        float xDistance = Mathf.Abs(releasedPos.x - touchPos.x);
        float yDistance = Mathf.Abs(releasedPos.y - touchPos.y);

        if (xDistance > yDistance)
        {
            Debug.Log("x direction action");
        }
        else
        {
            movement.ChangeGravity(releasedPos.y - touchPos.y);
        }
    }
}
