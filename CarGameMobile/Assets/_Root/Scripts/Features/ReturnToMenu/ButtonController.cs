using Features.Fight;
using Profile;
using System;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.ReturnToMenu
{
    internal class ButtonController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Button/ReturnToMenuView");

        private readonly ReturnToMenuView _view;
        private readonly ProfilePlayer _profilePlayer;


        public ButtonController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(Return);
        }
        

        private ReturnToMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ReturnToMenuView>();
        }

        private void Return() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}
