using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 2.0f;

    private float vertical, horizontal;

    private bool allowedToMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (allowedToMove) {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        } 
    }

    public void DisableMovement()
    {
        allowedToMove= false;
    }
}
