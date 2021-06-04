using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start1 : MonoBehaviour
{
    public string sname;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(sceneName: sname);
    }


}