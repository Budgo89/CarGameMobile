using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonBask;
        public void Init(UnityAction mainMenu) 
            => _buttonBask.onClick.AddListener(mainMenu);

        public void OnDestroy()
        {
            _buttonBask.onClick.RemoveAllListeners();
        }
    }
}
