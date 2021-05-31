using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public BoxSpawner box_Spawner;
    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;


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
        
    }

    
    void Update()
    {
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
            
                Time.timeScale = 0f;
                countDown.text = "WIN!!";
            
            
        }
    }
  
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    
}
