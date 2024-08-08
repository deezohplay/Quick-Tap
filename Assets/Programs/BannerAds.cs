using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private string iosGameId;
    // Start is called before the first frame update
    private string gameId;
    private string adUnitId;

    private void Awake(){
        #if UNITY_IOS
        gameId = iosGameId;
        #elif UNITY_ANDROID
        gameId = androidGameId;
        #elif UNITY_EDITOR
        gameId = androidGameId; // for testing
        #endif
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    
    public void LoadBannerAd(){
        BannerLoadOptions options = new BannerLoadOptions{
            loadCallback = BannerLoaded, 
            errorCallback = BannerLoadError
        };
        Advertisement.Banner.Load(adUnitId,options);
    }

    private void BannerLoadError(string message)
    {
        
    }

    private void BannerLoaded()
    {
        
    }

    public void ShowBannerAd(){
        BannerOptions options = new BannerOptions{
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    private void BannerHidden()
    {
        
    }

    private void BannerClicked()
    {
        
    }

    private void BannerShown()
    {
        
    }

    public void HideBannerAd(){
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        ;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }
}
