using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

    

    private void FixedUpdate()
    {
        //transform.localRotation = Quaternion.Euler((Vector3.forward + new Vector3(0, 0, transform.localRotation.z)) * turnSpeed *Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, turnSpeed) * Time.deltaTime);
    }

    public void Upgrade()
    {
        short stat = (short)Random.Range(0, 2);

        switch (stat)
        {
            case 0:
                damage += 0.5f;
                break;
            case 1:
                turnSpeed += 5;
                break;
            default:
                break;
        }
    }
}
