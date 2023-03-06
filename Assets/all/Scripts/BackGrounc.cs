using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounc : MonoBehaviour
{
   [HideInInspector] public SpriteRenderer sr;
    public Sprite[] BG_ARRAY;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

       int rand= Random.Range(0, BG_ARRAY.Length);
        sr.sprite = BG_ARRAY[rand];
    }

   
}
