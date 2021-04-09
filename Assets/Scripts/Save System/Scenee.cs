using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenee : MonoBehaviour
{

    public int backDigged;
    public int frontDigged;

    public void SaveScene(){
        SaveSystem.SaveScene(this);
    }

    public void LoadScene(){
        SceneData data = SaveSystem.LoadScene();

        backDigged = data.backDigged;
        frontDigged = data.frontDigged;
    }
}
