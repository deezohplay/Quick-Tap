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

    public void ShowBannerAd(){
        BannerOptions options = new BannerOptions{
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    public void HideBannerAd(){
        Advertisement.Banner.Hide();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
