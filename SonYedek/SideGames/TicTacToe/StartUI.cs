﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(sceneName: "2MedicTent");
    }
}
