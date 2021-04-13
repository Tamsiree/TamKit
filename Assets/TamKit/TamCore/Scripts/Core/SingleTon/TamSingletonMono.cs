/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 16:14:30
* |     主要功能：Mono脚本的单例模式
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using UnityEngine;

public abstract class TamSingletonMono<T> : TamMonoBehaviour where T : TamSingletonMono<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (TamSingletonMono<T>.instance == null)
            {
                TamSingletonMono<T>.instance = Object.FindObjectOfType<T>();

                if (Object.FindObjectsOfType<T>().Length > 1)
                {
                    return TamSingletonMono<T>.instance;
                }
                if (TamSingletonMono<T>.instance == null)
                {
                    string name = typeof(T).Name;
                    GameObject gameObject = GameObject.Find(name);
                    if (gameObject == null)
                    {
                        gameObject = new GameObject(name);
                    }
                    TamSingletonMono<T>.instance = gameObject.AddComponent<T>();
                }
            }
            return TamSingletonMono<T>.instance;
        }
    }

    public void Dispose()
    {
        TamSingletonMono<T>.instance = default(T);
    }
}