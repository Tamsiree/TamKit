/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年07月09日 19:26:45
* |     主要功能：查找算法
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamSearch 
{

    /**
   * 二分查找算法
   *
   * @param srcArray 有序数组
   * @param des 查找元素
   * @return des的数组下标，没找到返回-1
   */
    public static int BinarySearch(int[] srcArray, int des)
    {
        int low = 0;
        int high = srcArray.Length - 1;
        while (low <= high)
        {
            int middle = (low + high) / 2;
            if (des == srcArray[middle])
            {
                return middle;
            }
            else if (des < srcArray[middle])
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }
        return -1;
    }
}
