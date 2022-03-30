
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ЕwinAnimations
{
    internal class ButtonByComposition
    {

        private RectTransform _rectTransform;
        
        private AnimationButtonType _animationButtonType = AnimationButtonType.PunchPosition;
        private float _elasticity = 0.01f;
        private float _duration = 0.1f;
        private int _vibrato = 1;

        private Vector3 _direction;

        internal ButtonByComposition(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
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
