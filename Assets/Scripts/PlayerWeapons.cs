using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Stats")]
    public float maxHP = 30f;
    public float atkDelay = 1.0f;
    public float dmgMultiplier = 1.0f;
    public float curseDamage = 0.2f;
    public float healMultiplier = 1.0f;
    private int totalXP = 0;

    [Header("Weapons")]
    public GameObject eraseCircle;
    public GameObject bow;
    public GameObject whiteout;
    public GameObject pencilStar;
    public GameObject chain;
    public GameObject healAura;
    public GameObject Orberaser;

    [Header("UI Utilities")]
    private GameObject deathScreen;

    private int experience;
    private float HP;

    private string[] equipped = { "def", "def", "def", "def" };
    private int[] eqIDs = new int[4];
    private short numWeapons = 0;

    void Start()
    {
        HP = maxHP;
        deathScreen = GameObject.Find("GameOverScreen");
        deathScreen.SetActive(false);
    }

    void Update()
    {

    }

    void Equip(GameObject equWeapon, int id)
    {
        bool complete = false;
        bool alreadyOwned = false;
        // AOE = 0, Orbit = 1, Proj = 2
        short weapType = equWeapon.GetComponent<WeaponCheck>().getType();
        string wname = "";
        switch (weapType)
        {
            case 0:
                wname = equWeapon.GetComponent<AOEWeapon>().weaponName;
                break;
            case 1:
                wname = equWeapon.GetComponent<OrbitWeapon>().weaponName;
                break;
            case 2:
                wname = equWeapon.GetComponent<ProjWeapon>().weaponName;
                break;
            default:
                break;
        }

        for (int i = 0; i < equipped.Length; i++)
        {
            if (equipped[i] == wname)
            {
                alreadyOwned = true;
                complete = true;
            }

            if (equipped[i] == "def" && !complete)
            {
                equipped[i] = wname;
                eqIDs[i] = id;
                complete = true;
            }
        }


        if (numWeapons < 4 && !alreadyOwned)
        {
            AttachWeapon(equWeapon);
            numWeapons += 1;
        }
        else if (alreadyOwned)
        {
            switch (weapType)
            {
                case 0:
                    equWeapon.GetComponent<AOEWeapon>().Upgrade();
                    break;
                case 1:
                    equWeapon.GetComponent<OrbitWeapon>().Upgrade();
                    break;
                case 2:
                    equWeapon.GetComponent<ProjWeapon>().Upgrade();
                    break;
                default:
                    break;
            }
        }

       
        if (!complete) 
        {
            throw new Exception("Tried to equip but no open slots");
        }
    }

    void AttachWeapon(GameObject equWeapon)
    {
        GameObject newWeapon = Instantiate(equWeapon, transform);
    }

    public void RecieveSelection(short selected)
    {
        // Weapon List:
        // 0: Circle, 1: Bow, 2: Whiteout, 3: Pencils, 4: Chain, 5: Heal Aura, 6:Orberaser

        switch (selected)
        {
            case 0:
                Equip(eraseCircle, selected);
                break;
            case 1:
                Equip(bow, selected);
                break;
            case 2:
                Equip(whiteout, selected);
                break;
            case 3:
                Equip(pencilStar, selected);
                break;
            case 4:
                Equip(chain, selected);
                break;
            case 5:
                Equip(healAura, selected);
                break;
            case 6:
                Equip(Orberaser, selected);
                break;
            default:
                break;
        }
    }

    public void GainXP(int xp)
    {
        experience += xp;
        totalXP += xp;
    }

    public int GetXP()
    {
        return experience;
    }

    public void LevelUp()
    {
        experience -= 20;
    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("YOU DIED");
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pit")
        {
            Die();
        }
    }

    public int GetWeaponCount()
    {
        return numWeapons;
    }

    public int[] GetEquippedIDs()
    {
        return eqIDs;
    }
}