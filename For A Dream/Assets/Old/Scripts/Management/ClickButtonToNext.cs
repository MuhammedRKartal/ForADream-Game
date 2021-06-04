using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonToNext : MonoBehaviour
{
    public string sname;
    public string musicName;
    public void nextScene(){
        FindObjectOfType<AudioManager>().Play(musicName);
        SceneManager.LoadScene(sceneName: sname);
    }
}
