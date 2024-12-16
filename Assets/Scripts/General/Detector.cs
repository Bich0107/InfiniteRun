using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] List<GameObject> detectedTargets;
    [SerializeField] float range;
    [SerializeField] bool isActive;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (!HaveTarget(other.gameObject)) detectedTargets.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (HaveTarget(other.gameObject)) detectedTargets.Remove(other.gameObject);
    }

    bool HaveTarget(GameObject _go)
    {
        foreach (GameObject go in detectedTargets)
        {
            if (go.Equals(_go)) return true;
        }
        return false;
    }

    public void SetActiveStatus(bool _value) => isActive = _value;

    public GameObject GetRandomTarget()
    {
        int index = Random.Range(0, detectedTargets.Count);
        return detectedTargets[index];
    }

    public GameObject GetTarget(int _index = 0) => detectedTargets[_index];

    public List<GameObject> GetDetectedTargets()
    {
        return detectedTargets;
    }
}
