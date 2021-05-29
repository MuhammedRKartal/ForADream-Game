using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator animator;
    public GameObject button;

    public string sname;

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
                SceneManager.LoadScene(sceneName: sname);
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

}
