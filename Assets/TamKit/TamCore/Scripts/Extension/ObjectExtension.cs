/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 14:41:06
* |     主要功能：扩展方法
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ObjectExtension
{
    /// <summary>
    /// 获取资源名称
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public static string GetAssetName(this string assetPath)
    {
        if (string.IsNullOrEmpty(assetPath))
        {
            UnityEngine.Debug.LogError("GetAssetName()-->the asset path is empty!");
            return string.Empty;
        }
        var index1 = assetPath.LastIndexOf('/');
        var index2 = assetPath.LastIndexOf('.');
        return assetPath.Substring(index1 + 1, index2 - index1 - 1);
    }

#if UNITY_EDITOR
    /// <summary>
    /// 查找资源
    /// </summary>
    /// <param name="folders"></param>
    /// <param name="filter"></param>
    /// <param name="exincludeName"></param>
    /// <returns></returns>
    public static string[] FindAssets(string[] folders, string filter, string exincludeName)
    {
        List<string> list = new List<string>();
        var assets = AssetDatabase.FindAssets(filter, folders);
        foreach (var guid in assets)
        {
            list.Add(AssetDatabase.GUIDToAssetPath(guid).ToLower());
        }
        string[] exinclude = null;
        if (!string.IsNullOrEmpty(exincludeName))
        {
            exinclude = exincludeName.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }
        if (exinclude != null && exinclude.Length > 0)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                string assetPath = list[i];
                for (int j = 0; j < exinclude.Length; j++)
                {
                    if (assetPath.Contains(exinclude[j]))
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        return list.ToArray();
    }
#endif
}