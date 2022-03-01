using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonAdvertising;
        [SerializeField] private Button _buttonPurchase;

        public void Init(UnityAction startGame, UnityAction settingsGame, UnityAction advertising, UnityAction purchase)
        {
            
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(settingsGame);
            _buttonAdvertising.onClick.AddListener(advertising);
            _buttonPurchase.onClick.AddListener(purchase);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonAdvertising.onClick.RemoveAllListeners();
            _buttonPurchase.onClick.RemoveAllListeners();
        }
    }
}
