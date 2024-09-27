using Tool;
using System;
using Profile;
using UnityEngine;
using Game.InputLogic;
using Game.TapeBackground;
using Game.Transport;
using Game.Transport.Boat;
using Game.Transport.Car;
using Features.AbilitySystem;
using Features.AbilitySystem.Abilities;

namespace Game
{
    internal class GameController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;
        private readonly SubscriptionProperty<float> _jumpMoveDiff;

        private readonly TapeBackgroundController _tapeBackgroundController;
        private readonly InputGameController _inputGameController;
        private readonly TransportController _transportController;
        private readonly AbilitiesController _abilitiesController;


        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _leftMoveDiff = new SubscriptionProperty<float>();
            _rightMoveDiff = new SubscriptionProperty<float>();
            _jumpMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = CreateTapeBackground();
            _inputGameController = CreateInputGameController();
            _transportController = CreateTransportController();
            _abilitiesController = CreateAbilitiesController(placeForUi);
        }


        private TapeBackgroundController CreateTapeBackground()
        {
            var tapeBackgroundController = new TapeBackgroundController(_leftMoveDiff, _rightMoveDiff, _jumpMoveDiff);
            AddController(tapeBackgroundController);

            return tapeBackgroundController;
        }

        private InputGameController CreateInputGameController()
        {
            var inputGameController = new InputGameController(_leftMoveDiff, _rightMoveDiff, _jumpMoveDiff, _profilePlayer.CurrentTransport);
            AddController(inputGameController);

            return inputGameController;
        }

        private TransportController CreateTransportController()
        {
            TransportController transportController =
                _profilePlayer.CurrentTransport.Type switch
                {
                    TransportType.Car => new CarController(),
                    TransportType.Boat => new BoatController(),
                    _ => throw new ArgumentException(nameof(TransportType))
                };

            AddController(transportController);

            return transportController;
        }

        private AbilitiesController CreateAbilitiesController(Transform placeForUi)
        {
            var view = LoadAbilitiesView(placeForUi);
            var abilityItemConfigs = LoadAbilityItemConfigs();
            var repository = CreateAbilitiesRepository(abilityItemConfigs);
            var abilitiesController = new AbilitiesController(view, repository, _transportController, abilityItemConfigs);
            AddController(abilitiesController);

            return abilitiesController;
        }

        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Ability/AbilitiesView");
        private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");

        private IAbilitiesRepository CreateAbilitiesRepository(AbilityItemConfig[] abilityItemConfigs)
        {
            var repository = new AbilitiesRepository(abilityItemConfigs);
            AddRepository(repository);

            return repository;
        }

        private IAbilitiesView LoadAbilitiesView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }
        private AbilityItemConfig[] LoadAbilityItemConfigs() =>
            ContentDataSourceLoader.LoadAbilityItemConfigs(_dataSourcePath);

    }
}
