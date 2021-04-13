/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月28日 15:12:03
* |     主要功能：对象池
* |     详细描述：
* |     版本：1.0
* ========================================================*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : TamSingleton<ObjectPool>
{

    public string ResourceDir = "Prefabs";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();
    
    //取对象

    public GameObject Spawn(string path, string name)
    {
        if (!m_pools.ContainsKey(name))
            RegisterNew(path, name);
        SubPool pool = m_pools[name];
        return pool.Spawn();
    }

    public GameObject SpawnUIObj(string path, string name){
        if (!m_pools.ContainsKey(name))
            RegisterUIObj(path, name);
        SubPool pool = m_pools[name];
        return pool.SpawnUI();
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;
        foreach(SubPool p in m_pools.Values)
        {
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }
        pool.Unspawn(go);
    }

    //回收指定子池子内所以对象
    public void UnspawnAllInSubPool(string name)
    {
        SubPool pool = null;
        foreach (SubPool p in m_pools.Values)
        {
            if (p.Name == name)
            {
                pool = p;
                break;
            }
        }
        if(pool != null)
            pool.UnspawnAll();
        
    }

    //清除指定子池子内所以对象
    public void ClearAllInSubPool(string name)
    {
        SubPool pool = null;
        foreach (SubPool p in m_pools.Values)
        {
            if (p.Name == name)
            {
                pool = p;
                break;
            }
        }
        if (pool == null){
            return;
        }
        
        pool.ClearAll();
        m_pools.Remove(name);
    }

    //回收所以对象
    public void UnspawnAll()
    {
        foreach (SubPool p in m_pools.Values)
            p.UnspawnAll();
    }

    //创建新子池子
    public void RegisterNew(string p ,string name)
    {
        //预设路径
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir))
            path = name;
        else
            path = ResourceDir + p + "/" + name;

        //加载预设
        Object prefab = Resources.Load<Object>(path);

        //创建子对象池
        SubPool pool = new SubPool(prefab);
        m_pools.Add(pool.Name, pool);

    }

    void RegisterUIObj(string p, string name){
        //预设路径
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir))
            path = name;
        else
            path = ResourceDir + p + "/" + name;

        //加载预设
        GameObject prefab = Resources.Load<GameObject>(path);

        //创建子对象池
        SubPool pool = new SubPool(prefab);
        m_pools.Add(pool.Name, pool);
    }

}
