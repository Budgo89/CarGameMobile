using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services.Ads
{
    internal class IAdsService
    {
        IAdsPlayer InterstitialPlayer { get; }
        IAdsPlayer RewardedPlayer { get; }
        IAdsPlayer BannerPlayer { get; }
        UnityEvent Initialized { get; }
        bool IsInitialized { get; }
    }
}
