using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Assets._Root.Scripts.Services.Ads
{
    internal class UnityAdsTools : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsListener
    {
        public event Action Initialized;
        public bool IsInitialized { get; private set; }

        private string _gameId = "4634703";
        private string _rewardedId = "Rewarded_Android";
        private string _interstitialId = "Interstitial_Android";
        private string _bannerId = "Banner_Android";

        private Action _callbackSuccessShowVideo;

        private void Start() => Advertisement.Initialize(_gameId, true);

        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Load(_interstitialId);
            Advertisement.Show(_interstitialId);
        }

        public void ShowRewarded(/*Action successShow*/)
        {
            //_callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardedId);
        }

        public void ShowBanner()
        {
            Advertisement.Show(_bannerId);
        }
        public void OnInitializationComplete()
        {
            IsInitialized = true;
            Initialized?.Invoke();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {

        }
        public void OnUnityAdsReady(string placementId){}
        public void OnUnityAdsDidError(string message){}
        public void OnUnityAdsDidStart(string placementId){}

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
            {
                _callbackSuccessShowVideo?.Invoke();
            }
        }
    }
}
