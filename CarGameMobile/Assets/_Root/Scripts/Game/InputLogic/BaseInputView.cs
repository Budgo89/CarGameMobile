using Tool;
using UnityEngine;

namespace Game.InputLogic
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        private SubscriptionProperty<float> _jump;
        protected float _speed;


        public virtual void Init(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            SubscriptionProperty<float> jump,
            float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _jump = jump;
            _speed = speed;
        }

        protected virtual void OnLeftMove(float value) =>
            _leftMove.Value = value;

        protected virtual void OnRightMove(float value) =>
            _rightMove.Value = value;

        protected virtual void OnJump(float value) =>
            _jump.Value = value;
    }
}
