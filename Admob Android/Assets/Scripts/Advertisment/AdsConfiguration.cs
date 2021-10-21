using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using Sirenix.OdinInspector;
using Enumerations;

[CreateAssetMenu(menuName = "Ads Configuration Asset", fileName = "New Ads Configuration Asset")]
public class AdsConfiguration : SerializedScriptableObject
{
    [OdinSerialize]
    public Dictionary<string, AdType> adTypesByPlacementIds { get; private set; } = new Dictionary<string, AdType>();
    [OdinSerialize]
    public List<AdType> adsWithFakeRewards { get; private set; } = new List<AdType>();
    [OdinSerialize]
    public Dictionary<AdType, string> clientAdPlacementIds { get; private set; } = new Dictionary<AdType, string>();
    [OdinSerialize]
    public List<AdType> interstatialAds { get; private set; } = new List<AdType>();
    [OdinSerialize]
    public List<AdType> rewardedAds { get; private set; } = new List<AdType>();
}
