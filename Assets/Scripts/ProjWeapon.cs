using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjWeapon : MonoBehaviour
{
    public string weaponName;
    [Header("Stats")]
    public float damage;
    public float regen;
    public bool isCursed;
    private float curseDmg;
    public float FireRate;

    private GameObject player;

    void Start()
    {
        player = this.gameObject.transform.parent.gameObject;
        damage *= player.GetComponent<PlayerWeapons>().dmgMultiplier;
        regen *= player.GetComponent<PlayerWeapons>().healMultiplier;
        curseDmg = player.GetComponent<PlayerWeapons>().curseDamage;
        FireRate *= player.GetComponent<PlayerWeapons>().atkDelay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
