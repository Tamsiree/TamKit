/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年09月03日 17:36:14
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static readonly object _lock = new object();
    public static T Instance
    {
        get
        {
            //线程锁
            lock (_lock)
            {
                //场景中找 没有的话在创建
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    //如果没有就创建一个
                    GameObject singletonGo = new GameObject("Singleton_" + typeof(T).Name);
                    _instance = singletonGo.AddComponent<T>();
                    //DontDestroyOnLoad(singletonGo);
                }
                return _instance;
            }

        }
    }
}


