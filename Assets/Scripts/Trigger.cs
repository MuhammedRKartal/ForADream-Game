using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;


    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
                Debug.Log("hey");
                 SceneManager.LoadScene (sceneName:"Middle");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = true;
            Debug.Log("heeeeey");
        }

    }
    private void OnTriggerExit2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = false;
            Debug.Log("çıktım");     
        }

    }

}