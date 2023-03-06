using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchAnim : MonoBehaviour
{
    Text txt;
   
    public float speed;
    Vector3 scale = new Vector3(0, 0, 0);
    bool isReverse = false;
    private AudioSource BG_Sound;
    private void Awake()
    {
        txt = GetComponent<Text>();
        scale = txt.rectTransform.localScale;
        BG_Sound = GetComponent<AudioSource>();
        BG_Sound.Play();
    }
    
    void Update()
    {
        if (!isReverse)
        {
            if (scale.x > 3.5f)
            {
                isReverse = true;
            }
            scale.x = Mathf.Lerp(scale.x, 3.6f, Time.deltaTime*speed);
            scale.y = Mathf.Lerp(scale.y, 3.6f, Time.deltaTime * speed);
            txt.rectTransform.localScale = scale;
           
            

        }
        else
        {
            if (scale.x <3.1)
            {
                isReverse = false;
            }
            scale.x = Mathf.Lerp(scale.x, 3, Time.deltaTime * speed);
            scale.y = Mathf.Lerp(scale.y, 3, Time.deltaTime * speed);
            txt.rectTransform.localScale = scale;
        
            
        }
    
    }
}
