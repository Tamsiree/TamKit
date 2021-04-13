/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年08月19日 11:57:25
* |     主要功能：数据处理公共工具类
* |     详细描述：
* |     版本：1.0
*  ======================================================== */


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class DataTool
{

    public static int ToInt(object obj)
    {
        int result = default(int);
        if (obj != null && obj != DBNull.Value)
        {
            int.TryParse(obj.ToString(), out result);
        }
        return result;
    }

    //格式化
    public static string JsonTree(string json)
    {
        int level = 0;
        string jsonTree = string.Empty;
        for (int i = 0; i < json.Length; i++)
        {
            char c = json[i];
            if (level > 0 && '\n' == jsonTree[jsonTree.Length - 1])
            {
                jsonTree += TreeLevel(level);
            }
            switch (c)
            {
                case '{':
                    jsonTree += c + "\n";
                    level++;

                    break;
                case ',':
                    jsonTree += c + "\n";
                    break;
                case '}':
                    jsonTree += "\n";
                    level--;
                    jsonTree += TreeLevel(level);
                    jsonTree += c;
                    break;
                default:
                    jsonTree += c;
                    break;
            }
        }
        return jsonTree;
    }

    private static string TreeLevel(int level)
    {
        string leaf = string.Empty;
        for (int t = 0; t < level; t++)
        {
            leaf += "\t";
        }
        return leaf;
    }



    public static string LoadJsonFile(string filePath)
    {
        string json = "";
        if (filePath.Contains("task"))
        {
            Debug.Log("task :: filePath : " + filePath);
        }
        TextAsset t = Resources.Load<TextAsset>(filePath);
        if (t == null)
        {
            Debug.LogError("json 文件不存在 ，错误的 fileName = " + filePath);
        }
        else
        {
            json = t.text;
        }
        return json;
    }

    public static string Number2Chinese(string dd)
    {
        Dictionary<int, string> dic = new Dictionary<int, string>();
        dic.Add(1, "一");
        dic.Add(2, "二");
        dic.Add(3, "三");
        dic.Add(4, "四");
        dic.Add(5, "五");
        dic.Add(6, "六");
        dic.Add(7, "七");
        dic.Add(8, "八");
        dic.Add(9, "九");
        dic.Add(0, "零");
        string svalue = string.Empty;
        foreach (char item in dd.ToCharArray())
        {
            foreach (int key in dic.Keys)
            {
                if (key.ToString() == item.ToString())
                {
                    svalue += dic[key];
                    break;
                }
            }
        }
        return svalue;
    }

    public static bool IsSuccessWithPercent(float percent)
    {
        if (percent < 0f)
        {
            percent = 0;
        }
        else if (percent > 1f)
        {
            percent = 1;
        }
        if (UnityEngine.Random.Range(0f, 1f) < percent)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 四舍五入
    /// </summary>
    /// <param name="value"></param>
    /// <param name="decimals"></param>
    /// <returns></returns>
    public static double ChinaRound(double value, int decimals = 0)
    {
        return System.Math.Round(value, decimals, System.MidpointRounding.AwayFromZero);
    }

    public static int GetRandomIndex(object[] objList, int oldSelectIndex)
    {
        if (objList.Length == 0)
        {
            return -1;
        }
        else if (objList.Length == 1)
        {
            return 0;
        }
        else if (objList.Length == 2)
        {
            if (oldSelectIndex == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            int inx = 0;
            while (true)
            {
                //随机一个index，直到不等于oldSelectIndex
                inx = UnityEngine.Random.Range(0, objList.Length);
                if (inx != oldSelectIndex)
                {
                    break;
                }
            }
            return inx;
        }
    }

    static StringBuilder strB = new StringBuilder();
    public static string AppendStr(string str_1, string str_2)
    {
        strB.Clear();
        strB.Append(str_1).Append(str_2);
        return strB.ToString();
    }

    public static string GetNumString(int num)
    {
        float absNum = Mathf.Abs(num);
        string rStr = num > 0 ? "" : "-";
        if (absNum >= 100000000)
        {
            rStr += (absNum / 100000000).ToString("#0.00") + "m";
        }
        else if (absNum >= 10000)
        {
            rStr += (absNum / 10000).ToString("#0.00") + "k";
        }
        else
        {
            rStr += absNum;
        }
        return rStr;
    }

    //一些通用的数学方法
    //通过传入一组权重，随机返回一个key
    public static string GetRandomDataFromWeightList(Dictionary<string, float> list)
    {
        float sum = 0;
        foreach (string k in list.Keys)
        {
            if (list[k] > 0)
            {
                sum += list[k];
            }
        }
        //传入的数组无效
        if (sum == 0)
        {
            Debug.Log("传入的数组无效!");
            return null;
        }
        float ranNum = UnityEngine.Random.Range(0, sum);

        float addNum = 0;
        foreach (string k in list.Keys)
        {
            if (list[k] > 0)
            {
                addNum += list[k];
                if (ranNum < addNum)
                {
                    return k;
                }
            }
        }
        Debug.Log("未找到合适的值！");
        return null;
    }

    public static Dictionary<T, S> MySortDic<T, S>(Dictionary<T, S> sortDic, Func<KeyValuePair<T, S>, KeyValuePair<T, S>, int> sortFunc)
    {
        List<KeyValuePair<T, S>> Linelist = new List<KeyValuePair<T, S>>(sortDic);
        //利用链表的Sort方法进行排序
        Linelist.Sort(
            (KeyValuePair<T, S> left, KeyValuePair<T, S> right) =>
            {
                return sortFunc(left, right);
            });
        sortDic.Clear();
        for (int i = 0; i < Linelist.Count; i++)
        {
            sortDic[Linelist[i].Key] = Linelist[i].Value;
        }
        return sortDic;
    }
    #region 时间戳相关

    /// <summary>
    /// 获取时间戳Timestamp  
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static int GetTimeStamp(DateTime dt)
    {
        DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
        int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
        return timeStamp;
    }

    /// <summary>
    /// 时间戳Timestamp转换成日期
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static DateTime GetDateTime(int timeStamp)
    {
        DateTime dtStart = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));
        long lTime = ((long)timeStamp * 10000000);
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime targetDt = dtStart.Add(toNow);
        return targetDt;
    }

    /// <summary>
    /// 时间戳Timestamp转换成日期
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static DateTime GetDateTime(string timeStamp)
    {
        DateTime dtStart = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime targetDt = dtStart.Add(toNow);
        return dtStart.Add(toNow);
    }

    /// <summary>
    /// 时间戳Timestamp转换成日期
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static DateTime GetDateTime(long nowtimeStamp)
    {
        DateTime startTime = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddSeconds(nowtimeStamp);
        return dt;
    }
    #endregion
    public static string TurnContent(string content)
    {
        string turnStr = content;
        //turnStr = turnStr.Replace("[nt]","\n  ");
        turnStr = turnStr.Replace("[n]", "\n  ");
        turnStr = turnStr.Replace("[b]", "<b>");
        turnStr = turnStr.Replace("[/b]", "</b>");
        turnStr = turnStr.Replace("[i]", "<i>");
        turnStr = turnStr.Replace("[/i]", "</i>");
        turnStr = turnStr.Replace("[cr]", "<color=#ea6b61>");
        turnStr = turnStr.Replace("[/cr]", "</color>");
        turnStr = turnStr.Replace("[s1]", "<size=20>");
        turnStr = turnStr.Replace("[/s1]", "</size> ");

        return turnStr;
    }

    public static string GetTaskDescribe(string baseStr, int num, string name = null)
    {
        string rStr = baseStr;
        if (name != null)
        {
            rStr = rStr.Replace("@", name);
        }
        rStr = rStr.Replace("#", num.ToString());
        return rStr;
    }

    /// <summary>
    /// 获取当前时间戳
    /// </summary>
    /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>
    /// <returns></returns>
    public static long GetTimeStamp(bool bflag = true)
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long ret;
        if (bflag)
            ret = Convert.ToInt64(ts.TotalSeconds);
        else
            ret = Convert.ToInt64(ts.TotalMilliseconds);
        return ret;
    }

    public static void GetMethonUseTimeString(string MSGPreStr, Action methon)
    {
        System.DateTime start = System.DateTime.Now;
        methon?.Invoke();
        System.DateTime end = System.DateTime.Now;
        Debug.Log($"{MSGPreStr} startTime:{start}  endTime:{end} delTime:{end - start}");
    }

    public static void PushErr()
    {
        //Debug.LogError("手动触发一个错误！");
        string t = "aaa";
        int.Parse(t);
    }

    static string TurnExceptionStr(string str, bool flag = true)
    {
        string rStr = "";
        string StackTrace = str;
        string strTemp = "\n";
        string[] StackTraceList = Regex.Split(StackTrace, strTemp, RegexOptions.IgnoreCase);
        bool onceKey = true;
        for (int i = StackTraceList.Length - 1; i >= 0; i--)
        {
            string baseStr = StackTraceList[i];
            string splitKey = ".cs:";
            if (flag)
            {
                if (baseStr.Contains("Assets/Scripts"))
                {
                    if (onceKey)
                    {
                        splitKey = "/";
                    }
                    string[] splitBaseStr = Regex.Split(baseStr, splitKey, RegexOptions.IgnoreCase);
                    if (splitBaseStr.Length < 2)
                    {
                        continue;
                    }
                    onceKey = false;
                    rStr += splitBaseStr[splitBaseStr.Length - 1] + "_";
                }
            }
            else
            {
                if (onceKey)
                {
                    splitKey = "\\\\";
                }
                string[] splitBaseStr = Regex.Split(baseStr, splitKey, RegexOptions.IgnoreCase);
                if (splitBaseStr.Length < 2)
                {
                    continue;
                }
                onceKey = false;
                rStr += splitBaseStr[splitBaseStr.Length - 1] + "_";
            }
        }
        return rStr;
    }

    public static string GetPlatformPath()
    {
        RuntimePlatform platform = Application.platform;
        switch (platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                return "Windows";
            case RuntimePlatform.Android:
                return "Android";
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                return "iOS";
        }

        return "";
    }

    public static List<int> SplitString2Int(string numberStr, char splitSmb)
    {
        string[] str = numberStr.Split(splitSmb);
        List<int> numList = new List<int>();
        for (int i = 0; i < str.Length; i++)
        {
            numList.Add(int.Parse(str[i]));
        }
        return numList;
    }

    public static DateTime SplitString2DateTime(string dateStr, char splitSmb)
    {
        string[] str = dateStr.Split(splitSmb);

        if (str.Length != 6)
        {
            Debug.LogError("读取时间有误，现时间参数个数为： " + str.Length);
        }

        int year = int.Parse(str[0]);
        int month = int.Parse(str[1]);
        int day = int.Parse(str[2]);
        int hour = int.Parse(str[3]);
        int min = int.Parse(str[4]);
        int sec = int.Parse(str[5]);

        DateTime date = new DateTime(year, month, day, hour, min, sec);
        return date;
    }

    //获得时间简写
    public static string GetShortenTimeBySec(int sec, bool tillMin = false)
    {
        string str = "";
        if (sec == 0) return "0_S";

        if (sec > 3600)
        {
            int h = sec / 3600;
            str = h.ToString() + "_H";
            return str;
        }

        int m = 0;
        if (sec > 60)
        {
            m = sec / 60;
            str = m.ToString() + "_M";
            return str;
        }

        if (!tillMin)
        {
            str = sec.ToString() + "_S";
        }
        return str;
    }

    public static string GetTimeStringBySec(int sec, bool tillMin = false)
    {
        string str = "";
        if (sec == 0) return str;

        if (sec > 3600)
        {
            int h = sec / 3600;
            str += h.ToString() + "时";
            sec %= 3600;
        }

        int m = 0;
        if (sec > 60)
        {
            m = sec / 60;
            sec %= 60;
        }
        str += m.ToString() + "分";

        if (!tillMin)
        {
            str += sec.ToString() + "秒";
        }
        return str;
    }

    public static string GetTimeNumberBySec(int sec, bool tillMin = false)
    {
        string str = "";
        if (sec == 0) return "00:00";

        if (sec > 3600)
        {
            int h = sec / 3600;
            str += h.ToString("d2") + ":";
            sec %= 3600;
        }
        else if (tillMin)
        {
            str += "00:";
        }

        int m = sec / 60;
        str += m.ToString("d2");
        sec %= 60;


        if (!tillMin)
        {
            str += ":" + sec.ToString("d2");
        }
        return str;
    }

    public static string GetLastStringBySplit(string filePath, char splitSmb)
    {
        string[] str = filePath.Split(splitSmb);
        string lastStr = str[str.Length - 1];
        return lastStr;
    }

    //FIXME: temp closed
    public static string AutoWrap(string target, int wrapInChar)
    {
        string str1 = target;
        string wrapedString = target;
        int targetSize = target.Length;
        int wrapTimes = (targetSize - 1) / wrapInChar;
        for (int i = wrapTimes; i > 0; i--)
        {
            int wrapIndex = i * wrapInChar;
            wrapedString = str1.Insert(wrapIndex, "\n");
            str1 = wrapedString;
        }
        return wrapedString;
    }


    public static string MoneyToText(int money)
    {
        string back = "";
        float front = money;
        string f = front.ToString() + back;

        if (money > 999999)
        {
            front = money / 1000000f;
            back = "m";
            f = string.Format("{0:0.##}", front) + back;
        }
        else if (money > 9999)
        {
            front = money / 1000f;
            back = "k";
            f = string.Format("{0:0.##}", front) + back;
        }

        return f;
    }

    //FIXME: 有的0被省略了
    public static int TextToMoney(string textMoney)
    {
        textMoney = textMoney.Replace(".", "");
        textMoney = textMoney.Replace("k", "0");
        textMoney = textMoney.Replace("m", "0000");
        try
        {
            return int.Parse(textMoney);
        }
        catch
        {
            return 0;
        }
    }


    /// <summary>
    /// 获取枚举项描述信息 例如GetEnumDesc(Days.Sunday)
    /// </summary>
    /// <param name="en">枚举项 如Days.Sunday</param>
    /// <returns></returns>
    public static string GetEnumDesc(Enum en)
    {
        Type type = en.GetType();
        MemberInfo[] memInfo = type.GetMember(en.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
        }
        return en.ToString();
    }

    ///<summary>
    /// 获取枚举项+描述
    ///</summary>
    ///<param name="enumType">Type,该参数的格式为typeof(需要读的枚举类型)</param>
    ///<returns>键值对</returns>
    public static Dictionary<string, string> GetEnumItemDesc(Type enumType)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        FieldInfo[] fieldinfos = enumType.GetFields();
        foreach (FieldInfo field in fieldinfos)
        {
            if (field.FieldType.IsEnum)
            {
                System.Object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                dic.Add(field.Name, ((DescriptionAttribute)objs[0]).Description);
            }
        }
        return dic;
    }

    ///<summary>
    /// 获取枚举值+描述
    ///</summary>
    ///<param name="enumType">Type,该参数的格式为typeof(需要读的枚举类型)</param>
    ///<returns>键值对</returns>
    public static Dictionary<string, string> GetEnumItemValueDesc(Type enumType)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        Type typeDescription = typeof(DescriptionAttribute);
        FieldInfo[] fields = enumType.GetFields();
        string strText = string.Empty;
        string strValue = string.Empty;
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType.IsEnum)
            {
                strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                object[] arr = field.GetCustomAttributes(typeDescription, true);
                if (arr.Length > 0)
                {
                    DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                    strText = aa.Description;
                }
                else
                {
                    strText = field.Name;
                }
                dic.Add(strValue, strText);
            }
        }
        return dic;
    }




}
