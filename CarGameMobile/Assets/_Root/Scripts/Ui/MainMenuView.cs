using Services.Analytics;
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

        public void Init(UnityAction startGame)
        {
            
            _buttonStart.onClick.AddListener(startGame);
        }

        public void InitSettings(UnityAction settingsGame) 
            => _buttonSettings.onClick.AddListener(settingsGame);

        public void InitAdvertising(UnityAction advertising)
            => _buttonAdvertising.onClick.AddListener(advertising);

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonAdvertising.onClick.RemoveAllListeners();
        }
    }
}
