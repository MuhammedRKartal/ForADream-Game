using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPing : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;
	public string sname;
	public GUISkin layout;

	GameObject theBall;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
	}

	public static void Score(string wallID) {
		if (wallID == "RightWall") {
			PlayerScore1++;
		} else {
			PlayerScore2++;
		}
	}

	void OnGUI() {
		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

		if (PlayerScore1 == 3) {
			SceneManager.LoadScene(sceneName: sname);
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		} 
		else if (PlayerScore2 == 3) {
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}

}
