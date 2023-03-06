using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nextcolor1 : MonoBehaviour
{
 
    public GameManagerScript GM;
    RawImage img;

    void Start()
    {
        img = GetComponent<RawImage>();
    }

    
    void Update()
    {
      //  img.color = GM.NextColor[1];
        img.texture = GM.NextMatarial[1];
    }
}
