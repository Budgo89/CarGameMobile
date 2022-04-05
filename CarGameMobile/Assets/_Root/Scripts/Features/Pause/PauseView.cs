using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Features.Pause
{
    internal class PauseView : MonoBehaviour
    {
        [SerializeField] private Button _buttonMenu;
        [SerializeField] private Button _buttonBack;

        public void Init(UnityAction menu, UnityAction back)
        {
            _buttonMenu.onClick.AddListener(menu);
            _buttonBack.onClick.AddListener(back);
        }

        private void OnDestroy()
        {
            _buttonMenu.onClick.RemoveAllListeners();
            _buttonBack.onClick.RemoveAllListeners();
        }
    }
}
