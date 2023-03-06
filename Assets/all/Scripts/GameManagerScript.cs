using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    #region Singleton class : GameManager

    public static GameManagerScript Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            cam = Camera.main;
        }
        
    }
    #endregion
    public Ball SpawnObj;
    public Ball ball;
    public Trajectory trajectory;
    public float pushForce = 4.0f;
    public int BallCount = 1;
   

    Camera cam;
    bool isDragging=false;
    Vector2 StartPoint;
    Vector2 EndPoint;
    Vector2 Direction;
    Vector2 Force;
    float Distance;
    public float DelayTime;

    public bool isGameEnd = false;
    public bool isGameEndOnce = false;
    public int Score = 0;
    public int maxScore = 0;
    public int TmpScore = 0;
    public float RemainTime = 60.0f;
    public float CurrentTime = 0;
    public float maxTime = 0;

    public float BlockSpawnTİme = 2.0f;
    public Color32[] NextColor = new Color32[3];
    public Color32[] colors;

    public Sprite[] BallMatarialsNext;
    public Sprite[] BallSpirtes;
    public Texture[] NextMatarial;
    public Texture[] matarials;
    public Sprite DesiredMatarial;


    private AudioSource BG_Sound;
    public AudioClip Thorow;
    public AudioClip ClickSwitch;


    private  AdsScript Ads;

    public GameObject canvas;
    public Button RewardButton;
    public Sprite rewardblursprite;
   

    private void Start()
    {
        maxScore= PlayerPrefs.GetInt("maxScore");
        maxTime = PlayerPrefs.GetFloat("maxTime");
        BG_Sound = GetComponent<AudioSource>();
        Ads = GetComponent<AdsScript>();

        PrapereColor();
        
    }
    private void Update()
    {
        if (RemainTime<=0)
        {
            RemainTime = 0;
            GameOver();
            Debug.Log("Game Over");
        }
        RemainTime -= Time.deltaTime;
        CurrentTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
     
            onDragStart();


        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            onDragEnd();
        }
        if (isDragging)
        {
            Dragging();
        }

    }

    void onDragStart()
    {

     
        
            if (BallCount > 0 && ball == null)
            {
                
                ball = Instantiate(SpawnObj, transform.position+new Vector3(0,0.5f,0), transform.rotation,this.transform);
              
           
            }

            if (ball)
            {
                
                Ads.bannerdestroyads();
                ball.deActiveRB();
                StartPoint = cam.ScreenToWorldPoint(Input.mousePosition);

            }

        
        
       

    }
    void onDragEnd()
    {
        
        if (ball)
        {
            
            if (Force.y > 2)
            {
                
                ball.ActiveRB();
                ball.Push(Force);
                
                ball = null;
                BallCount--;
                trajectory.Hide();

                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

                if (Thorow )
                {
                   // BG_Sound.PlayOneShot(Thorow);//dışardan gelen sesi çal 
                    BG_Sound.Play();
                }
              
            }
          
           
        }
         



    }
    void Dragging()
    {
        EndPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Distance = Vector2.Distance(StartPoint, EndPoint);
        Direction = (StartPoint - EndPoint).normalized;

       
      

        Force = Direction * Distance *pushForce;
        Force.y *= 16;
      
        Force.x *= 8;
        Force.y= Mathf.Clamp(Force.y, 2, 30);

        Debug.Log(Force.y);


        Debug.DrawLine(StartPoint, EndPoint);

        if (ball && Force.y > 2)
        {
            trajectory.Show();
            trajectory.UpdateDots(ball.pos, Force);


            // açı hesaplama
            float angel = Mathf.Atan2(Force.y, Force.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);


        }
        else
            trajectory.Hide();
    }


   

    void PrapereColor()
    {
        for (int i = 0; i < NextColor.Length; i++)
        {
            int colorindx = Random.Range(0, 4);
            NextColor[i] = colors[colorindx];
            NextMatarial[i] = matarials[colorindx];
            switch (colorindx)
            {
                case 0:
                    //purple
                    BallMatarialsNext[i] = BallSpirtes[0];
                    break;
                case 1:
                    //red
                    BallMatarialsNext[i] = BallSpirtes[1];
                    break;
                case 2:
                    //green
                    BallMatarialsNext[i] = BallSpirtes[2];
                    break;
                case 3:
                    //blue
                    BallMatarialsNext[i] = BallSpirtes[3];
                    break;

            }
        }

    }

       public void ChangeColor()
       {
        if (ClickSwitch)
            BG_Sound.PlayOneShot(ClickSwitch);//dışardan gelen sesi çal 
        if (ball)
        {
            ball.AsiggnColor();
          
        }
        else
        {

            for (int i = 0; i < 3; i++)
            {

                if (i == 2)
                {
                    // burası  sıradaki mataryel dizisinin değişeceği yerleri içeriyor ..................................
                    int colorindx = Random.Range(0, 4);
                    NextColor[i] = colors[colorindx];
                    NextMatarial[i] = matarials[colorindx];
                    BallMatarialsNext[i] = BallSpirtes[colorindx];
                }
                else
                {
                    NextColor[i] = NextColor[i + 1];
                    NextMatarial[i] = NextMatarial[i + 1];
                    BallMatarialsNext[i] = BallMatarialsNext[i + 1];
                }
                   
            }
            
        }
     
       }

        void GameOver()
    {
    
        // skor ve max zaman kaydetme
        if (Score > maxScore)
        {
            PlayerPrefs.SetInt("maxScore", Score);

        }
        if (CurrentTime >maxTime)
        {
            PlayerPrefs.SetFloat("maxTime",CurrentTime);
        }


        if (!isGameEndOnce)
        {
            canvas.SetActive(true);
            isGameEndOnce = true;
            Ads.isRewardEarned = false;

          

            Time.timeScale = 0f;// pause game
            RemainTime = 0.1f;
        }
        else
        {
             canvas.SetActive(true);
            RewardButton.enabled = false;
            RewardButton.GetComponent<Image>().sprite = rewardblursprite;
           
            Time.timeScale = 0f;// pause game
          
             RemainTime = 0.1f;

        }
           // GoMenu();
       

        //RemainTime = 40;
        //SceneManager.LoadScene("Menu");



    }
    public void Delay(float Time)
    {
        DelayTime = Time;
        StartCoroutine(Text());

    }

    IEnumerator Text()  //  <-  its a standalone method
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(DelayTime);
        Debug.Log("ByeBye");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   

}
