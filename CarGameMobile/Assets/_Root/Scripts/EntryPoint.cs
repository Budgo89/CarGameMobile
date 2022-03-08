using Game;
using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float SpeedCar = 15f;
    [SerializeField] private float JumpCar = 20f;
    [SerializeField] private GameState InitialState = GameState.Start;
    [SerializeField] private TransportType TransportType = TransportType.Car;

    [Header("Attachments")]
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, JumpCar, TransportType, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
