using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] bool followX = true;
    [SerializeField] bool followY = false;
    [SerializeField] bool isFollowing;
    Vector3 newPos = new Vector3();

    void Start()
    {
        offset = transform.position - target.position;
        newPos = target.position + offset;
    }

    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (!isFollowing) return;

        if (followX) newPos.x = (target.position + offset).x;
        if (followY) newPos.y = (target.position + offset).y;

        newPos.z = (target.position + offset).z;
        transform.position = newPos;
    }

    public void SetFollowStatus(bool _status) => isFollowing = _status;
}
