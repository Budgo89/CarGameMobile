using Profile;
using Tool;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Ui.LanguageMenu
{
    internal class LanguageMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Ui/LanguageMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly LanguageMenuView _view;


        public LanguageMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(Back, English, Russian);
        }

        private void Russian()
        {
            ChangeLanguage(1);
        }

        private void English()
        {
            ChangeLanguage(0);
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Settings;
        }

        private LanguageMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<LanguageMenuView>();
        }

        private void ChangeLanguage(int index) =>
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

    }

}
