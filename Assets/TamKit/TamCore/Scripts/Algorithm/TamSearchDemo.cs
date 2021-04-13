/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月24日 17:54:24
* |     主要功能：二分查找
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TamSearchDemo : MonoBehaviour
{
    [SerializeField]
    private bool isTest = false;

    [SerializeField]
    private int[] array;

    [SerializeField]
    private KeyCode applyKeyCode = KeyCode.Return;

    // Start is called before the first frame update
    void Start()
    {
        if (array.Length < 1)
        {
            array = new int[10];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = UnityEngine.Random.Range(0, 101);
            }
        }
        //使用冒泡排序 把数组变成 升序排列
        array = TamSort.QuickSort(array);
        if (isTest)
        {
            print("二分查找之前：" + TamKit.TamTool.NumList2String(array));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTest)
        {
            if (Input.GetKeyDown(applyKeyCode))
            {
                TamKit.TamTool.PerformTimeConsums(new TamKit.TamTool.PerformTimeConsum(TestBinarySearch));
            }
        }
    }


    private void TestBinarySearch()
    {
        int index = UnityEngine.Random.Range(0, array.Length);
        int value = TamSearch.BinarySearch(array, array[index]);
        print("二分查找之后：" + array[value]);
    }

}
