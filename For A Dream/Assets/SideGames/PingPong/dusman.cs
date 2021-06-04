using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    void Start()
    {
        Launch();
    }


    void Update()
    {

    }

    private void Launch()
    {
        
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(0, speed * y);
    }
}
