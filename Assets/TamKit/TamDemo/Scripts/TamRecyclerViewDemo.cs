/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 20:55:26
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TamRecyclerView;

public class TamRecyclerViewDemo : MonoBehaviour
{
    Transform scrollView;

    List<ImageItemModel> itemData = new List<ImageItemModel>();

    RecyclerViewType recyclerViewType = RecyclerViewType.Grid;

    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitData()
    {
        itemData.Clear();
        for (int i = 0; i < 1000; i++)
        {
            itemData.Add(new ImageItemModel("Image_" + i));
        }
    }

    /// <summary>
    /// 初始化 TamRecyclerView
    /// </summary>
    void InitTamRecyclerView()
    {
        scrollView = transform.parent.parent.parent.parent.Find("TamRecyclerView").transform;
        scrollView.gameObject.SetActive(true);
        TamRecyclerView tamRecyclerView = scrollView.GetComponent<TamRecyclerView>();
        GameObject go = Resources.Load<GameObject>("Prefab/Demo/ImagePrefab");
        tamRecyclerView.SetScrollView(scrollView.gameObject);
        tamRecyclerView.SetItemPrefab(go);
        tamRecyclerView.SetRecyclerViewType(recyclerViewType);
        tamRecyclerView.InitData(itemData);
    }

    public void ShowRecyclerView()
    {
        InitTamRecyclerView();
    }

    public void SetRecyclerViewType(RecyclerViewType recyclerViewType)
    {
        this.recyclerViewType = recyclerViewType;
    }

    public void DismissRecyclerView()
    {
        if (scrollView != null)
        {
            scrollView.gameObject.SetActive(false);
        }
    }
}
