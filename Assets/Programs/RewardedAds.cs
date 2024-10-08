using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
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
    }

    public void LoadRewardedAd(){
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd(){
        adUnitId = "Rewarded_Android";
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
    }
 #region showCallbacks
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message){}
    public void OnUnityAdsShowStart(string placementId){}
    public void OnUnityAdsShowClick(string placementId){}
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState){
        if(placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)){
            Debug.Log("Ads Fully Watched");
            UIRunner.Instance.isRewarded = true;
            UIRunner.Instance.ContinueClick();
        }
    }
    #endregion
    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }
}
