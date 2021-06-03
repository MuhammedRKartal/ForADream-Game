using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public string snameLast;
    public string sname;
    public void skipToEnd(){
        PlayerPrefs.SetInt("isDefensive", 1);
        PlayerPrefs.SetInt("isOffensive", 0);
        PlayerPrefs.SetInt("isSimple", 0);
        SceneManager.LoadScene(sceneName: snameLast);
    }
    public void skipToEnd2(){
        PlayerPrefs.SetInt("isDefensive", 0);
        PlayerPrefs.SetInt("isOffensive", 1);
        PlayerPrefs.SetInt("isSimple", 0);
        SceneManager.LoadScene(sceneName: snameLast);
    }
    public void skipNext(){
        PlayerPrefs.SetInt("isDefensive", 0);
        PlayerPrefs.SetInt("isOffensive", 1);
        PlayerPrefs.SetInt("isSimple", 0);
        SceneManager.LoadScene(sceneName: sname);
    }
    public void skipNext2(){
        PlayerPrefs.SetInt("isDefensive", 0);
        PlayerPrefs.SetInt("isOffensive", 0);
        PlayerPrefs.SetInt("isSimple", 1);
        SceneManager.LoadScene(sceneName: sname);
    }
}
