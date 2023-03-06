using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public AdsScript Ads;
    float DelayTime=1.0f;
    private void Start()
    {
        Ads = GetComponent<AdsScript>();
    }
    private void Update()
    {     
        
    }
    public void OpenScene()
    {
        Ads.bannerdestroyads();
        Ads.ShowInterAds();
        Delay(1);
        //StartCoroutine(Text());

       

    }
    public void Delay(float Time)
    {
        DelayTime = Time;
     
        StartCoroutine(Text());

    }

    IEnumerator Text()  //  <-  its a standalone method
    {
     
      
        yield return new WaitForSeconds(DelayTime);
        SceneManager.LoadScene("SampleScene");
     
    }


}
