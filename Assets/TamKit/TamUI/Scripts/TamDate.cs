/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年12月23日 19:05:51
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamDate : MonoBehaviour
{
    private Text TimeText;

    // Start is called before the first frame update
    void Start()
    {
        TimeText = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        //获取系统当前时间
        DateTime NowTime = DateTime.Now;
        //NowTime = NowTime.AddHours(8);
        TimeText.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
