using Game;
using Profile;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(ConfigMain), menuName = "Configs/" + nameof(ConfigMain))]
    public class ConfigMain : ScriptableObject
    {
        [field: SerializeField] public float SpeedCar { get; private set; } = 15f;
        [field: SerializeField] public float JumpCar { get; private set; } = 20f;
        [field: SerializeField] public GameState InitialState { get; private set; } = GameState.Start;
        [field: SerializeField] public TransportType TransportType { get; private set; } = TransportType.Car;
    }
}