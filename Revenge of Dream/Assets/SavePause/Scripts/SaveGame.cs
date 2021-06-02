using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public void Save(){
        string nameOfScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("sceneSave", nameOfScene);
    }
}
