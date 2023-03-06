using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallCountText : MonoBehaviour
{
    Text txt;
    public GameManagerScript GM;

    private void Start()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        txt.text = "x"+GM.BallCount;
    }

}
