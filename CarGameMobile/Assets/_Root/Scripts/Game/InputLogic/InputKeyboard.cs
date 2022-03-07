using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputKeyboard : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 0.01f;


        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);


        private void Move()
        {
            float moveValue = _speed * _inputMultiplier * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                OnLeftMove(moveValue);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                OnRightMove(moveValue);

            if (Input.GetKey(KeyCode.Space))
            {
                OnJump(moveValue);
            }
               
        }
    }
}
