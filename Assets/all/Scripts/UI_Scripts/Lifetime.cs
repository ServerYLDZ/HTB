using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lifetime : MonoBehaviour
{
    public GameManagerScript GM;
    Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text =((int) GM.CurrentTime).ToString();
    }
}
