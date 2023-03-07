using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;
    private SpriteRenderer spriteRenderer;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 20f;
    [SerializeField]private float jumpForce = 14f;
    private bool isJumping = false;
    private int jumpNbr = 0;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) 
        {
            if ((animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle") || animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Running")) && jumpNbr == 0 && !isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSoundEffect.Play();
                jumpNbr += 1;
                isJumping = true;
            }
            else if((animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Jumping") || animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Falling")) && jumpNbr == 1 && isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSoundEffect.Play();
                jumpNbr += 1;
            }
        }
        else if ((animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle") || (animation.GetCurrentAnimatorStateInfo(0).IsName("Player_Running"))) && jumpNbr >= 1 && isJumping)
        {
            jumpNbr = 0;
            isJumping = false;
        }

        animationUpdate();
    }

    private void animationUpdate()
    {
        if (dirX > 0f)
        {
            animation.SetBool("running", true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            animation.SetBool("running", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animation.SetBool("running", false);
        }

        animation.SetFloat("jumping", rb.velocity.y);
    }
}
