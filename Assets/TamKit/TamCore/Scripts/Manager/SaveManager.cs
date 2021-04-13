/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年06月26日 17:25:36
* |     主要功能：保存加载管理者
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : TamSingletonMono<GameManager>
{
    public bool IsPause { get; private set; }

    public void GamePause()
    {
        if (IsPause)
        {
            Time.timeScale = 1;
            IsPause = !IsPause;
        }
        else
        {
            Time.timeScale = 0;
            IsPause = !IsPause;
        }
    }

}
