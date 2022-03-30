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

        internal ButtonByComposition(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
            _animationButtonType = InventoryAnimationConfigurations.AnimationButtonType;
            _elasticity = InventoryAnimationConfigurations.Elasticity;
            _duration = InventoryAnimationConfigurations.Duration;
            _vibrato = InventoryAnimationConfigurations.Vibrato;
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
