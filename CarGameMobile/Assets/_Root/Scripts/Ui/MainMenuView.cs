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
        

        public void Init(UnityAction startGame)
        {
            
            _buttonStart.onClick.AddListener(startGame);
        }

        public void InitSettings(UnityAction settingsGame) 
            => _buttonSettings.onClick.AddListener(settingsGame);

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
        }
    }
}
