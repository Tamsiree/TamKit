/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月24日 18:11:36
* |     主要功能：测试工具
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamTest : MonoBehaviour
{

    [SerializeField, SetProperty("IsTest")]
    private bool isTest;
    public bool IsTest
    {
        get
        {
            return isTest;
        }
        private set
        {
            isTest = value;
        }
    }

    [SerializeField, SetProperty("IsLogAll")]
    private bool isLogAll;
    public bool IsLogAll
    {
        get
        {
            return isLogAll;
        }
        private set
        {
            isLogAll = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isTest)
        {
            if (isLogAll)
            {
                Print("TamTest: isTest已开，isLogAll已开");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Print(object message)
    {
        if (isTest)
        {
            if (isLogAll)
            {
                print(message);
            }
        }
    }

}
