using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Services.Ads.Settings
{
    [Serializable]
    internal class AdsPlayerSettings
    {
        [field: SerializeField] public bool Enabled { get; private set; }
        [SerializeField] private string _androidId;
        [SerializeField] private string _iosId;

        public string Id =>
#if UNITY_EDITOR
            _androidId;
#else
            Application.platform switch
            {
                RuntimePlatform.Android => _androidId,
                RuntimePlatform.IPhonePlayer => _iosId,
                _ => ""
            };
#endif
    }
}
