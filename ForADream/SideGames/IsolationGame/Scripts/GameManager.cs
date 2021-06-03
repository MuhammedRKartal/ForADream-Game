using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static bool isGameOver;

    public event Action<int, int> onGridSizeChanged;
    public event Action onGameStarted;
    public event Action<Vector3> OnInput;
    public event Action<PlayerPawn> onTurnChanged;
    public event Action<EndState> onEndState;
    public event Action<Gameplay> onGameplayChanged;
    public event Action<Vector3Int> onTurnPlayed;
    

    public int minimaxDepth;
    public int treeDepth;
    public HeuristicType heuristicType;

    public string sname;

    private void Awake()
    {
        Instance = this;
        
    }
    void Start(){
        Instance.CreateGrid(3,3);
        if(PlayerPrefs.GetInt("isDefensive") == 1){
            heuristicType = HeuristicType.Defensive;
        }
        else if(PlayerPrefs.GetInt("isOffensive") == 1){
            heuristicType = HeuristicType.Offensive;
        }
        else if(PlayerPrefs.GetInt("isSimple") == 1){
            heuristicType = HeuristicType.Simple;
        }
    }

    void Update(){
        Debug.Log(PlayerPrefs.GetInt("playCount"));
        if(PlayerPrefs.GetInt("playCount") >= 2){
            SceneManager.LoadScene(sceneName: sname);
        }
    }

    public void CreateGrid(int x, int y)
    {
        onGridSizeChanged?.Invoke(x, y);
        StartGame();
    }

    public void StartGame()
    {
        onGameStarted?.Invoke();
    }

    public void BroadcastInput(Vector3 pos)
    {
        OnInput?.Invoke(pos);
    }

    public void BroadcastChangeTurn(PlayerPawn player)
    {
        onTurnChanged?.Invoke(player);
    }

    public void BroadcastEndState(EndState endState)
    {
        onEndState?.Invoke(endState);
        isGameOver = true;
    }

    public void ChangeGamePlay(Gameplay gameplay)
    {
        onGameplayChanged?.Invoke(gameplay);
    }

    public void TurnPlayed(Vector3Int tilePos)
    {
        FindObjectOfType<AudioManager>().Play("Isolation");
        onTurnPlayed?.Invoke(tilePos);
    }
}
