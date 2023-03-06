using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifetime : MonoBehaviour
{
    Text txt;
   
    void Start()
    {
        txt = GetComponent<Text>();
        txt.text = ((int)PlayerPrefs.GetFloat("maxTime")).ToString();
    }


}
