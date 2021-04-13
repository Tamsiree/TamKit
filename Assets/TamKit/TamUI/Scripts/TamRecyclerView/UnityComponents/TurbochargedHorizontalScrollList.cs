using UnityEngine;
using UnityEngine.UI;

namespace TamKit
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ScrollRect))]
    public class TurbochargedHorizontalScrollList : MonoBehaviour
    {
        public GameObject itemPrefab;
        
        public HorizontalLayoutSettings layout;

        HorizontalScrollList _list;

        public HorizontalScrollList GetList()
        {
            if (null == _list)
            {
                _list = new HorizontalScrollList(GetComponent<ScrollRect>(), itemPrefab, layout);
            }
            return _list;
        }
    }
}