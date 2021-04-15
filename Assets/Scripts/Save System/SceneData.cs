using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData : MonoBehaviour
{
    public int backDigged;
    public int frontDigged;

    public SceneData(Scenee scene){
        backDigged = scene.backDigged;
        frontDigged = scene.frontDigged;
    }
}
