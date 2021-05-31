using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWithOutButton : MonoBehaviour
{
    public bool isInRange;
    public string sname;
    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            SceneManager.LoadScene(sceneName: sname);
        }
    }

    private void OnTriggerEnter2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collusion){
        if(collusion.gameObject.CompareTag("Player")){
            isInRange = false;
        }
    }
}
