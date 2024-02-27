using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AOEWeapon : MonoBehaviour
{
    public string weaponName;
    [Header("Stats")]
    public float damage;
    public float regen;
    public bool isCursed;
    public float curseDmg;
    private Vector3 size;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        size = this.transform.localScale;
        player = this.gameObject.transform.parent.gameObject;
        damage *= player.GetComponent<PlayerWeapons>().dmgMultiplier;
        regen *= player.GetComponent<PlayerWeapons>().healMultiplier;
        curseDmg = player.GetComponent<PlayerWeapons>().curseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
