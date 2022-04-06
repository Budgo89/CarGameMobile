using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Tool.Bundles.Examples
{
    internal class LoadButtonView : LoadButtonViewBase
    {
        [Header("Asset Bundles")]
        [SerializeField] private Button _loadAssetsButton;

        private GameObject _addressablePrefab;

        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAsset);
        }

        private void LoadAsset()
        {
            _loadAssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles());
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();

            DespawnPrefabs();
        }

        private void DespawnPrefabs()
        {
            Addressables.ReleaseInstance(_addressablePrefab);
        }
    }
}
