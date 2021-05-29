using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public float moveSpeed = 5.4f;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent <Rigidbody2D> ();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            velX = Input.GetAxisRaw("Horizontal");
            velY = rigBody.velocity.y;
            rigBody.velocity = new Vector2 (velX * moveSpeed , velY);

            if(velX == 0f){
                animator.SetBool("isRunning", false);
            }
            else{
                animator.SetBool("isRunning", true);
            }

            Vector3 localScale = transform.localScale;
            if (velX > 0){
                facingRight = true;
            }
            else if (velX < 0){
                facingRight = false;
            }
            if (((facingRight)&&(localScale.x <0)) || ((!facingRight)&&(localScale.x >0))){
                localScale.x *= -1;
            }
            transform.localScale = localScale;
    }
}