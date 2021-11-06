using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Ad2 : MonoBehaviour
{
    string UserId = "ca-app-pub-8073019939192864~8827616828";
    string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    public RewardedAd rewardedAd;
    public int reklama_count = 0;
    public GameObject levemanage;
    public int rek_id=0;
    



    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(UserId);


        RequestrewardedAd();


    }




    public void RequestrewardedAd()
    {

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.LoadAd(CreateNewRequest());

        this.rewardedAd.OnAdClosed += HandleOnClosed;
        this.rewardedAd.OnAdLoaded += HandleOnLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;



    }


    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }


    public void HandleOnLoaded(object sender, EventArgs args)
    {





    }

    public void HandleOnAdRewarded(object sender, EventArgs args)
    {


    }

    public void HandleOnClosed(object sender, EventArgs args)
    {


        RequestrewardedAd();






    }
    void Update()
    {
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {if(rek_id==0)
        levemanage.GetComponent<Levelmanager>().coin += 100;
        if (rek_id == 1)
            levemanage.GetComponent<Levelmanager>().mag+= 10;
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }



}
