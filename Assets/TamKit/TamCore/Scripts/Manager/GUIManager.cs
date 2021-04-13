/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年06月26日 17:25:12
* |     主要功能：用于UGUI等UI元素的工具
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIManager : TamManager
{
    public static GUIManager Instance { get; private set; }

    public override void Init()
    {
        Instance = this;
    }

    /// <summary>
    /// 设置InputField编辑输入框的可编辑状态
    /// </summary>
    /// <param name="inputField"></param>
    /// <param name="isNeedEdit"></param>
    public static void SetInputFieldEditStatus(InputField inputField, bool isNeedEdit)
    {
        Color color = inputField.GetComponent<Image>().color;
        color.a = isNeedEdit ? 1 : 0;
        inputField.GetComponent<Image>().color = color;
        inputField.GetComponent<Image>().raycastTarget = isNeedEdit;
        if (isNeedEdit)
        {
            inputField.interactable = isNeedEdit;
        }
    }

    /// <summary>
    /// 光标默认聚焦在InputField
    /// </summary>
    /// <param name="inputField"></param>
    public static void SetInputFieldFocus(InputField inputField, bool FirstFunc = true)
    {
        if (FirstFunc)
        {
            //方法1
            inputField.ActivateInputField();
        }
        else
        {
            //方法2
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        }
    }


    public static void SetButtonOnClick(Button button, UnityAction click)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(click);
    }
}
