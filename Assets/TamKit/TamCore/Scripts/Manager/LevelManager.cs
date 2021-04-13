/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年06月26日 17:24:40
* |     主要功能：关卡管理者
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : TamSingleton<LevelManager>
{
    private LevelManager()
    {
        // to do ...
    }


    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

}
