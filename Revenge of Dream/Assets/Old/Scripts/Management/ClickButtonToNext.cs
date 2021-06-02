using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonToNext : MonoBehaviour
{
    public string sname;
    public void nextScene(){
        SceneManager.LoadScene(sceneName: sname);
    }
}
