using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Stats")]
    public float maxHP = 30f;
    public float atkDelay = 1.0f;
    public float dmgMultiplier = 1.0f;
    public float curseDamage = 0.2f;
    public float healMultiplier = 1.0f;
    public int xpToLevel = 50;

    [Header("Weapons")]
    public GameObject eraseCircle;

    private int experience;
    private float HP;

    private string[] equipped = { "def", "def", "def", "def", "def", "def" };

    void Start()
    {
        Equip(eraseCircle);
        HP = maxHP;
    }


    void Update()
    {
        
    }

    void Equip(GameObject equWeapon)
    {
        bool complete = false;
        for (int i = 0; i < equipped.Length; i++)
        {
            if (equipped[i] == "def" && !complete)
            {
                equipped[i] = equWeapon.GetComponent<AOEWeapon>().weaponName;
                complete = true;
                AttachWeapon(equWeapon);
            }
        }
        if (!complete) 
        {
            throw (new Exception("Tried to equip but no open slots"));
        }
    }

    void AttachWeapon(GameObject equWeapon)
    {
        GameObject newWeapon = Instantiate(equWeapon, this.transform);
        newWeapon.transform.transform.localPosition = new Vector3(0, -0.6f, 0);
    }

    public void GainXP(int xp)
    {
        experience += xp;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject attacker = collision.gameObject;
            HP -= attacker.GetComponent<Enemy>().damage;
        }
    }
}