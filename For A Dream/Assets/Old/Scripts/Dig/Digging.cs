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

    private bool canRun = false;


    void Start()
    {
        animator = button.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting == true){
            if(!Waited(4.8f)){
                Debug.Log(canRun);
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
            if(isInRange){
                if(Input.GetKeyDown(interactKey)){
                    interactAction.Invoke();
                }
            }
            Debug.Log(canRun);
            if(counter == 0 && canRun){
                FindObjectOfType<AudioManager>().Play("Digging");
            }
            else if(counter == 1){
                FindObjectOfType<AudioManager>().Play("Digging");
                molozArray[0].SetActive(true);
                Destroy(moloz);
            }
            else if(counter == 2){
                FindObjectOfType<AudioManager>().Play("Digging");
                molozArray[1].SetActive(true);
                Destroy(molozArray[0]);
            }
            else if(counter == 3){
                molozArray[2].SetActive(true);
                llider.SetActive(false);
                Destroy(molozArray[1]);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = true;
            animator.SetBool("isInRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = false;
            animator.SetBool("isInRange", false); 
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
        canRun = true;
        Debug.Log("hey");
        player.GetComponent<Animator>().SetBool("isDigging", true);
        kurek.SetActive(true);
        //FindObjectOfType<AudioManager>().Play("Digging");
        waiting = true;   
    }  
}
