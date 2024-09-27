using Configs;
using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ConfigMain _configMain;

    [Header("Attachments")]
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Awake()
    {
        var speedCar = _configMain.SpeedCar;
        var jumpCar = _configMain.JumpCar;
        var transportType = _configMain.TransportType;
        var initialState = _configMain.InitialState;
        var profilePlayer = new ProfilePlayer(speedCar, jumpCar, transportType, initialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
