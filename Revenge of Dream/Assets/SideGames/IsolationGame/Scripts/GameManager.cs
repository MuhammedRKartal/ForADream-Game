using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetHeuristicType(int heuristicType)
    {
        if (heuristicType == 0)
        {
            this.heuristicType = HeuristicType.Simple;
        }
        else if(heuristicType == 1){
            this.heuristicType = HeuristicType.Defensive;
        }
        else if(heuristicType == 2){
            this.heuristicType = HeuristicType.Offensive;
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
        onTurnPlayed?.Invoke(tilePos);
    }
}
