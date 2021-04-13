/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 15:27:12
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TamKit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TamRecyclerView : RecyclerViewBase
{

    public enum RecyclerViewType
    {
        Vertical, Horizontal, Grid
    }

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private RecyclerViewType recyclerViewType = RecyclerViewType.Vertical;

    private ScrollRect scrollRect;

    public void SetRecyclerViewType(RecyclerViewType recyclerViewType)
    {
        this.recyclerViewType = recyclerViewType;
    }

    public void SetItemPrefab(GameObject itemPrefab)
    {
        this.itemPrefab = itemPrefab;
    }

    public void SetScrollView(GameObject scrollView)
    {
        this.scrollView = scrollView;
    }

    public TamRecyclerView(GameObject scrollView, GameObject itemPrefab = null)
    {
        this.scrollView = scrollView;
        if (itemPrefab != null)
        {
            this.itemPrefab = itemPrefab;
        }
    }

    /// <summary>
    /// 初始化界面与数据
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="datas"></param>
    public override void InitData<TData>(IEnumerable<TData> datas)
    {
        if (scrollView != null)
        {
            if (itemPrefab != null)
            {
                scrollRect = scrollView.GetComponent<ScrollRect>();
                DemoManager.Instance.SendTerminalMessage("RecyclerViewType:" + recyclerViewType);
                switch (recyclerViewType)
                {
                    case RecyclerViewType.Vertical:
                        scrollRect.horizontal = false;
                        scrollRect.vertical = true;
                        VerticalLayoutSettings layoutSetting = new VerticalLayoutSettings();
                        list = new VerticalScrollList(scrollRect, itemPrefab, layoutSetting);
                        break;
                    case RecyclerViewType.Horizontal:
                        scrollRect.horizontal = true;
                        scrollRect.vertical = false;
                        HorizontalLayoutSettings horizontalSetting = new HorizontalLayoutSettings();
                        list = new HorizontalScrollList(scrollRect, itemPrefab, horizontalSetting);
                        break;
                    case RecyclerViewType.Grid:
                        scrollRect.horizontal = true;
                        scrollRect.vertical = true;
                        GridLayoutSettings layout = new GridLayoutSettings();
                        list = new GridScrollList(scrollRect, itemPrefab, layout);
                        break;
                }

                list.onRenderItem += OnItemRender;
                list.onRebuildContent += OnRebuildContent;
                list.onRefresh += OnListRefresh;
                SetData(datas);
                Debug.Log("recyclerViewType: " + recyclerViewType.ToString() + "datas.count:" + datas.Count());
            }
            else
            {
                Debug.LogError("请先设置 TamRecyclerView 的 itemPrefab ！");
            }
        }
        else
        {
            Debug.LogError("请先设置 TamRecyclerView 的 ScrollView ！");
        }
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="datas"></param>
    public void SetData<TData>(IEnumerable<TData> datas)
    {
        list.Clear();
        list.AddRange(datas);
    }

    /// <summary>
    /// 渲染Item
    /// </summary>
    /// <param name="item"></param>
    /// <param name="data"></param>
    /// <param name="isRefresh"></param>
    protected void OnItemRender(ScrollListItem item, object data, bool isRefresh)
    {
        if (isRefresh)
        {
            var listItem = item.GetComponent<RecyclerViewItem>();
            listItem.Refresh(data);
        }
    }
}