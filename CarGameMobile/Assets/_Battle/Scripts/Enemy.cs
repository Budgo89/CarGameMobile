using UnityEditorInternal;
using UnityEngine;

namespace BattleScripts
{
    internal interface IEnemy
    {
        void Update(DataPlayer dataPlayer);
    }

    internal class Enemy : IEnemy
    {
        private const float KMoney = 5f;
        private const float KPower = 1.5f;
        private const float MaxHealthPlayer = 20;

        private readonly string _name;

        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        public enum —omplexity
        {
            Light,
            Average,
            Complex
        }

        public Enemy(string name) =>
            _name = name;


        public void Update(DataPlayer dataPlayer)
        {
            switch (dataPlayer.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = dataPlayer.Value;
                    break;

                case DataType.Health:
                    _healthPlayer = dataPlayer.Value;
                    break;

                case DataType.Power:
                    _powerPlayer = dataPlayer.Value;
                    break;
            }

            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }

        public int CalcPower()
        {
            int kHealth = CalcKHealth();
            float moneyRatio = _moneyPlayer / KMoney;
            float powerRatio = _powerPlayer / KPower;
            float complexity = Get—omplexity(—omplexity.Average);
            return (int)(moneyRatio + kHealth + powerRatio * complexity);
        }

        private int CalcKHealth() =>
            _healthPlayer > MaxHealthPlayer ? 100 : 5;

        private float Get—omplexity(—omplexity complexity)
        {
            float _complexity; 
            switch (complexity)
            {
                case —omplexity.Light:
                    _complexity = 0.5f;
                    break;
                case —omplexity.Average:
                    _complexity = 1f;
                    break;
                case —omplexity.Complex:
                    _complexity = 2f;
                    break;
                default:
                    _complexity = 1f;
                    break;
            }

            return _complexity;
        }
    }
}

