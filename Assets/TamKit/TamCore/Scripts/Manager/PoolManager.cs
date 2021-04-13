/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年06月26日 17:25:24
* |     主要功能：对象池管理者
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : TamManager
{
    public static PoolManager Instance { get; private set; }

    public override void Init()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
