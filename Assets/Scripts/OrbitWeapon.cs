using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitWeapon : MonoBehaviour
{
    public string weaponName;
    [Header("Stats")]
    public float damage;
    public float regen;
    public bool isCursed;
    private float curseDmg;
    public float turnSpeed;

    private GameObject player;

    void Start()
    {
        player = this.gameObject.transform.parent.gameObject;
        damage *= player.GetComponent<PlayerWeapons>().dmgMultiplier;
        regen *= player.GetComponent<PlayerWeapons>().healMultiplier;
        curseDmg = player.GetComponent<PlayerWeapons>().curseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //transform.localRotation = Quaternion.Euler((Vector3.forward + new Vector3(0, 0, transform.localRotation.z)) * turnSpeed *Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, turnSpeed) * Time.deltaTime);
    }
}
