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

    private GameObject player;
    private GameObject gameManager;
    Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        goal = player.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, goal, speed*Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        short weapType = collision.GetComponent<WeaponCheck>().getType();
        GameObject weapon;
        weapon = collision.gameObject;
        switch (weapType)
        {
            case 0:
                health -= weapon.GetComponent<AOEWeapon>().damage * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
