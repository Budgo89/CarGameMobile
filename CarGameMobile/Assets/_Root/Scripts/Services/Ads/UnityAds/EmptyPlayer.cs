using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Ads.UnityAds;

namespace Services.Ads.UnityAds
{
    internal class EmptyPlayer : UnityAdsPlayer
    {
        public EmptyPlayer(string id) : base(id)
        { }

        protected override void OnPlaying()
        { }

        protected override void Load()
        { }
    }
}
