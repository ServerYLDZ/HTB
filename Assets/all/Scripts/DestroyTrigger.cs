using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{

    public GameManagerScript GM;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag=="Ball")
        {
            GM.BallCount++;
            Destroy(collision.gameObject);

            if (GM.BallCount > 0 && GM.ball == null)
            {
                GM.ball = Instantiate(GM.SpawnObj, GM.transform.position + new Vector3(0, 0.5f, 0), GM.transform.rotation, GM.transform);
                GM.ball.deActiveRB();
            }
          
         
        }
        if (collision.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
       

    }
     



}
