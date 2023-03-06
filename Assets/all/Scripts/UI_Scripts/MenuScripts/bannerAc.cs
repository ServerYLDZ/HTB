using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bannerAc : MonoBehaviour
{
    private AdsScript Ads;
    
    void Start()
    {
        Ads = GetComponent<AdsScript>();
        if(Ads.banner==null)
        Ads.BannerAds();
    }

  
}
