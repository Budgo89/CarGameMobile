using Profile;
using Features.Pause;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

internal class PauseController : BaseController
{
    private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Pause/PauseMenu");

    private readonly PauseView _view;
    private readonly ProfilePlayer _profilePlayer;

    public PauseController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _view = LoadView(placeForUi);
        _view.Init(ReturnToMenu, Back);
    }

    private void Back()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private void ReturnToMenu()
    {
        _profilePlayer.CurrentState.Value = GameState.Start;
    }

    private PauseView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<PauseView>();
    }
}