using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobBanner : MonoBehaviour
{
    private string test_unitID = "ca-app-pub-3940256099942544/6300978111";

    public BannerView banner;

    public AdPosition position;



    private void Start()
    {
        MobileAds.Initialize((InitializationStatus) => InitAd());
    }

    void InitAd()
    {
        banner = new BannerView(test_unitID, AdSize.Banner, position);

        AdRequest request = new AdRequest.Builder().Build();

        banner.LoadAd(request);
    }

}
