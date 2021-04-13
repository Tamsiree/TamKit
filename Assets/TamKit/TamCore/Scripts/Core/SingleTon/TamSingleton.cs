/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 16:13:08
* |     主要功能：单例模式
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Reflection;

public abstract class TamSingleton<T> where T : TamSingleton<T>
{
    protected static T instance = null;

    protected TamSingleton()
    {
    }

    public static T Instance()
    {
        if (instance == null)
        {
            // 先获取所有非public的构造方法
            ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            // 从ctors中获取无参的构造方法
            ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
            if (ctor == null)
                throw new Exception("Non-public ctor() not found!");
            // 调用构造方法
            instance = ctor.Invoke(null) as T;
        }

        return instance;
    }
}
