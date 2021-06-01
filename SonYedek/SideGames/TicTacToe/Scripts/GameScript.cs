using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour
{
    public GameObject cross, circle, bar;
    //public Text Instructions;
    public enum Seed { EMPTY, CROSS, CIRCLE };
    public Seed Turn;

    public string sname;
    public bool isEasy = false;

    public GameObject[] allSpawns = new GameObject[9];
    public Seed[] player = new Seed[9];

    Vector2 pos1, pos2;

    public int id;
    public GameObject cameraM;

    private void OnMouseDown()
    {
        cameraM.GetComponent<GameScript>().Spawn(this.gameObject, id);
    }
    
    private void Awake()
    {
        Turn = Seed.CROSS;
        for (int i = 0; i < 9; i++)
            player[i] = Seed.EMPTY;
    }
    

    public void Spawn(GameObject emptycell, int id)
    {
        if (Turn == Seed.CROSS)
        {
            allSpawns[id] = Instantiate(cross, emptycell.transform.position, Quaternion.identity);
            Destroy(emptycell);
            player[id] = Turn;
            if (Won(Turn))
            {
                Turn = Seed.EMPTY;
                SceneManager.LoadScene(sceneName: sname);
            }
            else
            {
                Turn = Seed.CIRCLE;
            }
            
        }

        if (Turn == Seed.CIRCLE)
        {
            int bestScore = -1, bestPos = -1, score;

            for (int i = 0; i < 9; i++)
            {
                if (player[i] == Seed.EMPTY)
                {
                    player[i] = Seed.CIRCLE;
                    score = minimax(Seed.CROSS, player, -1000, +1000);
                    player[i] = Seed.EMPTY;

                    if (bestScore < score)
                    {
                        bestScore = score;
                        bestPos = i;
                    }
                }
            }
                
            //if there is a best position
            if (bestPos > -1){
                allSpawns[bestPos] = Instantiate(circle, allSpawns[bestPos].transform.position, Quaternion.identity);

                string x = "EmptyCell0 (" + bestPos + ")"; 
                if(bestPos == 0){
                    x = "EmptyCell0";
                }
                Destroy(GameObject.Find(x));

                player[bestPos] = Turn;
            }
            
            if (Won(Turn))
            {
                // change the turn
                Turn = Seed.EMPTY;
                SceneManager.LoadScene(sceneName: sname);
            }
            else
            {
                // change the turn
                Turn = Seed.CROSS;             
            }
        }
        

        if (IsDraw())
        {
            // change the turn
            Turn = Seed.EMPTY;
            SceneManager.LoadScene(sceneName: sname);
        } 
    }

    bool IsAnyEmpty()
    {
        bool empty = false;
        for (int i = 0; i < 9; i++)
        {
            if (player[i] == Seed.EMPTY)
            {
                empty = true;
                break;
            }
        }
        return empty;
    }

    bool Won(Seed currPlayer)
    {
        bool hasWon = false;

        int[,] allConditions = new int[8, 3] { {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                                                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                                                {0, 4, 8}, {2, 4, 6} };

        // check conditions
        for (int i = 0; i < 8; i++)
        {
            if (player[allConditions[i, 0]] == currPlayer & player[allConditions[i, 1]] == currPlayer &player[allConditions[i, 2]] == currPlayer){
                hasWon = true;

                // keep track of the winning positions to spawn a Bar
                pos1 = allSpawns[allConditions[i, 0]].transform.position;
                pos2 = allSpawns[allConditions[i, 2]].transform.position;
                break;
            }
        }
        return hasWon;
    }

    bool IsDraw()
    {
        bool player1Won, player2Won, anyEmpty;
        player1Won = Won(Seed.CROSS);
        player2Won = Won(Seed.CIRCLE);
        anyEmpty = IsAnyEmpty();

        bool isDraw = false;

        if (player1Won == false & player2Won == false & anyEmpty == false)
            isDraw = true;

        return isDraw;
    }

    Vector2 calculateCenter()
    {
        float x = (pos1.x + pos2.x) / 2,
            y = (pos1.y + pos2.y) / 2;

        return new Vector2(x, y);
    }

    int minimax(Seed currPlayer, Seed[] board, int alpha, int beta)
    {

        if (IsDraw())
            return 0;

        if (Won(Seed.CIRCLE))
            return +10;

        if (Won(Seed.CROSS))
            return -10;


        int score;

        if(currPlayer == Seed.CIRCLE){
            if(isEasy == false){
                for(int i=0; i < 9; i++){
                    if(board[i] == Seed.EMPTY){
                        board[i] = Seed.CIRCLE;
                        score = minimax(Seed.CROSS, board, alpha, beta);
                        board[i] = Seed.EMPTY;
                        if (score > alpha)
                            alpha = score;
                        if (alpha > beta)
                            break;
                    }
                }
            }
            else{
                for(int i=0; i < 8; i++){
                    if(board[i] == Seed.EMPTY){
                        board[i] = Seed.CIRCLE;
                        score = minimax(Seed.CROSS, board, alpha, beta);
                        board[i] = Seed.EMPTY;
                        if (score > alpha)
                            alpha = score;
                        if (alpha > beta)
                            break;
                    }
                }
            }
            
            return alpha;
        }
        else{
            if(isEasy == false){
                for (int i = 0; i < 9; i++){
                    if (board[i] == Seed.EMPTY){
                        board[i] = Seed.CROSS;
                        score = minimax(Seed.CIRCLE, board, alpha, beta);
                        board[i] = Seed.EMPTY;

                        if (score < beta)
                            beta = score;
                        if (alpha > beta)
                            break;
                    }
                }
            }
            else{
                for (int i = 0; i < 8; i++){
                    if (board[i] == Seed.EMPTY){
                        board[i] = Seed.CROSS;
                        score = minimax(Seed.CIRCLE, board, alpha, beta);
                        board[i] = Seed.EMPTY;

                        if (score < beta)
                            beta = score;
                        if (alpha > beta)
                            break;
                    }
                }
            }
                
            return beta;
        }
    }

}


