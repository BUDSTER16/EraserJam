using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Stats")]
    public float atkDelay = 1.0f;
    public float dmgMultiplier = 1.0f;
    public float curseDamage = 0.2f;
    public float healMultiplier = 1.0f;

    private Weapon circle = new Weapon("Circle", 5f, 0, 0, false);

    private Weapon[] equipped = new Weapon[6];

    void Start()
    {
        Equip(circle);
    }


    void Update()
    {
        
    }

    void Equip(Weapon equWeapon)
    {
        bool complete = false;
        for (int i = 0; i < equipped.Length; i++)
        {
            if (equipped[i].name != "def" && !complete)
            {
                equipped[i] = equWeapon;
                complete = true;
            }
        }
        if (!complete) 
        {
            throw (new Exception("Tried to equip but no open slots"));
        }
    }

    void CreateEffect(Weapon equWeapon)
    {

    }
}


[System.Serializable]
public class Weapon
{
    public string name;
    public float damage;
    public Boolean isCursed;
    public float heal;
    enum WeaponType {AOE, Proj, Orbit};
    public short type;

    public Weapon()
    {
        name = "def";
        damage = 0.0f;
        isCursed = false;
        heal = 0.0f;
        type = 0;
    }
    public Weapon(string weapName, float dmg, short useage, float regen, bool curse)
    {
        name = weapName;
        damage = dmg;
        type = useage;
        heal = regen;
        isCursed = curse;
    }
}