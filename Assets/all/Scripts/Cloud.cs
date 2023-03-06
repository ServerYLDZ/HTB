using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    Vector3 pos = new Vector3(0, 0, 0);
    bool isReverse = false;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isReverse)
        {
          
            if (pos.x>=0.4f)
            isReverse = !isReverse;
            pos.x = Mathf.Lerp(pos.x,0.5f, Time.deltaTime * speed);
           
            this.transform.position= pos;
          


        }
        else
        {
            
            if (pos.x <=-0.4f)
                isReverse = !isReverse;
            pos.x = Mathf.Lerp(pos.x, -0.5f, Time.deltaTime * speed);

            this.transform.position = pos;

        }
      
        


    }
}
