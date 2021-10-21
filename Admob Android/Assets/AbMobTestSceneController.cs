using UnityEngine;

public class AbMobTestSceneController : MonoBehaviour
{
    private bool bannerShown = false;

    public void FlipBanner()
    {
        if (bannerShown)
        {
            GameManager.gameManager.GetAdController().HideBanner();
            this.bannerShown = false;
        }
        else
        {
            GameManager.gameManager.GetAdController().ShowBanner(Enumerations.GenericBannerPosition.Bottom);
            this.bannerShown = true;
        }
    }

    public void PlayInterstatial()
    {
        GameManager.gameManager.GetAdController().PlayAd(Enumerations.AdType.InterstatialAd);
    }

    public void PlayRewardedAd()
    {
        GameManager.gameManager.GetAdController().PlayAd(Enumerations.AdType.ClaimAp_1);
    }
}
