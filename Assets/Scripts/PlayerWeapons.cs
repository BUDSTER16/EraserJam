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
    public int xpToLevel = 50;

    [Header("Weapons")]
    public GameObject eraseCircle;
    public GameObject bow;
    public GameObject whiteout;
    public GameObject pencilStar;

    [Header("UI Utilities")]
    private GameObject deathScreen;

    private int experience;
    private float HP;

    private string[] equipped = { "def", "def", "def", "def", "def", "def" };

    void Start()
    {
        Equip(eraseCircle);
        HP = maxHP;
        deathScreen = GameObject.Find("GameOverScreen");
        deathScreen.SetActive(false);
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pit")
        {
            Die();
        }
    }
}