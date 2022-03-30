using DG.Tweening;
using Profile;
using UnityEngine;

namespace ЕwinAnimations
{
    internal class ButtonByComposition
    {

        private RectTransform _rectTransform;
        
        private readonly AnimationButtonType _animationButtonType;
        private readonly float _elasticity;
        private readonly float _duration;
        private readonly int _vibrato;

        private readonly Vector3 _direction;

        internal ButtonByComposition(RectTransform rectTransform, InventoryAnimationConfigurations inventoryAnimationConfigurations)
        {
            _rectTransform = rectTransform;
            _animationButtonType = inventoryAnimationConfigurations.AnimationButtonType;
            _elasticity = inventoryAnimationConfigurations.Elasticity;
            _duration = inventoryAnimationConfigurations.Duration;
            _vibrato = inventoryAnimationConfigurations.Vibrato;
            _direction = _rectTransform.position;
        }

        public void ActivateAnimation()
        {
            
            switch (_animationButtonType)
            {
                case AnimationButtonType.PunchPosition:
                    _rectTransform.DOPunchPosition(_direction, _duration, _vibrato, _elasticity);
                    break;
            }
        }

    }
}
