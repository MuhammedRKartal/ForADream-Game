using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TakeSomethingAndNext : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator animator;
    public GameObject button;

    public string sname;

    public GameObject player;
    private float timer = 0;
    private float timerMax = 0;
    private bool waiting = false;

    private bool act = false;
    public int counter = 0;
    public GameObject[] openDoor;
    public GameObject[] collTrigger;
    

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
            if(!Waited(0.75f)){
                player.GetComponent<PlayerMovement>().enabled = false;
                return;
            }
            else{
                player.GetComponent<PlayerMovement>().enabled = true;
                timer = 0;
                player.GetComponent<Animator>().SetBool("isTaking", false);
                player.GetComponent<Animator>().SetBool("isPutting", false);
                waiting = false;
                counter++;
            }    
        }
        else{
            if(act == false){
                if(counter == 1){
                    foreach (GameObject x in collTrigger){
                        x.SetActive(false);
                    }
                    foreach (GameObject x in openDoor){
                        x.SetActive(true);
                    }
                }
                
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

    public void take(){
        player.GetComponent<Animator>().SetBool("isTaking", true);
        waiting = true;    
    }

    public void put(){
        player.GetComponent<Animator>().SetBool("isPutting", true);
        waiting = true;    
    }

}
