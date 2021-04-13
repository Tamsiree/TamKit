/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 18:31:55
* |     主要功能：Addressable工具
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class AddressableKit : TamSingleton<AddressableKit>
{

    public static void InstantiateAsync(string addressabelPath, Action<AsyncOperationHandle<GameObject>> InstantiateDoneAction)
    {
        Addressables.InstantiateAsync(addressabelPath).Completed += InstantiateDoneAction;
    }

    /// <summary>
    /// Addressable 加载资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="key"></param>
    /// <param name="run"></param>
    public void LoadObjRun<T>(string key, LoadObj<T> run = null)
    {
        Addressables.LoadAssetAsync<T>(key).Completed += (obj) =>
        {
            run?.Invoke(obj.Result);
            Addressables.Release(obj);
        };
    }

    /// <summary>
    /// 返回操作句柄,自己控制(PercentComplete:完成百分比)
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public AsyncOperationHandle LoadSceneRun(string key)
    {
        return Addressables.LoadSceneAsync(key);
    }

    /// <summary>
    /// Addressable 加载场景
    /// </summary>
    /// <param name="key"></param>
    /// <param name="run"></param>
    public void LoadSceneRun(string key, LoadObj<Scene> run = null)
    {
        Addressables.LoadSceneAsync(key).Completed += (obj) =>
        {
            run?.Invoke(obj.Result.Scene);
            Addressables.Release(obj);
        };
    }


    public delegate void LoadObj<T>(T obj);



}

public static class KUOZ
{
    /// <summary>
    /// 销毁释放Addressable实例化的游戏对象
    /// </summary>
    /// <param name="obj"></param>

    public static void ReleaseInstance(this GameObject obj)
    {
        Addressables.ReleaseInstance(obj);
    }

}