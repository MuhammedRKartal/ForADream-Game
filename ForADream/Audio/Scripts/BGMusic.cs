using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public string musicName;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(musicName);
        PlayerPrefs.SetString("lastMusic", musicName);
        Debug.Log(PlayerPrefs.GetString("lastMusic"));
    }

}
