using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    string nameOfScene;
    public bool isFresh = false;
    public void Load(){
        if(isFresh){
            SceneManager.LoadScene(sceneName: "2MedicTent");
        }
        else{
            if(PlayerPrefs.HasKey("sceneSave") == true){
                nameOfScene = PlayerPrefs.GetString("sceneSave");
                SceneManager.LoadScene(sceneName: nameOfScene);
            }
            else{
                SceneManager.LoadScene(sceneName: "2MedicTent");
            }
        }
        
        
    }
}
