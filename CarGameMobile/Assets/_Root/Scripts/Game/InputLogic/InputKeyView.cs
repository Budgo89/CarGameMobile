﻿using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputKeyView : BaseInputView
    {
        [SerializeField] private float _speed = 0.05f;


        private void Start() => UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            float axisOffset = Input.GetAxis("Horizontal");
            float moveValue = _speed * Time.deltaTime * axisOffset;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else if (sign < 0)
                OnLeftMove(abs);
        }
    }
}
