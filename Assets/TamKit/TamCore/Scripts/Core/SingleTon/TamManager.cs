/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月28日 15:12:03
* |     主要功能：
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TamManager : TamSingleton<TamManager> 
{
    [SerializeField]
    private bool isAutoInit = true;

    public bool IsAutoInit { get => isAutoInit; set => isAutoInit = value; }

    public abstract void Init();

    private void Awake()
    {
        if (IsAutoInit)
        {
            Init();
        }
    }
}
