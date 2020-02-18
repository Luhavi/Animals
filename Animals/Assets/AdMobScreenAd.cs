using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobScreenAd : MonoBehaviour
{
    private string test_unitID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd screenAd;

    private void Start()
    {
        InitAd();
    }

    private void InitAd()
    {
        screenAd = new InterstitialAd(test_unitID);

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
    }

    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            yield return null;
        }
        screenAd.Show();
    }
}
