using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdsScript : MonoBehaviour
{
    public BannerView banner;
    private InterstitialAd InterstitialAds;
    private RewardedAd Rad;

    public GameManagerScript GM;
  
    public string bannerID;
    public string interID;
    public string rewardID;
    public bool isRewardEarned;

    public GameObject rewardbutton;
    public bool testMode;

    void Start()
    {

        GM = GetComponent<GameManagerScript>();
        MobileAds.Initialize(Ads =>{ });

        if (testMode == true)
        {
            bannerID = "ca-app-pub-3940256099942544/6300978111";
            interID = "ca-app-pub-3940256099942544/1033173712";
            rewardID = "ca-app-pub-3940256099942544/5224354917";
        }
        InterAds();
        RewardAds();

    }
    #region Banner 
    public void BannerAds()
    {
        banner = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest NewAds = new AdRequest.Builder().Build();
      
        banner.LoadAd(NewAds);
        
    }

   public void ShowBannerAds()
    {
        BannerAds();
    }


    public void bannerdestroyads()
    {
        if (banner != null)
            banner.Destroy();

    }

    #endregion

    #region InterstatilAds
    public void InterAds()
    {
        InterstitialAds = new InterstitialAd(interID);
        AdRequest NewAds = new AdRequest.Builder().Build();
        InterstitialAds.OnAdClosed += this.HandleOnAdClosed;
        InterstitialAds.LoadAd(NewAds);

 

        
        
    }
    public void ShowInterAds()
    {
        if(InterstitialAds.IsLoaded())
        InterstitialAds.Show();
    }

    
    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        Time.timeScale = 1f;
        bannerdestroyads();
        InterAds();
        SceneManager.LoadScene("SampleScene");

    }
    #endregion

    #region RewardedAds
    public void RewardAds()
    {
        Rad = new RewardedAd(rewardID);
        AdRequest NewAds = new AdRequest.Builder().Build();
        Rad.OnUserEarnedReward += Rad_OnUserEarnedReward;
        Rad.OnAdClosed += Rad_OnAdClosed;
        
        Rad.LoadAd(NewAds);

    }

    private void Rad_OnAdClosed(object sender, EventArgs e)
    {
        Time.timeScale = 1f;
      
        RewardAds();
       
    }

    private void Rad_OnUserEarnedReward(object sender, Reward e)
    {
        isRewardEarned = true;
        Debug.Log("ödül kazanıldı");
        // oyuncu ne kazandı

        GM.RemainTime += 30;
        GM.canvas.SetActive(false);
    }

    public void ShowRewardAds()
    {
        Rad.Show();
    }
    #endregion
}
