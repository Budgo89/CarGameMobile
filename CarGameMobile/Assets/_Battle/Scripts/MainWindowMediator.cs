using System;
using Assets._Battle.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScripts
{
    public class MainWindowMediator : MonoBehaviour
    {
        [Header("Player Stats")]
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countCrimeText;

        [Header("Enemy Stats")]
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [Header("Money Buttons")]
        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _minusMoneyButton;

        [Header("Health Buttons")]
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [Header("Power Buttons")]
        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [Header("Crime Buttons")] 
        [SerializeField] private Button _addCrimeButton;
        [SerializeField] private Button _minusCrimeButton;

        [Header("Pass Buttons")] 
        [SerializeField] private Button _passPeacefully;
        [SerializeField] private Button _warTheFight;

        [Header("Other Buttons")]
        [SerializeField] private Button _fightButton;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _allCountCrimePlayer;

        private DataPlayer _money;
        private DataPlayer _heath;
        private DataPlayer _power;
        private DataPlayer _crime;
        private DataPlayer _crimeType;

        private Enemy _enemy;


        private void Start()
        {
            _enemy = new Enemy("Enemy Flappy");

            _money = CreateDataPlayer(DataType.Money);
            _heath = CreateDataPlayer(DataType.Health);
            _power = CreateDataPlayer(DataType.Power);
            _crime = CreateDataPlayer(DataType.Crime);
            _crimeType = CreateDataPlayer(CrimeType.War);

            Subscribe();
        }

        private void OnDestroy()
        {
            DisposeDataPlayer(ref _money);
            DisposeDataPlayer(ref _heath);
            DisposeDataPlayer(ref _power);
            DisposeDataPlayer(ref _crime);

            Unsubscribe();
        }


        private DataPlayer CreateDataPlayer(DataType dataType)
        {
            DataPlayer dataPlayer = new DataPlayer(dataType);
            dataPlayer.Attach(_enemy);

            return dataPlayer;
        }

        private DataPlayer CreateDataPlayer(CrimeType crimeType)
        {
            DataPlayer dataPlayer = new DataPlayer(crimeType);

            return dataPlayer;
        }

        private void DisposeDataPlayer(ref DataPlayer dataPlayer)
        {
            dataPlayer.Detach(_enemy);
            dataPlayer = null;
        }
        
        private void Subscribe()
        {
            _addMoneyButton.onClick.AddListener(IncreaseMoney);
            _minusMoneyButton.onClick.AddListener(DecreaseMoney);

            _addHealthButton.onClick.AddListener(IncreaseHealth);
            _minusHealthButton.onClick.AddListener(DecreaseHealth);

            _addPowerButton.onClick.AddListener(IncreasePower);
            _minusPowerButton.onClick.AddListener(DecreasePower);

            _addCrimeButton.onClick.AddListener(IncreaseCrime);
            _minusCrimeButton.onClick.AddListener(DecreaseCrime);

            _fightButton.onClick.AddListener(Fight);

            _passPeacefully.onClick.AddListener(PassPeacefully);
            _warTheFight.onClick.AddListener(JoinTheFight);
        }

        private void Unsubscribe()
        {
            _addMoneyButton.onClick.RemoveAllListeners();
            _minusMoneyButton.onClick.RemoveAllListeners();

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();

            _addCrimeButton.onClick.RemoveAllListeners();
            _minusCrimeButton.onClick.RemoveAllListeners();

            _fightButton.onClick.RemoveAllListeners();

            _passPeacefully.onClick.RemoveAllListeners();
            _warTheFight.onClick.RemoveAllListeners();
        }
        
        private void IncreaseMoney() => IncreaseValue(ref _allCountMoneyPlayer, DataType.Money);
        private void DecreaseMoney() => DecreaseValue(ref _allCountMoneyPlayer, DataType.Money);

        private void IncreaseHealth() => IncreaseValue(ref _allCountHealthPlayer, DataType.Health);
        private void DecreaseHealth() => DecreaseValue(ref _allCountHealthPlayer, DataType.Health);

        private void IncreasePower() => IncreaseValue(ref _allCountPowerPlayer, DataType.Power);
        private void DecreasePower() => DecreaseValue(ref _allCountPowerPlayer, DataType.Power);

        private void IncreaseCrime() => IncreaseValue(ref _allCountCrimePlayer, DataType.Crime);
        private void DecreaseCrime() => DecreaseValue(ref _allCountCrimePlayer, DataType.Crime);

        private void IncreaseValue(ref int value, DataType dataType) => AddToValue(ref value, 1, dataType);
        private void DecreaseValue(ref int value, DataType dataType) => AddToValue(ref value, -1, dataType);

        private void AddToValue(ref int value, int addition, DataType dataType)
        {
            value += addition;
            ChangeDataWindow(value, dataType);
        }


        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            DataPlayer dataPlayer = GetDataPlayer(dataType);
            TMP_Text textComponent = GetTextComponent(dataType);
            string text = $"Player {dataType:F} {countChangeData}";

            dataPlayer.Value = countChangeData;
            textComponent.text = text;

            int enemyPower = _enemy.CalcPower();
            _countPowerEnemyText.text = $"Enemy Power {enemyPower}";
        }

        private TMP_Text GetTextComponent(DataType dataType) =>
            dataType switch
            {
                DataType.Money => _countMoneyText,
                DataType.Health => _countHealthText,
                DataType.Power => _countPowerText,
                DataType.Crime => _countCrimeText,
                _ => throw new ArgumentException($"Wrong {nameof(DataType)}")
            };

        private DataPlayer GetDataPlayer(DataType dataType) =>
            dataType switch
            {
                DataType.Money => _money,
                DataType.Health => _heath,
                DataType.Power => _power,
                DataType.Crime => _crime,
                _ => throw new ArgumentException($"Wrong {nameof(DataType)}")
            };


        private void Fight()
        {
            int enemyPower = _enemy.CalcPower();
            bool isVictory = _allCountPowerPlayer >= enemyPower;

            string color = isVictory ? "#07FF00" : "#FF0000";
            string message = isVictory ? "Win" : "Lose";

            Debug.Log($"<color={color}>{message}!!!</color>");
        }

        private void JoinTheFight()
        {
            ChallengeToFight();
        }

        private void PassPeacefully()
        {
            if (_allCountCrimePlayer < 3)
            {
                _crimeType = CreateDataPlayer(CrimeType.Peace);
            }
            else
            {
                _crimeType = CreateDataPlayer(CrimeType.War);
            }

            if (_crimeType.CrimeType == CrimeType.Peace)
            {
                string color = "#07FF00";
                string message = "Win";

                SetActiveButton();
                _fightButton.gameObject.SetActive(false);
                Debug.Log($"<color={color}>{message}!!!</color>");
            }
            else
            {
                ChallengeToFight();
            }
        }

        private void ChallengeToFight()
        {
            string color = "#FF0000";
            string message = "War";
            
            SetActiveButton();
            Debug.Log($"<color={color}>{message}!!!</color>");
        }

        private void SetActiveButton()
        {
            _passPeacefully.gameObject.SetActive(false);
            _warTheFight.gameObject.SetActive(false);
        }
    }
}
