/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月28日 14:24:20
* |     主要功能：TamTool通用工具
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
namespace TamKit
{
    public class TamTool
    {
        //返回当前方法所在的类名
        public static string getCurrentClassName()
        {
            string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
            return className;
        }

        /**
         * 返回调用当前方法的方法名
         * 参数 index : 1 代表上级，2 代表上上级，以此类推
         */
        public static string getClassName(int index = 1)
        {
            StackTrace trace = new StackTrace();
            //1代表上级，2代表上上级，以此类推
            StackFrame frame = trace.GetFrame(index);
            MethodBase method = frame.GetMethod();
            string className = method.ReflectedType.Name;
            return className + "." + method.Name;
        }

        //定义一个执行耗时计算委托
        public delegate void PerformTimeConsum();

        /// <summary>
        /// 执行耗时计算操作委托作为参数
        /// </summary>
        /// <param name="performTimeConsuming"></param>
        public static double PerformTimeConsums(PerformTimeConsum performTimeConsuming)
        {
            //Stopwatch提供一组方法和属性，可用于准确地测量运行时间
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //可以添加一些处理过程。
            performTimeConsuming();

            sw.Stop();
            //获取当前实例测量得出的总运行时间
            System.TimeSpan dt = sw.Elapsed;

            UnityEngine.Debug.Log("程序耗时: " + dt + " 秒");
            return dt.TotalSeconds;
        }

        //输出整型数组
        public static string NumList2String(int[] list)
        {
            string str = "";
            foreach (int n in list)
                str += n + " ";

            return str;
        }

        /// <summary>
        /// 设置Layer层级
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="layerString"></param>
        public static void SetLayer(GameObject gameObject, string layerString)
        {
            gameObject.layer = LayerMask.NameToLayer(layerString);

        }

    }
}