using Assets._Root.Scripts.Services.Ads;
using Profile;
using Services.Analytics;
using Services.IAP;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;
    [SerializeField] private AnalyticsManager _analytics;
    [SerializeField] private UnityAdsTools _adsTools;
    [SerializeField] private IAPService _iapService;

    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer, _analytics, _adsTools, _iapService);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
