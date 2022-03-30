
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ЕwinAnimations
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    internal class ButtonByComposition : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;

        [Header("Settings")]
        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.PunchPosition;
        [SerializeField] private float _elasticity = 0.1f;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private int _vibrato = 2;

        private Vector3 _direction;

        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();

        private void Start() => _button.onClick.AddListener(OnButtonClick);
        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _rectTransform ??= GetComponent<RectTransform>();
            _direction = _rectTransform.position;
        }


        private void OnButtonClick() =>
            ActivateAnimation();


        [ContextMenu(nameof(ActivateAnimation))]
        private void ActivateAnimation()
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
