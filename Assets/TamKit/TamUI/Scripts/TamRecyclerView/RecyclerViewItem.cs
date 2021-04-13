/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 16:54:32
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclerViewItem : MonoBehaviour
{

    private void Awake()
    {
        InitView();
    }

    protected virtual void InitView() { }

    protected virtual void LoadModel(object model) { }


    public void Refresh(object model)
    {
        LoadModel(model);
    }

    public void Refresh(float w, float h, object model)
    {
        LoadModel(model);

        var rt = GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
    }
}
