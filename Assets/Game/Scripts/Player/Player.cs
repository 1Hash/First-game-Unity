using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float velocidadeMovimento;

    public SpriteRenderer spriteRenderer;
    public float forceJump;

    private bool onGround;
    private bool jumping;
    public Transform detectionGround;
    public float detectionRadius;
    public LayerMask layerGround;

    void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        float horizontalMobile = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocidade = this.rigidbody2d.velocity;

        if (horizontalMobile != 0)
        {
            velocidade.x = horizontalMobile * this.velocidadeMovimento;
            this.rigidbody2d.velocity = velocidade;
        } else
        {
            velocidade.x = horizontal * this.velocidadeMovimento;
            this.rigidbody2d.velocity = velocidade;
        }

        if (velocidade.x > 0)
        {
            this.spriteRenderer.flipX = false;
        }
        else if (velocidade.x < 0)
        {
            this.spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        Collider2D collider = Physics2D.OverlapCircle(this.detectionGround.position, this.detectionRadius, this.layerGround);
        if (collider != null)
        {
            this.onGround = true;
            this.jumping = false;
        } else
        {
            this.onGround = false;
        }

        if(this.onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                if (!this.jumping)
                {
                    Vector2 force = new Vector2(0, this.forceJump);
                    this.rigidbody2d.AddForce(force, ForceMode2D.Impulse);
                }
            }
        }
    }

    public bool OnGround
    {
        get
        {
            return this.onGround;
        }
    }
}
