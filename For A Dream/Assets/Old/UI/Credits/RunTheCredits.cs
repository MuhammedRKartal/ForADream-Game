using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunTheCredits : MonoBehaviour
{
    public GameObject texts;
    // Start is called before the first frame update
    void Awake()
    {
        texts.GetComponent<Animator>().SetBool("isDone", true);
        
    }
    void Update(){
        texts.GetComponent<Animator>().SetBool("isDone", false);
        if(texts.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            SceneManager.LoadScene(sceneName: "1EnterGame");
        }
    }
}
