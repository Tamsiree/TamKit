/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 16:19:47
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 15:30:47
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections.Generic;
using TamKit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class RecyclerViewBase : MonoBehaviour
{
    /// <summary>
    /// 列表项数量
    /// </summary>
    public int itemCount = 100;

    public IScrollList list { get; protected set; }

    protected GameObject scrollView;

    /// <summary>
    /// 添加数据
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="addList"></param>
    protected void AddRange<TData>(IEnumerable<TData> addList)
    {
        list.AddRange(addList);
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    protected void Clear()
    {
        list.Clear();
    }

    /// <summary>
    /// 默认插入在最前面
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="data"></param>
    /// <param name="index"></param>
    protected void Insert<TData>(TData data, int index = 0)
    {
        list.Insert(index, data);
    }

    /// <summary>
    /// 移除指定Item
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="data"></param>
    protected void Remove<TData>(TData data)
    {
        list.Remove(data);
    }

    /// <summary>
    /// 移除指定下标的Item
    /// </summary>
    /// <param name="index"></param>
    protected void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    /// <summary>
    /// 滚动到指定的Item
    /// </summary>
    /// <param name="index"></param>
    protected void ScrollToItem(int index)
    {
        list.ScrollToItem(index);
    }

    /// <summary>
    /// 滚动到列表末尾
    /// </summary>
    protected void ScrollToPosition()
    {
        list.ScrollToPosition(new Vector2(0, list.ContentHeight));
    }

    void Start()
    {
#if !UNITY_EDITOR
        Application.targetFrameRate = 60;
#endif

        //InitData();
    }

    void OnEnable()
    {

    }

    public abstract void InitData<TData>(IEnumerable<TData> datas);

    /// <summary>
    /// 列表刷新
    /// </summary>
    protected void OnListRefresh()
    {

    }

    /// <summary>
    /// 列表高度改变
    /// </summary>
    protected void OnRebuildContent()
    {

    }
}
