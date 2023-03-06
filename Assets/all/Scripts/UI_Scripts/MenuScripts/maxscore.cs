using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class maxscore : MonoBehaviour
{
   
    Text txt;
    private void Start()
    {
        txt = GetComponent<Text>();
        txt.text = PlayerPrefs.GetInt("maxScore").ToString();
    }
 
}
