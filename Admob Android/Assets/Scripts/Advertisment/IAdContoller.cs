using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerations;
using UnityEngine.Advertisements;

public delegate void OnAdFinished(AdType adType, bool success);
public delegate void OnAdStarted(AdType adType);

public interface IAdContoller
{
    bool masterAdControllerInitialization { get; }
    bool refreshAds { get; }
    void RefreshAds();
    void PlayAd(AdType adType);
    void ShowBanner(GenericBannerPosition genericBannerPosition);
    void HideBanner();
    int GetRemainingAdPlacements(AdType adType);
    string GetRewardDescription(AdType adType);
    double GetRewardPlacementViewResetMinutes(AdType adType);
    void SubscribeToAdFinished(OnAdFinished onAdFinished);
    void UnsubscribeToAdFinished(OnAdFinished onAdFinished);
    void SubscribeToAdStarted(OnAdStarted onAdStarted);
    void UnsubscribeToAdStarted(OnAdStarted onAdStarted);
    string GetCurrentRewardDescription();
}
