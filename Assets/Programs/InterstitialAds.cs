using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
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
    }
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
