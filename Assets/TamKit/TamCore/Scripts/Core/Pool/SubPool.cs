/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月28日 15:12:03
* |     主要功能：对象池 子池
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool
{
    Transform canvasTra;

    //预设
    Object m_prefab;

    //集合
    List<Object> m_objects = new List<Object>();

    //名字构造
    public string Name
    {
        get { return m_prefab.name; }
    }

    //构造
    public SubPool(Object prefab)
    {
        this.m_prefab = prefab;
    }

    //取对象
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate(m_prefab) as GameObject;
            m_objects.Add(go);
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return go;
    }

    //取UI对象
    public GameObject SpawnUI()
    {
        GameObject go = null;
        if (canvasTra == null)
        {
            canvasTra = GameObject.Find("Canvas").transform;
        }
        foreach (GameObject obj in m_objects)
        {
            if (obj == null)
            {
                Debug.LogWarning("Object pool " + Name + " contains null game object!");

                continue;
            }
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate(m_prefab, canvasTra) as GameObject;
            m_objects.Add(go);

            //TODO:移除池空對象
            RemoveNullObjects();
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return go;
    }

    void RemoveNullObjects()
    {
        List<Object> temp = new List<Object>();
        foreach (GameObject obj in m_objects)
        {
            if (obj != null)
            {
                temp.Add(obj);
                continue;
            }
        }

        m_objects = temp;
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        if (Contains(go))
        {
            go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    //回收该池子所有对象
    public void UnspawnAll()
    {
        try
        {
            foreach (GameObject obj in m_objects)
            {
                if (obj == null)
                {
                    continue;
                }
                if (obj.activeSelf)
                {
                    Unspawn(obj);
                }
            }

        }
        catch
        {
            Debug.LogWarning("Object pool " + Name + " contains null game object!");
            ClearAll();
        }

    }

    //全部移除
    public void ClearAll()
    {
        foreach (GameObject obj in m_objects)
        {
            if (obj != null)
            {
                GameObject.Destroy(obj);
            }
        }
        m_objects.Clear();
    }

    //是否包含对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }
}
