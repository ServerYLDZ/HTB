using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManagerScript GM;

    public Rigidbody2D rb;
    private CircleCollider2D colider;
    private SpriteRenderer sr;
    private TrailRenderer tr;

    public Color32[] colors;
    public Color32 DesiredColor;

    public Sprite[] matarials;
    public Sprite DesiredMatarial;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
        AsiggnColor();
    }
    public void AsiggnColor()
    {

        // sr.color = GM.NextColor[0];
        tr.startColor= GM.NextColor[0];
        sr.sprite = GM.BallMatarialsNext[0];
      // GM den gelen mataryali kullanmalıııııııııııı........................................
        DesiredColor = GM.NextColor[0];
        for(int i = 0; i < 3; i++)
        {

            if (i == 2)
            {
                int colorindx = Random.Range(0, 4);
                GM.NextColor[i] = colors[colorindx];
                GM.NextMatarial[i] = GM.matarials[colorindx];
               GM.BallMatarialsNext[i] =matarials[colorindx];
                // GM den gelen Mataryale  Random mataryel atanmalı bu yüzden  mataryal arrayi oluşturulmalı ;...........................
            }
            else
            {
                GM.NextColor[i] = GM.NextColor[i + 1];
                GM.NextMatarial[i] = GM.NextMatarial[i + 1];
                GM.BallMatarialsNext[i] = GM.BallMatarialsNext[i + 1];


            }
            

        }
    }
    

    public void Push(Vector2 force) {
        rb.velocity = force;
    }
    public  void ActiveRB()
    {
      
        rb.isKinematic=false;
        colider.enabled = true;
       
    }
    public void deActiveRB()
    {
        colider.enabled = false;
        // rb.velocity = Vector2.zero;
        // rb.angularVelocity = 0.0f;
        //rb.isKinematic = true;

    }
}
