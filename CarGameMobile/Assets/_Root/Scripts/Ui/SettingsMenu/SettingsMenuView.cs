using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonLanguage;

        public void Init(UnityAction back, UnityAction language)
        {
            _buttonBack.onClick.AddListener(back);
            _buttonLanguage.onClick.AddListener(language);
        }


        public void OnDestroy()
        {
            _buttonBack.onClick.RemoveAllListeners();
            _buttonLanguage.onClick.RemoveAllListeners();
        }
    }
}
