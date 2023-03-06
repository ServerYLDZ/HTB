using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnPoints : MonoBehaviour
{
     public Bloc SpawnObj;
     public GameManagerScript GM;
     private Transform TransformPosition;
     private Transform[]TransformPositions;
    private AudioSource BG_Sound;
    float i = 0;
    float k = 0;
    int m = 0;
    private int[] IntArray;
    

    void Start()
    {
        IntArray = new int[5];
        TransformPosition = GetComponent<Transform>();
        TransformPositions = new Transform[5];
        ReadyToArray();
        BG_Sound = GetComponent<AudioSource>();
        BG_Sound.Play();
        SpawnBlock();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GM.RemainTime>0)
        {
            //sürekli block spawnlama
            if (i >= GM.BlockSpawnTİme)
            {
                //eger 40 saniyeyi geçmişse
                if (GM.CurrentTime >= 40)
                {
                    int howmany = Random.Range(1, 4);
                   
                   
                    for (int i=0;i<howmany;i++)
                    {
                        SpawnBlock();
                       
                        if (CheckAllReset())
                        {
                            m = 0;
                        }

                    }
                    ReadyToArray();
                    m = 0;

                }
                else
                SpawnBlock();
                i = 0;
            }
            i += Time.deltaTime;
            //her 5 saniyede bir spawn süresi azalması
            if (k >= 5)
            {
                GM.BlockSpawnTİme -= 0.12f;
                GM.BlockSpawnTİme = Mathf.Clamp(GM.BlockSpawnTİme, 0.5f, 6.0f);
                SpawnObj.Speed += -0.1f;
                SpawnObj.Speed= Mathf.Clamp(SpawnObj.Speed, -4f, 6f);

                k = 0;
            }
            k += Time.deltaTime;
        }
        
    }
    void ReadyBlock()
    {
        for(int i = 0; i< 4; i++)
        {
            TransformPositions[i] = TransformPosition;
        }
       
    }

    void ReadyToArray()
    {
        for (int i = 0; i < 4; i++)
        {
            IntArray[i] = -1;
        }
    }
    void RandomIntArraySetup(int value)
    {
       
        for(int i = 0; i < value; i++)
        {
            if (IntArray[i] == -1 )
            {
                int tmp= Random.Range(0, 4);
                if (!Checkishere(tmp))
                {
                    IntArray[i] = tmp;
                    //Debug.Log(IntArray[i]);
                }
                else
                i--;
                
            }
        }

    }
    bool Checkishere(int value)
    {

        for(int i = 0; i < 4; i++)
        {
            if (IntArray[i] == value)
            
                return true;
      
        }
        return false;
    }
    bool CheckAllReset()
    {
        for(int i = 0; i < 4; i++)
        {
            if (IntArray[i] != -1)
                return false;

        }

        return true; 
    }


    void SpawnBlock()
    {
        

        int sayi;
        if (GM.CurrentTime >= 40)
        {
            if (m == 0)
            {
                RandomIntArraySetup(4);
            }


         
            
            sayi = IntArray[m];
            IntArray[m] = -1;
            m++;
          
        }
        else
            sayi = Random.Range(0, 4);


        TransformPositions[sayi] = Instantiate(SpawnObj, null).transform;
        TransformPositions[sayi].position = TransformPosition.position;

        TransformPositions[sayi].position += new Vector3((sayi * 1.2f) + 1.3f,-0.8f, 0);

    }
}
