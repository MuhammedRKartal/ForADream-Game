using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float holep;
    public int width, height, x, y;
    public bool[,] hwalls, vwalls;
    public int [,] st;
    public Transform Level, Player, Goal;
    public GameObject Floor, Wall;
    public CinemachineVirtualCamera cam;

    void Start()
    {
        foreach (Transform child in Level){
            Destroy(child.gameObject);
        }

        hwalls = new bool[width + 1, height];
        vwalls = new bool[width, height + 1];
        int[,] st = new int[width, height]; //2x2 zone at start
        
        

        void depthFirstSearch(int x, int y)
        {
            
            st[x, y] = 1;
            
            Instantiate(Floor, new Vector3(x, y), Quaternion.identity, Level); //put floor at each place

            //possible directions
            var dirs = new[]{
                (x - 1, y, hwalls, x, y, Vector3.right, 90, KeyCode.A),
                (x + 1, y, hwalls, x + 1, y, Vector3.right, 90, KeyCode.D),
                (x, y - 1, vwalls, x, y, Vector3.up, 0, KeyCode.S),
                (x, y + 1, vwalls, x, y + 1, Vector3.up, 0, KeyCode.W),
            };

            foreach (var i in dirs)
            {
                Debug.Log(i);
            }
            foreach (var (nx, ny, wall, wx, wy, sh, ang, k) in dirs.OrderBy(d => Random.value)){
                //if we are not out of the range or place is visited twice create a wall
                if (!(0 <= nx && nx < width && 0 <= ny && ny < height) || (st[nx, ny] == 2 && Random.value > holep)){
                    
                    wall[wx, wy] = true;
                    Instantiate(Wall, new Vector3(wx, wy) - sh / 2, Quaternion.Euler(0, 0, ang), Level);
                }

                //if place isn't visited yet visit
                else if (st[nx, ny] == 0){
                    depthFirstSearch(nx, ny);
                } 
            }
            st[x, y] = 2;
        }
        depthFirstSearch(0,0);

        //Start from a random position
        x = Random.Range(0, width);
        y = Random.Range(0, height);
        Player.position = new Vector3(x, y);

        //Create a random goal position until the distance between goal and player is well
        do Goal.position = new Vector3(Random.Range(0, width), Random.Range(0, height));
        while (Vector3.Distance(Player.position, Goal.position) < (width + height) / 4);
        cam.m_Lens.OrthographicSize = Mathf.Pow(width / 3 + height / 2, 0.7f) + 1;
    }

    void Update()
    {
        //create places
        var dirs = new[]
        {
            (x - 1, y, hwalls, x, y, Vector3.right, 90, KeyCode.A),
            (x + 1, y, hwalls, x + 1, y, Vector3.right, 90, KeyCode.D),
            (x, y - 1, vwalls, x, y, Vector3.up, 0, KeyCode.S),
            (x, y + 1, vwalls, x, y + 1, Vector3.up, 0, KeyCode.W),
        };
        //shuffle the dirs array
        foreach (var (nx, ny, wall, wx, wy, sh, ang, k) in dirs.OrderBy(d => Random.value))
            if (Input.GetKeyDown(k))
            //if there is a wall don't move the player, else move the player
                if (wall[wx, wy])
                    Player.position = Vector3.Lerp(Player.position, new Vector3(nx, ny), 0.1f);
                else (x, y) = (nx, ny);

        Player.position = Vector3.Lerp(Player.position, new Vector3(x, y), Time.deltaTime * 12);
        if (Vector3.Distance(Player.position, Goal.position) < 0.12f)
        {
            if (Random.Range(0, 5) < 3) width++;
            else height++;
            Start();
        }
    }
}