using UnityEngine;
using ЕwinAnimations;

namespace Profile
{
    [CreateAssetMenu(fileName = nameof(InventoryAnimationConfigurations), menuName = "Configs/" + nameof(InventoryAnimationConfigurations))]
    internal class InventoryAnimationConfigurations : ScriptableObject
    {
        [field: SerializeField] public static AnimationButtonType AnimationButtonType = AnimationButtonType.PunchPosition;
        [field: SerializeField] public static float Elasticity = 0.01f;
        [field: SerializeField] public static float Duration = 0.1f;
        [field: SerializeField] public static int Vibrato = 1;
    }
}
