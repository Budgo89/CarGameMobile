using Features.Inventory;
using Features.Inventory.Items;
using Ui;
using Game;
using Profile;
using UnityEngine;
using Features.Shed;
using Features.Shed.Upgrade;
using Tool;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private GameController _gameController;
    private InventoryController _inventoryController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        DisposeControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        DisposeControllers();
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                CreateShedController();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                break;
        }
    }

    private void CreateShedController()
    {
        var view = LoadShedView(_placeForUi);
        var repository = CreateHandlersRepository();
        _inventoryController = CreateInventoryController(_placeForUi);
        _shedController = new ShedController(view, repository, _profilePlayer);
    }

    private void DisposeControllers()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _inventoryController?.Dispose();
        _gameController?.Dispose();
        
    }

    private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Shed/ShedView");
    private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");
    private readonly ResourcePath _viewInventoryPath = new ResourcePath("Prefabs/Inventory/InventoryView");
    private readonly ResourcePath _dataInventorySourcePath = new ResourcePath("Configs/Inventory/ItemConfigDataSource");
    private IUpgradeHandlersRepository CreateHandlersRepository()
    {
        UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
        var repository = new UpgradeHandlersRepository(upgradeConfigs);
        AddRepository(repository);

        return repository;
    }

    private IShedView LoadShedView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<ShedView>();
    }

    private InventoryController CreateInventoryController(Transform placeForUi)
    {
        var view = LoadInventoryView(placeForUi);
        var repository = CreateInventoryRepository();
        var inventoryController = new InventoryController(view, repository, _profilePlayer.Inventory);
        AddController(inventoryController);

        return inventoryController;
    }

    private IItemsRepository CreateInventoryRepository()
    {
        ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(_dataInventorySourcePath);
        var repository = new ItemsRepository(itemConfigs);
        AddRepository(repository);

        return repository;
    }

    private IInventoryView LoadInventoryView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_viewInventoryPath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi);
        AddGameObject(objectView);

        return objectView.GetComponent<InventoryView>();
    }
}
