﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour
{
    public string musicName;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(musicName);
    }
}
