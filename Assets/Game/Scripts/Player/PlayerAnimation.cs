using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private Player player;

    void Update()
    {
        if(this.player.OnGround)
        {
            float speedX = Mathf.Abs(this.rigidbody.velocity.x);
            if (speedX > 0)
            {
                this.animator.SetBool("run", true);
            }
            else
            {
                this.animator.SetBool("run", false);
            }
            this.animator.SetBool("jump", false);
            this.animator.SetBool("fall", false);
        } else
        {
            float speedY = this.rigidbody.velocity.y;
            if(speedY > 0)
            {
                this.animator.SetBool("jump", true);
                this.animator.SetBool("fall", false);
            } else if(speedY < 0)
            {
                this.animator.SetBool("jump", false);
                this.animator.SetBool("fall", true);
            }
        }
        
    }
}
