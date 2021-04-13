/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年07月16日 16:36:09
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using AssetBundleBrowser;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TamMenu
{

    [MenuItem("TamKit/AssetBundle Browser", priority = 1)]
    public static void AssetBundleBrowser()
    {
        AssetBundleBrowserMain.ShowWindow();
    }

    [MenuItem("TamKit/Settings", priority = 200)]
    public static void Settings()
    {
        Debug.Log("TamKit/Settings");
    }


}
