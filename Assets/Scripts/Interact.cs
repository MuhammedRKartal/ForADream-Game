using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
                Debug.Log("hey");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = true;
            Debug.Log("heeeeey");
        }
        else{
            isInRange = false;
        }

    }
}
