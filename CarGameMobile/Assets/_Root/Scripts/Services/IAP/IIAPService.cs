using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services.IAP
{
    internal interface IIAPService
    {
        UnityEvent Initialized { get; }
        UnityEvent PurchaseSucceed { get; }
        UnityEvent PurchaseFailed { get; }
        bool IsInitialized { get; }

        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchases();
    }
}
