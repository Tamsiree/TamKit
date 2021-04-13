/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年06月28日 23:09:08
* |     主要功能：UI因屏幕适配自适应而改变了大小，使得 BoxCollider2D 跟随与之大小自适应
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider2DAdjust : MonoBehaviour
{
    public bool isAutoAdjust = false;
    private BoxCollider2D boxCollider2D;
    private RectTransform gameObjectRect;

    // Use this for initialization
    void Start()
    {
        gameObjectRect = GetComponent<RectTransform>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D != null)
        {
            if (isAutoAdjust == true)
            {
                //把 BoxCollider2D 组件的偏移 设置到物体的中心
                boxCollider2D.offset = gameObjectRect.rect.center;
                //改变 BoxCollider2D 大小
                boxCollider2D.size = new Vector2(gameObjectRect.rect.width, gameObjectRect.rect.height);
            }
        }
        else
        {
            Debug.LogError("Can't find any BoxCollider2D");
        }
    }

}
