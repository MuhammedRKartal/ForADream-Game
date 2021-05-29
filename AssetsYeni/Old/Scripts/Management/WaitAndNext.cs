using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndNext : MonoBehaviour
{
    public string sname;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScene(sname));
    }

    IEnumerator loadScene (string sname)
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName: sname);
    }
}
