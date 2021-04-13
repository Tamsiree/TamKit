/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 15:46:52
* |     主要功能：UGUI工具
* |     详细描述：简化 UGUI 部分控件的事件监听
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 简化 UGUI 部分控件的事件监听
/// </summary>
public class GUIKit
{
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

    /// <summary>
    /// 初始化 Button 点击事件
    /// </summary>
    /// <param name="buttonTransform"></param>
    /// <param name="click"></param>
    public static void InitButtonOnClick(Transform buttonTransform, UnityAction click)
    {
        Button button = buttonTransform.GetComponent<Button>();
        InitButtonOnClick(button, click);
    }

    /// <summary>
    /// 初始化 Button 点击事件
    /// </summary>
    /// <param name="button"></param>
    /// <param name="click"></param>
    public static void InitButtonOnClick(Button button, UnityAction click)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(click);
    }

    /// <summary>
    /// 初始化 InputField 编辑结束监听事件
    /// </summary>
    /// <param name="inputTransform"></param>
    /// <param name="onEditEnd"></param>
    public static void InitInputEdit(Transform inputTransform, UnityAction<string> onEditEnd)
    {
        InputField input = inputTransform.GetComponent<InputField>();
        InitInputEdit(input, onEditEnd);
    }

    /// <summary>
    /// 初始化 InputField 编辑结束监听事件
    /// </summary>
    /// <param name="input"></param>
    /// <param name="onEditEnd"></param>
    public static void InitInputEdit(InputField input, UnityAction<string> onEditEnd)
    {
        input.onEndEdit.RemoveAllListeners();
        input.onEndEdit.AddListener(onEditEnd);
    }

    /// <summary>
    /// 初始化 Dropdown 下拉数据
    /// </summary>
    /// <param name="dropdownTransform"></param>
    /// <param name="options"></param>
    public static void InitDropdownData(Transform dropdownTransform, List<string> options)
    {
        Dropdown dropdown = dropdownTransform.GetComponent<Dropdown>();
        InitDropdownData(dropdown, options);
    }

    /// <summary>
    /// 初始化 Dropdown 下拉数据
    /// </summary>
    /// <param name="dropdown"></param>
    /// <param name="options"></param>
    public static void InitDropdownData(Dropdown dropdown, List<string> options)
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    /// <summary>
    /// 初始化 Dropdown 下拉选择事件
    /// </summary>
    /// <param name="dropdownTransform"></param>
    /// <param name="dropdownEvent"></param>
    public static void InitDropdownEvent(Transform dropdownTransform, UnityAction<int> dropdownEvent)
    {
        Dropdown dropdown = dropdownTransform.GetComponent<Dropdown>();
        InitDropdownEvent(dropdown, dropdownEvent);
    }

    /// <summary>
    /// 初始化 Dropdown 下拉选择事件
    /// </summary>
    /// <param name="dropdown"></param>
    /// <param name="dropdownEvent"></param>
    public static void InitDropdownEvent(Dropdown dropdown, UnityAction<int> dropdownEvent)
    {
        dropdown.onValueChanged.RemoveAllListeners();
        dropdown.onValueChanged.AddListener(dropdownEvent);
    }

    /// <summary>
    /// 初始化 TMP_Dropdown 下拉数据
    /// </summary>
    /// <param name="dropdownTransform"></param>
    /// <param name="options"></param>
    public static void InitTMPDropdownData(Transform dropdownTransform, List<string> options)
    {
        TMP_Dropdown dropdown = dropdownTransform.GetComponent<TMP_Dropdown>();
        InitTMPDropdownData(dropdown, options);
    }

    /// <summary>
    /// 初始化 TMP_Dropdown 下拉数据
    /// </summary>
    /// <param name="dropdown"></param>
    /// <param name="options"></param>
    public static void InitTMPDropdownData(TMP_Dropdown dropdown, List<string> options)
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    /// <summary>
    /// 初始化 TMP_Dropdown 下拉选择事件
    /// </summary>
    /// <param name="dropdownTransform"></param>
    /// <param name="dropdownEvent"></param>
    public static void InitTMPDropdownEvent(Transform dropdownTransform, UnityAction<int> dropdownEvent)
    {
        TMP_Dropdown dropdown = dropdownTransform.GetComponent<TMP_Dropdown>();
        InitTMPDropdownEvent(dropdown, dropdownEvent);
    }

    /// <summary>
    /// 初始化 TMP_Dropdown 下拉选择事件
    /// </summary>
    /// <param name="dropdown"></param>
    /// <param name="dropdownEvent"></param>
    public static void InitTMPDropdownEvent(TMP_Dropdown dropdown, UnityAction<int> dropdownEvent)
    {
        dropdown.onValueChanged.RemoveAllListeners();
        dropdown.onValueChanged.AddListener(dropdownEvent);
    }

    /// <summary>
    /// 初始化 Toggle 选择事件
    /// </summary>
    /// <param name="toggleTransform"></param>
    /// <param name="toggleEvent"></param>
    public static void InitToggle(Transform toggleTransform, UnityAction<bool> toggleEvent)
    {
        Toggle toggle = toggleTransform.GetComponent<Toggle>();
        InitToggle(toggle, toggleEvent);
    }

    /// <summary>
    /// 初始化 Toggle 选择事件
    /// </summary>
    /// <param name="toggle"></param>
    /// <param name="click"></param>
    public static void InitToggle(Toggle toggle, UnityAction<bool> click)
    {
        toggle.onValueChanged.RemoveAllListeners();
        toggle.onValueChanged.AddListener(click);
    }

    /// <summary>
    /// 初始化 Slider 滑动事件
    /// </summary>
    /// <param name="sliderTransform"></param>
    /// <param name="loadingListener"></param>
    public static void InitSlider(Transform sliderTransform, UnityAction<float> loadingListener)
    {
        Slider slider = sliderTransform.GetComponent<Slider>();
        InitSlider(slider, loadingListener);
    }

    /// <summary>
    /// 初始化 Slider 滑动事件
    /// </summary>
    /// <param name="slider"></param>
    /// <param name="loadingListener"></param>
    public static void InitSlider(Slider slider, UnityAction<float> loadingListener)
    {
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(loadingListener);
    }

}
