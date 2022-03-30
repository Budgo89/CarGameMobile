using UnityEngine;
using ЕwinAnimations;

namespace Profile
{
    [CreateAssetMenu(fileName = nameof(InventoryAnimationConfigurations), menuName = "Configs/" + nameof(InventoryAnimationConfigurations))]
    internal class InventoryAnimationConfigurations : ScriptableObject
    {
        [field: SerializeField] public AnimationButtonType AnimationButtonType = AnimationButtonType.PunchPosition;
        [field: SerializeField] public float Elasticity = 0.01f;
        [field: SerializeField] public float Duration = 0.1f;
        [field: SerializeField] public int Vibrato = 1;
    }
}
