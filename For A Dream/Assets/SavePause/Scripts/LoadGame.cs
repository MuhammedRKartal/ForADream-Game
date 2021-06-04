using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    string nameOfScene;
    public bool isFresh = false;
    private string oldMusicName, musicName;

    public void Load(){
        if(isFresh){
            FindObjectOfType<AudioManager>().Stop();
            FindObjectOfType<AudioManager>().Play("DrunkenSailor");
            SceneManager.LoadScene(sceneName: "2MedicTent");
        }
        else{
            if(PlayerPrefs.HasKey("sceneSave") == true){
                FindObjectOfType<AudioManager>().Stop();
                Debug.Log(PlayerPrefs.GetString("lastMusic"));
                nameOfScene = PlayerPrefs.GetString("sceneSave");
                musicName = PlayerPrefs.GetString("lastMusic");
                FindObjectOfType<AudioManager>().Play(musicName);
                SceneManager.LoadScene(sceneName: nameOfScene); 
            }
            else{
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("DrunkenSailor");
                SceneManager.LoadScene(sceneName: "2MedicTent");
            }
        }
        
        
    }
}
