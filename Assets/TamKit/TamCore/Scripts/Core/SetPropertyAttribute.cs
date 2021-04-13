/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月08日 23:03:42
* |     主要功能：设置属性
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using UnityEngine;
using System.Collections;

public class SetPropertyAttribute : PropertyAttribute
{
    public string Name { get; private set; }
    public bool IsDirty { get; set; }

    public SetPropertyAttribute(string name)
    {
        this.Name = name;
    }
}
