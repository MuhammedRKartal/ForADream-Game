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

    PlayerMovement move;
    public GameObject player;

    private float timer = 0;
    private float timerMax = 0;


    void Start()
    {
        animator = button.GetComponent<Animator>();
        move = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move.counter==3){
            animator.SetBool("isInRange",false);
            if(!Waited(0.7f)) return;
            button.SetActive(false);
        }
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
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
}
