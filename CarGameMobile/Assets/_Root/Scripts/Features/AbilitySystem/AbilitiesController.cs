using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Features.AbilitySystem.Abilities;

namespace Features.AbilitySystem
{
    internal interface IAbilitiesController
    { }

    internal class AbilitiesController : BaseController
    {
        private readonly IAbilitiesView _view;
        private readonly IAbilitiesRepository _repository;
        private readonly IAbilityActivator _abilityActivator;


        public AbilitiesController(
            [NotNull] IAbilitiesView view,
            [NotNull] IAbilitiesRepository repository,
            [NotNull] IAbilityActivator abilityActivator,
            [NotNull] IReadOnlyList<IAbilityItem> abilityItemConfigs)
        {

            _view = view ?? throw new ArgumentNullException(nameof(view));

            _repository = repository ?? throw new AggregateException(nameof(repository));

            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));

            if (abilityItemConfigs == null)
                throw new ArgumentNullException(nameof(abilityItemConfigs));

            _view.Display(abilityItemConfigs, OnAbilityViewClicked);
        }

        private void OnAbilityViewClicked(string abilityId)
        {
            if (_repository.Items.TryGetValue(abilityId, out IAbility ability))
                ability.Apply(_abilityActivator);
        }
    }
}
