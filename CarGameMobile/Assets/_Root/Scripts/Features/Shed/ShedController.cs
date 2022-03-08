using System;
using Profile;
using System.Collections.Generic;
using UnityEngine;
using Features.Inventory;
using Features.Shed.Upgrade;
using JetBrains.Annotations;

namespace Features.Shed
{
    internal interface IShedController
    {
    }

    internal class ShedController : BaseController, IShedController
    {
        private readonly IShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly IInventoryController _inventoryController;
        private readonly IUpgradeHandlersRepository _upgradeHandlersRepository;


        public ShedController(
            [NotNull] IShedView view,
            [NotNull] IUpgradeHandlersRepository upgradeHandlersRepository,
            [NotNull] ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            _upgradeHandlersRepository = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));
            
            _view = view;

            _view.Init(Apply, Back);
        }

        private void Apply()
        {
            UpgradeWithEquippedItems(
                _profilePlayer.CurrentTransport,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Apply. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
            Log($"Apply. Current Speed: {_profilePlayer.CurrentTransport.Jump}");
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Back. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
            Log($"Apply. Current Speed: {_profilePlayer.CurrentTransport.Jump}");
        }


        private void UpgradeWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<string> equippedItems,
            IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandlers)
        {
            foreach (string itemId in equippedItems)
                if (upgradeHandlers.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
        }

        private void Log(string message) =>
            Debug.Log($"[{GetType().Name}] {message}");
    }
}
