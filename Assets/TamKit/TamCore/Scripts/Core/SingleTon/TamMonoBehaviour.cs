/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 16:13:08
* |     主要功能：Mono的根单例模式
* |     详细描述：整体控制 Start 和 Update 事件
* |     版本：1.0
*  ======================================================== */

using UnityEngine;

public class TamMonoBehaviour : MonoBehaviour
{
    private void Awake()
    {

    }

    private void Start()
    {
        this.OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnUpdate()
    {

    }
}
