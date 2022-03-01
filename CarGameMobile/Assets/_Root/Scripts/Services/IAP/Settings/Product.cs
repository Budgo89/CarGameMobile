using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Services.IAP.Settings
{
    [Serializable]
    internal struct Product
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public ProductType ProductType { get; private set; }
    }
}
