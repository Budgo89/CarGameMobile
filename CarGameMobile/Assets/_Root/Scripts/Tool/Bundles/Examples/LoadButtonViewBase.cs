using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Tool.Bundles.Examples
{
    internal class LoadButtonViewBase : MonoBehaviour
    {
        //private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1rQzWdcChHhJJBTe4rf1D0Kwi1a43jxWR";
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=15CiRd0LP1X65iidPEUtFXQHFBqX3-8-B";
        [SerializeField] private DataSpriteBundle _dataSpriteBundles;

        private AssetBundle _spritesAssetBundle;

        protected IEnumerator DownloadAndSetAssetBundles()
        {
            yield return GetSpritesAssetBundle();

            if (_spritesAssetBundle != null)
                SetSpriteAssets(_spritesAssetBundle);
            else
                Debug.LogError($"AssetBundle {nameof(_spritesAssetBundle)} failed to load");
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _spritesAssetBundle);
        }

        private void StateRequest(UnityWebRequest request, out AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete");
            }
            else
            {
                assetBundle = null;
                Debug.LogError(request.error);
            }
        }

        private void SetSpriteAssets(AssetBundle assetBundle)
        {
                _dataSpriteBundles.Image.sprite = assetBundle.LoadAsset<Sprite>(_dataSpriteBundles.NameAssetBundle);
        }
    }
}