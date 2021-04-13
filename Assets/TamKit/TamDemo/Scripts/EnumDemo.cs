using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnumDemo : MonoBehaviour
{

    public enum Days
    {
        [Description("星期天")]
        Sunday,
        [Description("星期一")]
        Monday,
        [Description("星期二")]
        Tuesday,
        [Description("星期三")]
        Wednesday,
        [Description("星期四")]
        Thursday,
        [Description("星期五")]
        Friday,
        [Description("星期六")]
        Saturday
    }


    public void Test()
    {
        DemoManager.Instance.SendTerminalMessage("-----进入EnumDemo----->");
        Dictionary<string, string> dic1 = DataTool.GetEnumItemDesc(typeof(Days));

        foreach (string key in dic1.Keys)
        {
            Debug.Log(key + ":" + dic1[key]);
            DemoManager.Instance.SendTerminalMessage(key + ":" + dic1[key]);
        }


        Dictionary<string, string> dic = DataTool.GetEnumItemValueDesc(typeof(Days));
        foreach (string key in dic.Keys)
        {
            Debug.Log(key + ":" + dic[key]);
            DemoManager.Instance.SendTerminalMessage(key + ":" + dic[key]);
        }

        Debug.Log(string.Format(Days.Sunday.ToString() + ":" + DataTool.GetEnumDesc(Days.Sunday)));
        DemoManager.Instance.SendTerminalMessage(string.Format(Days.Sunday.ToString() + ":" + DataTool.GetEnumDesc(Days.Sunday)));
        Debug.Log((int)Enum.Parse(typeof(Days), "Thursday", true));
        DemoManager.Instance.SendTerminalMessage("Enum.ToInt:" + ((int)Enum.Parse(typeof(Days), "Thursday", true)).ToString());
        DemoManager.Instance.SendTerminalMessage("=====EnumDemo结束=====>");
    }
}
