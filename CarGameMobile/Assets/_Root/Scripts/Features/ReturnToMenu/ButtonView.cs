using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Features.ReturnToMenu
{
    internal class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _returnButton;
        [SerializeField] private Button _pauseButton;

        public void Init(UnityAction returnMainMenu, UnityAction pause)
        {
            _returnButton.onClick.AddListener(returnMainMenu);
            _pauseButton.onClick.AddListener(pause);
        }

        private void OnDestroy()
        {
            _returnButton.onClick.RemoveAllListeners();
            _pauseButton.onClick.RemoveAllListeners();
        }
    }
}
