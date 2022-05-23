using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private Rigidbody2D rb;
    private Animator anim;
    public bool onGround;
    public bool doubleJumpReady;
    public Collider2D levelCollider;
    private void Start()
    {
        doubleJumpReady = true;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        onGround = false;
        if (GetComponent<BoxCollider2D>().IsTouching(levelCollider))
        {
            doubleJumpReady = true;
            onGround = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (onGround||doubleJumpReady))
        {
            if(doubleJumpReady&&!onGround){
                doubleJumpReady = false;
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
