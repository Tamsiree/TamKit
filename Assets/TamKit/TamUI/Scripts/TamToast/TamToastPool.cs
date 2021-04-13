/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年09月03日 17:07:45
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Collections.Generic;
using UnityEngine;


//*****************************自定义对象池类型 可单独创建一个脚本**************************************************************//
public enum PoolType
{
    DEFAULT,
    TEST1,
    TEST2,
    TEXTTIP
}
public class TamToastPool : SingletonMono<TamToastPool>
{
    //所有池子的字典
    private Dictionary<PoolType, Queue<GameObject>> _poolDic = new Dictionary<PoolType, Queue<GameObject>>();
    //所有池子类型节点
    private Dictionary<PoolType, Transform> _pathDic = new Dictionary<PoolType, Transform>();
    //池子容量不够用时候默认扩充数量
    private int _expansion = 5;
    //把所有池子归到统一节点下
    private Transform _poolTotal;
    //是否统一管理池子节点
    private bool _unifiedMgr = true;


    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="poolType">对象池类型</param>
    /// <param name="gameObject">Obj</param>
    /// <param name="cont">初始化大小</param>
    public void InitPool(PoolType poolType, GameObject prefab, int count = 20)
    {
        //创建个MgrPool节点 把所有池子都归到这个节点下 方便管理
        if (_poolTotal == null) _poolTotal = new GameObject("TamToastPool").transform;

        if (!_poolDic.ContainsKey(poolType))
        {
            if (_unifiedMgr)
            {
                //如果是新池子 创建一个节点
                Transform parent = new GameObject("Pool_" + poolType.ToString()).transform;
                parent.SetParent(_poolTotal);
                _pathDic.Add(poolType, parent);
            }
            _poolDic.Add(poolType, new Queue<GameObject>());
            CreatorItem(poolType, prefab, count);
        }
        else
        {
            //throw new Exception(string.Format("该池子：'{0}'已存在，请勿重复初始化！", poolType));
        }
    }

    /// <summary>
    /// 从池子里取出
    /// </summary>
    /// <param name="poolType">池子类型</param>
    /// <returns></returns>
    public GameObject Get(PoolType poolType)
    {
        if (_poolDic.ContainsKey(poolType) && _poolDic[poolType].Count > 0)
        {
            Queue<GameObject> goQueue = _poolDic[poolType];
            GameObject prefab = null;
            //这里留一个扩充池子用
            if (goQueue.Count > 1)
            {
                prefab = goQueue.Dequeue();
                prefab.SetActive(true);
            }
            //这里如果池子空间只剩下一个 就扩容池子
            if (prefab == null && goQueue.Count <= 1)
            {
                CreatorItem(poolType, goQueue.Peek(), _expansion);
                return Get(poolType);
            }
            return prefab;
        }
        else
        {
            throw new Exception(string.Format("该池子：'{0}'不存在或已被清理，请先初始化！", poolType));
        }
    }

    public void Put(PoolType poolType, GameObject prefab)
    {
        if (!_poolDic.ContainsKey(poolType))
        {
            if (prefab != null) GameObject.Destroy(prefab);
            //throw new Exception(string.Format("该池子：'{0}'不存在或已被清理，请先初始化！", poolType));
            Debug.LogWarning("该池子：'" + poolType + "'不存在或已被清理，请先初始化！");
        }
        else
        {
            if (_unifiedMgr)
            {
                prefab.transform.SetParent(_pathDic[poolType]);
            }
            prefab.SetActive(false);
            _poolDic[poolType].Enqueue(prefab);
        }
    }

    /// <summary>
    /// 创建池子预制
    /// </summary>
    /// <param name="poolType">池子类型</param>
    /// <param name="go">预制</param>
    /// <param name="count">多少个</param>
    private void CreatorItem(PoolType poolType, GameObject go, int count)
    {
        if (!_poolDic.ContainsKey(poolType))
        {
            throw new Exception(string.Format("该池子：'{0}'不存在或已被清理，请先初始化！", poolType));
        }
        for (int i = 0; i < count; i++)
        {
            GameObject goItem = GameObject.Instantiate(go);
            goItem.transform.SetParent(_unifiedMgr ? _pathDic[poolType] : _poolTotal);
            goItem.name = go.name;
            goItem.SetActive(false);
            _poolDic[poolType].Enqueue(goItem);
        }
    }

    /// <summary>
    /// 清理池子
    /// </summary>
    /// <param name="poolType">池子类型</param>
    public void Clear(PoolType poolType)
    {
        if (!_poolDic.ContainsKey(poolType))
        {
            throw new Exception(string.Format("该池子：'{0}'不存在或已被清理，请先初始化！", poolType));
        }
        else
        {
            if (_unifiedMgr)
            {
                GameObject.Destroy(_pathDic[poolType].gameObject);
                _pathDic.Remove(poolType);
            }
            else
            {
                foreach (GameObject poolItem in _poolDic[poolType])
                {
                    GameObject.Destroy(poolItem);
                }
            }
            _poolDic[poolType].Clear();
            _poolDic.Remove(poolType);

        }

    }
    /// <summary>
    /// 清理所有池子
    /// </summary>
    public void ClaerAll()
    {
        if (_unifiedMgr)
        {
            if (_poolTotal != null) GameObject.Destroy(_poolTotal.gameObject);
            _pathDic.Clear();
        }
        else
        {
            foreach (Queue<GameObject> queue in _poolDic.Values)
            {
                foreach (GameObject go in queue)
                {
                    GameObject.Destroy(go);
                }
            }
        }
        _poolDic.Clear();
    }
}

