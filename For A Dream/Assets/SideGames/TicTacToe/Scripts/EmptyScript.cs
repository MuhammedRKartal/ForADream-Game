using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyScript : MonoBehaviour
{   
    
    public int id;
    public GameObject cameraM;

    private void OnMouseDown()
    {
        cameraM.GetComponent<GameScript>().Spawn(this.gameObject, id);
    }
    
}
