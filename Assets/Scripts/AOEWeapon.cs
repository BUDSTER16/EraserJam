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
    private float curseDmg;
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

        this.transform.localPosition = new Vector3(0, -0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
