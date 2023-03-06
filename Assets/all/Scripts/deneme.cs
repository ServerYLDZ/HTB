using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
