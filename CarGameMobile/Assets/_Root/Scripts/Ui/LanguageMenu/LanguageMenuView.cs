using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui.LanguageMenu
{
    internal class LanguageMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonEnglish;
        [SerializeField] private Button _buttonRussian;


        public void Init(UnityAction back, UnityAction english, UnityAction russian)
        {
            _buttonBack.onClick.AddListener(back);
            _buttonEnglish.onClick.AddListener(english);
            _buttonRussian.onClick.AddListener(russian);
        }

        public void OnDestroy()
        {
            _buttonBack.onClick.RemoveAllListeners();
            _buttonEnglish.onClick.RemoveAllListeners();
            _buttonRussian.onClick.RemoveAllListeners();
        }


    }
}
