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

        [Header("Addressables")]
        [SerializeField] private AssetReference _setPicrureAssetReference;
        [SerializeField] private Image _image;
        [SerializeField] private Button _setPictureButton;
        [SerializeField] private Button _deletePictureButton;

        private Sprite _addressable;
        private GameObject _addressablePrefab;

        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAsset);
            _setPictureButton.onClick.AddListener(SetPicture);
            _deletePictureButton.onClick.AddListener(DeletePicture);
        }

        private void SetPicture()
        {
            _addressable =
                Addressables.LoadAssetAsync<Sprite>(_setPicrureAssetReference).Result;
            _image.sprite = _addressable;
        }

        private void DeletePicture()
        {
            _image.sprite = null;
            Addressables.Release(_addressable);
        }



        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
            _setPictureButton.onClick.RemoveAllListeners();
            _deletePictureButton.onClick.RemoveAllListeners();

            DespawnPrefabs();
        }

        private void LoadAsset()
        {
            _loadAssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles());
        }

        private void DespawnPrefabs()
        {
            Addressables.ReleaseInstance(_addressablePrefab);
        }
    }
}
