using System.Collections;
using UnityEngine;

namespace Game.TapeBackground
{
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeedRate;


        public void Move(float value)
        {
            if (value != 0)
            {
                Vector3 position = transform.position;
                position += Vector3.right * value * _relativeSpeedRate;

                if (position.x <= _leftBorder)
                    position.x = _rightBorder - (_leftBorder - position.x);

                else if (position.x >= _rightBorder)
                    position.x = _leftBorder + (_rightBorder - position.x);

                transform.position = position;
            }
            else
            {
                Jump(value);
            }
        }

        private float y = 0;
        private bool jump = true;
        private float _jumpSpeed = 10f;
        private GameObject _player;
        private Rigidbody2D _rigidbody2D;
        private void Jump (float value)
        {
            if (_player == null)
            {
                _player = GameObject.Find("Car(Clone)");
                _rigidbody2D = _player.GetComponent<Rigidbody2D>();
            }
            Vector3 position = transform.position;
            if (jump)
            {
                jump = false;
                _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                StartCoroutine(JumpCoroutine());
            }

        }

        IEnumerator JumpCoroutine()
        {
            yield return new WaitForSeconds(2f);
            jump = true;
        }
    }
}
