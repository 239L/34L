using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.Localization
{
    public class LocData
    {
        [SerializeField]
        List<LocItem> items;
        public List<LocItem> LocItems
        {
            get { return items; }
        }
        [System.Serializable]
        public class LocItem
        {
            public string key;
            public string value;
        }
    }
}