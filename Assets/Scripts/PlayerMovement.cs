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

    public GameObject kurek;

    private float timer = 0;
    private float timerMax = 0;
    private bool waiting = false;

    public int counter = 0;
    public GameObject moloz;
    public GameObject[] molozArray;
    public GameObject llider;


    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent <Rigidbody2D> ();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting == true){
            if(!Waited(4.8f)){
                return;
            }
            else{
                timer = 0;
                animator.SetBool("isDigging", false);
                kurek.SetActive(false);
                waiting = false;
                counter++;
            }    
        }
        else{
            if(counter == 1){
                moloz.SetActive(false);
                molozArray[0].transform.position = moloz.transform.position;
                molozArray[0].transform.rotation = moloz.transform.rotation;
                molozArray[0].transform.localScale = moloz.transform.localScale;
                molozArray[0].SetActive(true);
            }
            else if(counter == 2){
                molozArray[0].SetActive(false);
                molozArray[1].transform.position = moloz.transform.position;
                molozArray[1].transform.rotation = moloz.transform.rotation;
                molozArray[1].transform.localScale = moloz.transform.localScale;
                molozArray[1].SetActive(true);
            }
            else if(counter == 3){
                molozArray[1].SetActive(false);
                molozArray[2].transform.position = moloz.transform.position;
                molozArray[2].transform.rotation = moloz.transform.rotation;
                molozArray[2].transform.localScale = moloz.transform.localScale;
                molozArray[2].SetActive(true);
                llider.SetActive(false);

            }
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

    private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax) {return true;}
        return false;
    }

    public void dig(){
        animator.SetBool("isDigging", true);
        kurek.SetActive(true);
        waiting = true;   
    }  
}
