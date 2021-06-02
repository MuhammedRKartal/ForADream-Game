using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;
    int numberOfBoxes = 5;
    public GameplayController control;
    
    public void SpawnBox()
    {
        if(control.moveCount != 5){
            GameObject box_Obj = Instantiate(box_Prefab);
            Vector3 temp = transform.position;
            temp.z = 0f;
            box_Obj.transform.position = temp;
        }
        
    }

    public int GetNumberOfBoxes()
    {
        return numberOfBoxes;
    }
}
