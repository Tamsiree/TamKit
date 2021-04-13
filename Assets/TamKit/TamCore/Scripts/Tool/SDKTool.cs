/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 17:14:16
* |     主要功能：SDK工具
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKTool
{
    #region --------------SDK相关
    static bool isInitSDK = false;
    static void InitSDK()
    {

        isInitSDK = true;
    }
    public static void DoShare(Action successCall, Action failCall)
    {
        if (!isInitSDK)
        {
            InitSDK();
        }

    }
    public static void DoWatchADS(Action successCall = null, Action failCall = null)
    {
        if (!isInitSDK)
        {
            InitSDK();
        }

    }
    #endregion
}
