using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Digging : MonoBehaviour
{

public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator animator;
    public GameObject button;

    public GameObject kurek;
    public GameObject player;

    private float timer = 0;
    private float timerMax = 0;
    private bool waiting = false;

    public int counter = 0;
    public GameObject moloz;
    public GameObject[] molozArray;
    public GameObject llider;

    private bool act = false;


    void Start()
    {
        animator = button.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
            }
        }
        if(waiting == true){
            if(!Waited(4.8f)){
                player.GetComponent<PlayerMovement>().enabled = false;
                return;
            }
            else{
                player.GetComponent<PlayerMovement>().enabled = true;
                timer = 0;
                player.GetComponent<Animator>().SetBool("isDigging", false);
                kurek.SetActive(false);
                waiting = false;
                counter++;
            }    
        }
        else{
            if(act == false){
                if(counter == 1){
                molozArray[0].SetActive(true);
                Destroy(moloz);
                }
                else if(counter == 2){
                    molozArray[1].SetActive(true);
                    Destroy(molozArray[0]);
                    player.GetComponent<Scenee>().backDigged = 1;
                }
                else if(counter == 3){
                    molozArray[2].SetActive(true);
                    llider.SetActive(false);
                    Destroy(molozArray[1]);
                    
                    
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = true;
            animator.SetBool("isInRange", true);
            Debug.Log("heeeeey");
        }
    }

    private void OnTriggerExit2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = false;
            animator.SetBool("isInRange", false);
            Debug.Log("çıktım");     
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
        Debug.Log("hey");
        player.GetComponent<Animator>().SetBool("isDigging", true);
        
        kurek.SetActive(true);
        waiting = true;   
    }  
}
