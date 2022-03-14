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
        var SpeedCar = _configMain.SpeedCar;
        var JumpCar = _configMain.JumpCar;
        var TransportType = _configMain.TransportType;
        var InitialState = _configMain.InitialState;
        var profilePlayer = new ProfilePlayer(SpeedCar, JumpCar, TransportType, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
