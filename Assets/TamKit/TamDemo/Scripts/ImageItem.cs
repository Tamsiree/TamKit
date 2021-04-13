/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 20:57:30
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageItem : RecyclerViewItem
{

    Text text;

    protected override void InitView()
    {
        text = transform.Find("Text").GetComponent<Text>();
    }

    protected override void LoadModel(object model)
    {
        ImageItemModel imageItemModel = model as ImageItemModel;
        text.text = imageItemModel.content;
    }

}
