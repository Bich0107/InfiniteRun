using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHolder : MonoBehaviour
{
    [SerializeField] Equipment currentEquipment;

    public void UseEquipment()
    {
        currentEquipment?.Use();
    }
}
