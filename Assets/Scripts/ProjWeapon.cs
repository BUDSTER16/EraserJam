using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
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
    private GameObject enemy;
    private Vector3 target;

    private float fireTimer;
    private bool fired = false;
    public float speed;

    void Start()
    {
        player = this.gameObject.transform.parent.gameObject;
        damage *= player.GetComponent<PlayerWeapons>().dmgMultiplier;
        regen *= player.GetComponent<PlayerWeapons>().healMultiplier;
        curseDmg = player.GetComponent<PlayerWeapons>().curseDamage;
        FireRate *= player.GetComponent<PlayerWeapons>().atkDelay;
        //FireRate *= 10;
        fireTimer = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (fireTimer <= 0 && !fired)
        {
            Fire();
            fired = true;
        }else
        {
            fireTimer -= Time.deltaTime;
        }

        if (fired && enemy == null)
        {
            Destroy(gameObject);
        }
        else if (fired)
        {
            target = enemy.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (fired && enemy != null)
        {
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
    }

    void Fire()
    {
        Instantiate(this, player.transform);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int Target = Random.Range(0, enemies.Length);
        enemy = enemies[Target];
        if(enemy.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.SetParent(null, true);
    }

    public bool IsFired()
    {
        return fired;
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
                FireRate -= 0.1f;
                if (FireRate <1)
                {
                    FireRate = 1;
                }
                break;
            default:
                break;
        }
    }
}
