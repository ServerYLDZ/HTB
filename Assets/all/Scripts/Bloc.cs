using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{
    private Ball Target;
    public GameManagerScript GM;

    private Rigidbody2D rb;
    private BoxCollider2D colider;
    private SpriteRenderer sr;

    public float Speed=-10;
  
    public Color32 [] colors=new Color32[4];
    public Color32 DesiredColor;

    public Sprite[] matarials;
    public Sprite DesiredMatarial;

    private AudioSource Collect_sound;
    
    public void DisableRb()
    {
        rb.isKinematic = true;
    }
    void RandomColor()
    {
        
        int colorindx = Random.Range(0, 4);
        DesiredColor = colors[colorindx];
        // metaryelinide burda  degistirebiliriz  ..........................
        //sr.color = colors[colorindx];
        sr.sprite = matarials[colorindx];

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

           RandomColor();


        VelocityBlock();
    }
    private void Start()
    {

        Collect_sound = GetComponent<AudioSource>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colider.isTrigger = true;
        VelocityBlock();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {

            // collision.gameObject.GetComponent<SpriteRenderer>().color
            if (collision.GetComponent<Ball>().DesiredColor.Equals(DesiredColor)) 
            {
               
                GM.TmpScore++;
                GM.Score++;
                if (GM.TmpScore == 10)// how many score can incresse bol countt
                {
                    GM.TmpScore = 0;
                    GM.BallCount++;
                    GM.BallCount = Mathf.Clamp(GM.BallCount, 0, 11);
                    
                }
                GM.RemainTime += 1;

                Collect_sound.Play();
                Destroy(this.gameObject);
            }
            else
            {
                colider.isTrigger = false;
                VelocityBlock();
            }
                

        }
    }

    public void VelocityBlock()
    {
       
        rb.isKinematic = false;   
        colider.enabled = true;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, Speed);
        int yon= (int)Random.Range(0, 1.99f);
        if(yon==1)
        rb.angularVelocity = Speed * 100;
        else
         rb.angularVelocity = Speed * 100*-1;
    }
    
}
