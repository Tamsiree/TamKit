/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月06日 20:28:51
* |     主要功能：保留脚本
* |     详细描述：当前场景被销毁时保留
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHolder : TamSingletonMono<GameHolder>
{
    private void Awake()
    {
        //当前场景被销毁时保留
        DontDestroyOnLoad(this);
    }
}
