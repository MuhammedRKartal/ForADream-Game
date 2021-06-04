using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    private void Update(){
        ProcessClick();

    }
    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckTile(pos);
        }
    }
    private void CheckTile(Vector3 pos)
    {
        GameManager.Instance.BroadcastInput(pos);
    }
}
