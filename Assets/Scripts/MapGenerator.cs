using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject mapPartPrefab;
    [SerializeField] int amount;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 currentSpawnPos;
    [SerializeField] Transform mapParent;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(mapPartPrefab, currentSpawnPos, Quaternion.identity, mapParent);
            currentSpawnPos += offset;
        }
    }
}
