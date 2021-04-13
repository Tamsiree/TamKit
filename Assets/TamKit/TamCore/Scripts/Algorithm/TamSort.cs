/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年07月09日 17:24:39
* |     主要功能：排序算法
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamSort
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    /// <param name="arrayInt"></param>
    /// <returns></returns>
    public static int[] BubbleSortMethod(int[] arrayInt)
    {
        for (int i = 0; i < arrayInt.Length - 1; i++)
        {
            for (int j = 0; j < arrayInt.Length - i - 1; j++)
            {
                if (arrayInt[j] > arrayInt[j + 1])
                {
                    int temp = arrayInt[j];
                    arrayInt[j] = arrayInt[j + 1];
                    arrayInt[j + 1] = temp;
                }
            }
        }
        return arrayInt;
    }

    /// <summary>
    /// 快速排序
    /// 由于排序效率综合来说在几种排序方法中效率较高，因此经常被采用，再加上快速排序思想[分治法]也确实实用.
    /// 快速排序是C.R.A.Hoare于1962年提出的一种划分交换排序。
    /// 它采用了一种分治的策略，通常称其为分治法(Divide-and-ConquerMethod)。
    /// </summary>
    /// <param name="dataArray"></param>
    public static int[] QuickSort(int[] dataArray)
    {
        QuickSort(dataArray, 0, dataArray.Length - 1);
        return dataArray;
    }

    /// <summary>
    /// 快速排序算法内部逻辑
    /// </summary>
    /// <param name="dataArray"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    protected static void QuickSort(int[] dataArray, int left, int right)
    {
        if (left < right)
        {
            //基准数， 把比它小或者等于它的 放在它的左边，然后把比它大的放在它的右边
            int pivot = dataArray[left];
            int i = left;
            int j = right;

            while (i < j)//当i==j的时候，说明我们找到了一个中间位置，这个中间位置就是基准数应该所在的位置 
            {
                //从后往前比较
                //找到了一个比基准数 小于或者等于的数子，应该把它放在x的左边
                while (i < j)
                {
                    if (dataArray[j] <= pivot)
                    {
                        dataArray[i] = dataArray[j];
                        break;
                    }
                    else
                    {
                        j--;//向左移动 到下一个数字，然后做比较
                    }
                }
                //从前往后
                while (i < j)
                {
                    if (dataArray[i] > pivot)
                    {
                        dataArray[j] = dataArray[i];
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            //跳出循环 现在i==j i是中间位置
            dataArray[i] = pivot;
            QuickSort(dataArray, left, i - 1);// left -i- right
            QuickSort(dataArray, i + 1, right);
        }
    }
}
