using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlockTriger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerScript GM;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Block")
        {
           Destroy(collision.gameObject);
            if (GM.BallCount >= 10)
                GM.RemainTime -= 10;

            else if (GM.BallCount >= 5)
                GM.RemainTime -= 5;

            else if (GM.BallCount >= 2)
                GM.RemainTime -= 1f;
            
            else
                GM.RemainTime -= 0.5f;
        }

    }
}
