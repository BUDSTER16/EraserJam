using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Stats")]
    public float health;
    public float damage;
    public bool isRanged;
    public float speed;
    public short IDNum;

    private GameObject player;
    private GameObject gameManager;
    private Animator animator;
    Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        goal = player.transform.position;

        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, goal, speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Weapon" && collision.GetComponent<WeaponCheck>().getType() == 0)
        {
            GameObject weapon;
            weapon = collision.gameObject;

                    health -= (weapon.GetComponent<AOEWeapon>().damage) * Time.deltaTime;
        }
        if(collision.tag == "Player")
        {
            animator.ResetTrigger("Walk");
            animator.SetTrigger("Bite");
            player.GetComponent<PlayerWeapons>().TakeDamage(damage*Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && collision.GetComponent<WeaponCheck>().getType() == 1)
        {
            GameObject weapon;
            weapon = collision.gameObject;

            health -= (weapon.GetComponent<OrbitWeapon>().damage) * Time.deltaTime;
        }

        if (collision.tag == "Weapon" && collision.GetComponent<WeaponCheck>().getType() == 2)
        {
            GameObject weapon;
            weapon = collision.gameObject;
            if (!weapon.GetComponent<ProjWeapon>().IsFired())
            {
                health -= (weapon.GetComponent<ProjWeapon>().damage / 5) * Time.deltaTime;
                Destroy(weapon);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.ResetTrigger("Bite");
            animator.SetTrigger("Walk");
        }
    }

    private void Die()
    {
        gameManager.GetComponent<GameManager>().EnemyKilled(IDNum);
        Destroy(this.gameObject);
    }
}
