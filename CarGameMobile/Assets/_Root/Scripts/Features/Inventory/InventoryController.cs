using System;
using JetBrains.Annotations;
using Features.Inventory.Items;
using UnityEngine;
using �winAnimations;

namespace Features.Inventory
{
    internal interface IInventoryController
    {
    }

    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryView _view;
        private readonly IInventoryModel _model;
        private readonly IItemsRepository _repository;
        private ButtonByComposition _buttonByComposition;

        public InventoryController(
            [NotNull] IInventoryView inventoryView,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository)
        {
            _view
                = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

            _model
                = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _repository
                = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));

            _view.Display(_repository.Items.Values, OnItemClicked);

            //_buttonByComposition = new ButtonByComposition(inventoryView.GetRectTransform());

            foreach (string itemId in _model.EquippedItems)
                _view.Select(itemId);
        }

        protected override void OnDispose()
        {
            _view.Clear();
            base.OnDispose();
        }


        private void OnItemClicked(string itemId)
        {
            bool equipped = _model.IsEquipped(itemId);

            if (equipped)
                UnequipItem(itemId);
            else
                EquipItem(itemId);
        }

        private void EquipItem(string itemId)
        {
            _view.Select(itemId);
            _model.EquipItem(itemId);
            Plays(itemId);
        }

        private void UnequipItem(string itemId)
        {
            _view.Unselect(itemId);
            _model.UnequipItem(itemId);
            Plays(itemId);
        }

        private void Plays(string itemId)
        {
            var itemView = _view.GetItemView(itemId);
            _buttonByComposition = new ButtonByComposition(itemView.GetComponent<RectTransform>());
            _buttonByComposition.ActivateAnimation();
        }
    }
}
