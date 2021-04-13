/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年07月09日 17:36:21
* |     主要功能：
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TamSortDemo : MonoBehaviour
{
    [SerializeField]
    private bool isTest = false;

    int[] sortData = { 5, 6, 2, 3, 9, 1, 4, 7, 8, 15, 22, 35, 19, 16, 33, 15, 23, 68, 11, 33, 25, 14 };

    [SerializeField]
    private KeyCode applyKeyCode = KeyCode.Return;

    // Start is called before the first frame update
    void Start()
    {

        sortData = GenerateSortData(sortData);
        if (isTest)
        {
            print("排序之前的数据：" + TamKit.TamTool.NumList2String(sortData));
        }
    }

    /// <summary>
    /// 生成待排序数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private int[] GenerateSortData(int[] data)
    {
        if (data.Length < 1)
        {
            data = new int[10];
            for (int i = 0; i < data.Length - 1; i++)
            {
                data[i] = UnityEngine.Random.Range(0, 101);
            }
        }
        return data;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTest)
        {
            if (Input.GetKeyDown(applyKeyCode))
            {
                TamKit.TamTool.PerformTimeConsums(new TamKit.TamTool.PerformTimeConsum(TestBubbleSort));
                TamKit.TamTool.PerformTimeConsums(new TamKit.TamTool.PerformTimeConsum(TestQuickSort));
            }
        }
    }

    /// <summary>
    /// 测试快速排序算法
    /// </summary>
    private void TestQuickSort()
    {
        TamSort.QuickSort(sortData);
        print("快速排序之后：" + TamKit.TamTool.NumList2String(sortData));
    }

    private void TestBubbleSort()
    {
        TamSort.BubbleSortMethod(sortData);
        print("冒泡排序之后：" + TamKit.TamTool.NumList2String(sortData));
    }
}
