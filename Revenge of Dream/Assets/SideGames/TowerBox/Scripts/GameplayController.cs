using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public BoxSpawner box_Spawner;
    [HideInInspector]
    public BoxScript currentBox;
    public string sname;

    public CameraFollow cameraScript;
    public int moveCount;


    public Text countDown;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        box_Spawner.SpawnBox();
        moveCount=0;
    }

    
    void Update()
    {
        Debug.Log(moveCount);
        DetectInput();
        
    }
    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 0.000000001f);
    }

    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;
        if (moveCount == 3)
        {
            cameraScript.targetPos.y += 2f;          
        }
        if (moveCount == 5)
        {
                SceneManager.LoadScene(sceneName: sname);
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    
}
