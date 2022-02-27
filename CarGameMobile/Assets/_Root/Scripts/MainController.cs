using Assets._Root.Scripts.Services.Ads;
using Ui;
using Game;
using Profile;
using Services.Analytics;
using Services.IAP;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsMenuController;
    private AnalyticsManager _analytics;
    private UnityAdsTools _unityAdsTools;
    private IAPService _iapService;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, AnalyticsManager analytics, 
        UnityAdsTools unityAdsTools, IAPService iapService)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _analytics = analytics;
        _unityAdsTools = unityAdsTools;
        _iapService = iapService;
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _unityAdsTools, _iapService);
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _analytics.SendGameStart();
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
        }
    }
}
