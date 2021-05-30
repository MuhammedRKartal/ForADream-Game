using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GridSizeChanger : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(MakeGrid());
    }

    private IEnumerator MakeGrid()
    {
        yield return new WaitForSeconds(0.25f);
        GameManager.Instance.ChangeGridSize(3, 3);
    }
}
