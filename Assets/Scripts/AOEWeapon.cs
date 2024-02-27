using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEWeapon : MonoBehaviour
{
    public string weaponName;
    [Header("Stats")]
    public float damage;
    public float regen;
    public bool isCursed;
    private Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        size = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
