using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Maze : MonoBehaviour
{

	private int MOVE_STRAIGHT_COST = 10;

    private enum Directions{
        N = 1,
        S = 2,
        E = 4,
        W = 8
    }

    private const int _rowDimension = 0;
	private const int _columnDimension = 1;

    public int xP = 0;
    public int yP = 0;
    public GameObject hwall,vwall;
	public int[,] Cells;
    public Transform player,goal;
    
    public int[,] Initialise(int rows, int columns)
	{
		var cells = new int[rows, columns];

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				cells[i, j] = 0;
			}				
		}

		return cells;
	}

    private Dictionary<Directions, int> DirectionX = new Dictionary<Directions, int>
	{
		{ Directions.N, 0 },
		{ Directions.S, 0 },
		{ Directions.E, 1 },
		{ Directions.W, -1 }
	};

	private Dictionary<Directions, int> DirectionY = new Dictionary<Directions, int>
	{
		{ Directions.N, -1 },
		{ Directions.S, 1 },
		{ Directions.E, 0 },
		{ Directions.W, 0 }
	};

	private Dictionary<Directions, Directions> Opposite = new Dictionary<Directions, Directions>
	{
		{ Directions.N, Directions.S },
		{ Directions.S, Directions.N },
		{ Directions.E, Directions.W },
		{ Directions.W, Directions.E }
	};

    public int[,] Generate()
	{
		var cells = Cells;
		CarvePassagesFrom(0, 0, ref cells);
		return cells;
	}

	public void CarvePassagesFrom(int currentX, int currentY, ref int[,] grid)
	{
		var directions = new List<Directions>
		{
			Directions.N,
			Directions.S,
			Directions.E,
			Directions.W
		}.OrderBy(x => Guid.NewGuid());

		foreach (var direction in directions)
		{
			var nextX = currentX + DirectionX[direction];
			var nextY = currentY + DirectionY[direction];

			if (IsOutOfBounds(nextX, nextY, grid))
				continue;

			if (grid[nextY, nextX] != 0) // has been visited
				continue;

			grid[currentY, currentX] |= (int)direction;
			grid[nextY, nextX] |= (int)Opposite[direction];

			CarvePassagesFrom(nextX, nextY, ref grid);
		}
	}

	private bool IsOutOfBounds(int x, int y, int[,] grid)
	{
		if (x < 0 || x > grid.GetLength(_rowDimension) - 1)
			return true;

		if (y < 0 || y > grid.GetLength(_columnDimension) - 1)
			return true;

		return false;
	}

    public void Print(int[,] grid)
	{
		var rows = grid.GetLength(_rowDimension);
		var columns = grid.GetLength(_columnDimension);
        
		// Top line
		for (int i = 0; i < columns; i++)
			Instantiate(hwall,new Vector3(i,0,0),Quaternion.identity);

		for (int y = 0; y < rows; y++)
		{
			Instantiate(vwall,new Vector3(0,y,0),Quaternion.identity);

			for (int x = 0; x < columns; x++)
			{
				var directions = (Directions)grid[y, x];
                if(directions.HasFlag(Directions.S)== false){
                    Instantiate(hwall,new Vector3(x,y+1,0),Quaternion.identity);
                }
                if(directions.HasFlag(Directions.E) == false){
                    Instantiate(vwall,new Vector3(x+1,y,0),Quaternion.identity);
                }			
			}
		}
	}

    void Start()
    {
        Cells = Initialise(10,10);
        Cells = Generate();
        player.position = new Vector3(0,0,-1);
        Print(Cells);
    }

    // Update is called once per frame
    void Update()
    {
		//FindPath(new Vector3(0,0,-1), new Vector3(9,9,-1));



        if (player.position == new Vector3(9,9,-1)){
            Debug.Log("End");
        }
        else{
            var directions = (Directions)Cells[yP, xP];
            if (Input.GetKeyDown(KeyCode.W)){ 
                if(directions.HasFlag(Directions.S)== true){
                    player.Translate(new Vector2(0, 1.0f) * 1.0f);
                    yP++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                if(directions.HasFlag(Directions.N)== true){
                    player.Translate(new Vector2(0, -1.0f) * 1.0f);
                    yP--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A)){
                if(directions.HasFlag(Directions.W)== true){
                    player.Translate(new Vector2(-1.0f, 0) * 1.0f);
                    xP--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D)){
                if(directions.HasFlag(Directions.E)== true){
                    player.Translate(new Vector2(1.0f, 0) * 1.0f);
                    xP++;
                }
            }
        }
	}


	/*
	private List<Node> FindPath(int startX, int startY, int endX, int endY){
		Node startNode = new Node(Cells[startX, startY])
	}

	private int CalculateDistanceCost(Node a, Node b){
		int xDistance = Math.abs(a.x - b.x);
		int yDistance = Math.abs(a.y - b.y);
		int remaining = Math.abs(xDistance+yDistance);
		return MOVE_STRAIGHT_COST * remaining;
	}
	*/





	/*
	public List<Node> GetNeighboringNodes(Node a_NeighborNode)
    {
        List<Node> NeighborList = new List<Node>();
        int icheckX;
        int icheckY;

		var directions = (Directions)Cells[icheckY, icheckX];

		if(directions.HasFlag(Directions.S)== true){
            NeighborList.Add(Cells[icheckX, icheckY+1]);
        }

		if(directions.HasFlag(Directions.N)== true){
            NeighborList.Add(Cells[icheckX, icheckY-1]);
        }

		if(directions.HasFlag(Directions.W)== true){
            NeighborList.Add(Cells[icheckX-1, icheckY]);
        }

		if(directions.HasFlag(Directions.E)== true){
            NeighborList.Add(Cells[icheckX+1, icheckY]);
        }

        return NeighborList;//Return the neighbors list.
    }
        */
    
}
