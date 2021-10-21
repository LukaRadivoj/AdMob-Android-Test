using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobAdController : MonoBehaviour, IAdContoller
{
    public bool masterAdControllerInitialization { get; private set; } = false;

    public bool refreshAds { get; private set; } = false;

    private AdsConfiguration adsConfiguration;
    [SerializeField] private AdsConfiguration androidAdsConfiguration;
    [SerializeField] private AdsConfiguration iosAdsConfiguration;


    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    private OnAdFinished onAdFinishedBuffer;
    private OnAdStarted onAdStartedBuffer;

    private AdType currentInterstitialAd = AdType.None;
    private AdType currentRewardedAd = AdType.None;

    public void InitializeAdController()
    {
        this.masterAdControllerInitialization = true;
#if UNITY_IOS
        this.adsConfiguration = this.iosAdsConfiguration;
#elif UNITY_ANDROID
        this.adsConfiguration = this.androidAdsConfiguration;
#elif UNITY_EDITOR
        this.adsConfiguration = this.iosAdsConfiguration;
#endif

        Debug.Log("Starting Ads Initialization");
        MobileAds.Initialize(initializationStatus =>
        {
            Debug.Log("Action Started");
            Dictionary<string, AdapterStatus> adapterStatusMap = initializationStatus.getAdapterStatusMap();
            bool initializationDone = true;
            foreach (AdapterStatus adapterStatus in adapterStatusMap.Values)
            {
                if (adapterStatus.InitializationState == AdapterState.NotReady)
                {
                    initializationDone = false;
                    break;
                }
            }
            if (initializationDone)
            {
                Debug.Log("Initialization Done");
                if (this.masterAdControllerInitialization)
                {
                    this.masterAdControllerInitialization = false;
                }
            }
        });
    }


    public void RefreshAds()
    {
        StartCoroutine(RefreshingAds());
    }

    private IEnumerator RefreshingAds()
    {
        yield return null;
        
    }

    public void PlayAd(AdType adType)
    {

        if (!this.adsConfiguration.adsWithFakeRewards.Contains(adType))
        {
            this.currentRewardedAd = adType;
            StartCoroutine(RegisterAdActivityReward());
        }
        else
        {
            this.onAdFinishedBuffer?.Invoke(adType, true);
        }

    }

    //A function that constructs and strats the loading process of an interstitial ad with the given placement ID
    private void PlayInterstatialAd(string interstitialAdPlacementId)
    {
        //Construct a new interstatial ad object
        this.interstitialAd = new InterstitialAd(interstitialAdPlacementId);

        //Subscribe to the needed delegates
        this.interstitialAd.OnAdLoaded += OnInterstitialAdLoaded;
        this.interstitialAd.OnAdFailedToLoad += OnInterstitialAdFailedToLoad;
        this.interstitialAd.OnAdOpening += OnInterstitialAdOpened;
        this.interstitialAd.OnAdClosed += OnInterstitialAdClosed;

        //Build an ad request and start loading the interstatial ad
        AdRequest adRequest = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(adRequest);
    }

    //A coroutine that loads and shows a rewarded ad with the given placement ID
    private void PlayRewardedAd(string rewardedAdPlacementId)
    {
        //Construct a new rewarded ad object
        this.rewardedAd = new RewardedAd(rewardedAdPlacementId);

        //Subscribe to the appropriate delegates
        this.rewardedAd.OnAdLoaded += OnRewardedAdLoaded;
        //this.rewardedAd.OnAdFailedToLoad += OnRewardedAdFailedToLoad;
        this.rewardedAd.OnAdOpening += OnRewardedAdOpened;
        this.rewardedAd.OnAdClosed += OnRewardedAdClosed;
        this.rewardedAd.OnUserEarnedReward += OnPlayerEarnedReward;

        //Build an ad request and start the loading of the rewarded ad
        AdRequest adRequest = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(adRequest);
    }

    public void ShowBanner(GenericBannerPosition genericBannerPosition)
    {
        AdPosition adPosition;
        if (genericBannerPosition == GenericBannerPosition.Top)
        {
            adPosition = AdPosition.Top;
        }
        else
        {
            adPosition = AdPosition.Bottom;
        }
        this.bannerView = new BannerView(this.adsConfiguration.clientAdPlacementIds[AdType.BannerAd], AdSize.Banner, adPosition);
        AdRequest adRequest = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(adRequest);
    }

    public void HideBanner()
    {
        if (bannerView != null)
        {
            this.bannerView.Destroy();
            this.bannerView = null;
        }
    }

    public void SubscribeToAdFinished(OnAdFinished onAdFinished)
    {
        this.onAdFinishedBuffer += onAdFinished;
    }

    public void SubscribeToAdStarted(OnAdStarted onAdStarted)
    {
        this.onAdStartedBuffer += onAdStarted;
    }

    public void UnsubscribeToAdFinished(OnAdFinished onAdFinished)
    {
        this.onAdFinishedBuffer -= onAdFinished;
    }

    public void UnsubscribeToAdStarted(OnAdStarted onAdStarted)
    {
        this.onAdStartedBuffer -= onAdStarted;
    }

    //Callback functions for the MobileAds delegates
    #region Interstatial Ads Delegates
    public void OnInterstitialAdClosed(object sender, EventArgs args)
    {
       
    }

    public void OnInterstitialAdLoaded(object sender, EventArgs args)
    {
        //If the interstitial ad loaded successfully, show the loaded ad
        this.interstitialAd.Show();
    }

    public void OnInterstitialAdOpened(object sender, EventArgs args)
    {
        
    }

    public void OnInterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        this.onAdFinishedBuffer?.Invoke(this.currentInterstitialAd, false);
        this.interstitialAd.Destroy();
        this.interstitialAd = null;
    }
    #endregion

    #region Rewarded Ads Delegates
    public void OnRewardedAdClosed(object sender, EventArgs args)
    {
       
    }

    public void OnRewardedAdLoaded(object sender, EventArgs args)
    {
        //If the rewarded ad loaded successfully, show the loaded ad
        this.rewardedAd.Show();
    }

    public void OnRewardedAdOpened(object sender, EventArgs args)
    {
        
    }

    public void OnRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        this.onAdFinishedBuffer?.Invoke(this.currentRewardedAd, false);
        this.currentRewardedAd = AdType.None;
        this.rewardedAd = null;
    }

    public void OnPlayerEarnedReward(object sender, Reward args)
    {
        Debug.Log("OnPlayerEarnedReward");
        StartCoroutine(RegisterAdActivityReward());
    }

    private IEnumerator RegisterAdActivityReward()
    {
        yield return null;
    }

    public int GetRemainingAdPlacements(AdType adType)
    {
        throw new NotImplementedException();
    }

    public string GetRewardDescription(AdType adType)
    {
        throw new NotImplementedException();
    }

    public double GetRewardPlacementViewResetMinutes(AdType adType)
    {
        throw new NotImplementedException();
    }

    public string GetCurrentRewardDescription()
    {
        throw new NotImplementedException();
    }
    #endregion

}
