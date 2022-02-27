using Assets._Root.Scripts.Services.Ads;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
       
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly UnityAdsTools _unityAdsTools;

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, UnityAdsTools unityAdsTools)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            _view.InitSettings(SettingsGame);
            _unityAdsTools = unityAdsTools;
            _unityAdsTools.Initialized += _unityAdsTools.ShowInterstitial;
            _view.InitAdvertising(Advertising);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;
        

        private void SettingsGame() => _profilePlayer.CurrentState.Value = GameState.Settings;
        private void Advertising() => _unityAdsTools.ShowRewarded();
    }
}
