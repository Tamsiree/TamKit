/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年09月03日 17:15:31
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //测试用 摘抄LOL台词
    string[] strArr = {
        "真正的大师，永远都怀着一颗学徒的心",
        "断剑重铸之日，其誓归来之时",
        "真正的意志是不会被击败的",
        "我于杀戮之中绽放，亦如黎明中的花朵",
        "是的，只要998，就能让你爽到不能呼吸",
        "物是人非，可我依旧穿着嫁衣，在黑夜中寻找你的身影",
        "我好想射点什么",
        "是时候表演真正的技术了",
        "鸟真多，匹配系统真得能找到所谓的平衡吗？",
        "德玛西亚",};

    //点击事件
    public void OnClickBtn()
    {
        //随机一句话显示出来
        string str = strArr[Random.Range(0, strArr.Length)];
        TamToast.GenerateToast(str);
        DemoManager.Instance.SendTerminalMessage("-----进入ToastDemo----->");
        DemoManager.Instance.SendTerminalMessage(str);
        DemoManager.Instance.SendTerminalMessage("=====EnumDemo结束=====>");
    }

}
