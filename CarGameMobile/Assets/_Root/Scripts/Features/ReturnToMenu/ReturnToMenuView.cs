using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Features.ReturnToMenu
{
    internal class ReturnToMenuView : MonoBehaviour
    {
        [SerializeField] private Button _returnButton;

        public void Init(UnityAction returnMainMenu) =>
            _returnButton.onClick.AddListener(returnMainMenu);

        private void OnDestroy() =>
            _returnButton.onClick.RemoveAllListeners();
    }
}
