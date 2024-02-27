using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCheck : MonoBehaviour
{
    [SerializeField]
    // AOE = 0, Orbit = 1
    private short weaponType;

    public short getType()
    {
        return weaponType;
    }

}
