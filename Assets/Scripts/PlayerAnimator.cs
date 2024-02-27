using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    bool falling = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }

    private void Update()
    {
        if(falling)
        {
            animator.SetTrigger("Falling");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().flipX= false;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Walking");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Walking");
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Walking");
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            animator.ResetTrigger("Walking");
            animator.SetTrigger("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pit")
        {
            falling = true;
        }
    }


}
