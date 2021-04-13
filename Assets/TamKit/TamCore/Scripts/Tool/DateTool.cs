/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 17:14:16
* |     主要功能：时间日期工具
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using UnityEngine;
using System.Collections;
using System;

public class DateTool
{
    /// 1秒 
    public static int Second = 1;
    /// 1分
    public static int Minute = 60 * Second;
    /// 1小时 
    public static int Hour = 60 * Minute;
    /// 1天
    public static int Day = 24 * Hour;

    //时间戳起始时间本地化
    static DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));

    public static string[] WeekDayChinese = new string[] { "日", "一", "二", "三", "四", "五", "六" };

    /// <summary>
    /// 获取当前时间戳(格林威治时间) 本地时间
    /// </summary>
    /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>
    /// <returns></returns>
    public static long GetNowTime(bool bflag = true)
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        long ret;
        if (bflag)
            // 10 位
            ret = Convert.ToInt64(ts.TotalSeconds);
        else
            // 13位
            ret = Convert.ToInt64(ts.TotalMilliseconds);
        return ret;
    }

    /// <summary>
    /// 将long型时间戳转换成DataTime型(本地时间)
    /// </summary>
    /// <param name="UnixTime"></param>
    /// <returns></returns>
    public static DateTime UnixToDataTime(long UnixTime)
    {
        return dtStart.AddSeconds(UnixTime);
    }

    /// <summary>
    /// 今天周几 一到日 对应 1-6-0
    /// </summary>
    /// <returns></returns>
    // public static int GetWeekDayNow()
    // {
    //     GameTimeManager gtm = GameManager.GetInstance().GetBaseMonoManager<GameTimeManager>(BaseManagerKind.Time);
    //     DateTime dt = gtm.GetNowTime();
    //     return (int)dt.DayOfWeek;
    // }

    /// <summary>
    /// 如果参数1早于参数2，返回true
    /// </summary>
    /// <param name="first">时间参数1</param>
    /// <param name="second">时间参数2</param>
    /// <returns></returns>
    public static bool IsFirstEarlier(DateTime first, DateTime second)
    {
        if (first.CompareTo(second) < 0)
            return true;
        return false;
    }

    /// <summary>
    /// 如果参数1早于参数2，返回true
    /// </summary>
    /// <param name="first">时间参数1</param>
    /// <param name="second">时间参数2</param>
    /// <returns></returns>
    public static bool IsFirstEarlier(TimeSpan first, TimeSpan second)
    {
        return first < second;
    }

    /// <summary>
    /// 日期转换成unix时间戳(本地时间)
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long DateTimeToUnix(DateTime dateTime)
    {
        return Convert.ToInt64((dateTime - dtStart).TotalSeconds);
    }

    /// <summary>
    /// Time_1 + sec，返回时间戳加秒数后的时间戳
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="sec">秒</param>
    /// <returns></returns>
    public static long UnixTimeAddSeconds(long Time_1, int sec)
    {
        //DateTime dataTime_1 = UnixToDataTime(Time_1);
        return Time_1 + (long)sec;
    }

    /// <summary>
    /// Time_2 - Time_1，返回相减后的的时间间隔
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="Time_2">时间戳_2</param>
    /// <returns></returns>
    public static TimeSpan UnixTimeSubtractUnixTimeToTimeSpan(long Time_1, long Time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(Time_1);
        DateTime dataTime_2 = UnixToDataTime(Time_2);
        TimeSpan a = dataTime_2 - dataTime_1;
        return a;
    }

    /// <summary>
    /// Time_2 - Time_1，返回相减后的的时间间隔(时数)
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="Time_2">时间戳_2</param>
    /// <returns></returns>
    public static int UnixTimeSubtractUnixTimeToHour(long Time_1, long Time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(Time_1);
        DateTime dataTime_2 = UnixToDataTime(Time_2);
        TimeSpan a = dataTime_2 - dataTime_1;
        return (int)a.TotalHours;
    }

    /// <summary>
    /// Time_2 - Time_1，返回相减后的的时间间隔(秒数)
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="Time_2">时间戳_2</param>
    /// <returns></returns>
    public static int UnixTimeSubtractUnixTimeToSeconds(long Time_1, long Time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(Time_1);
        DateTime dataTime_2 = UnixToDataTime(Time_2);
        TimeSpan a = dataTime_2 - dataTime_1;
        return (int)a.TotalSeconds;
    }

    /// <summary>
    /// Time_2 - Time_1，返回相减后的的时间间隔(分钟)
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="Time_2">时间戳_2</param>
    /// <returns></returns>
    public static int UnixTimeSubtractUnixTimeToMinutes(long Time_1, long Time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(Time_1);
        DateTime dataTime_2 = UnixToDataTime(Time_2);
        TimeSpan a = dataTime_2 - dataTime_1;
        return (int)a.TotalMinutes;
    }

    /// <summary>
    /// Time_2 - Time_1，返回相减后的的时间间隔(天数)
    /// </summary>
    /// <param name="Time_1">时间戳_1</param>
    /// <param name="Time_2">时间戳_2</param>
    /// <returns></returns>
    public static int UnixTimeSubtractUnixTimeToDay(long Time_1, long Time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(Time_1);
        DateTime dataTime_2 = UnixToDataTime(Time_2);
        TimeSpan a = dataTime_2 - dataTime_1;
        return (int)a.TotalDays;
    }


    // 是否是同一天
    public static bool isSameDay(long time_1, long time_2)
    {
        DateTime dataTime_1 = UnixToDataTime(time_1);
        DateTime dataTime_2 = UnixToDataTime(time_2);
        if (dataTime_1.Year != dataTime_2.Year)
        {
            return false;
        }

        if (dataTime_1.Month != dataTime_2.Month)
        {
            return false;
        }
        if (dataTime_1.Day != dataTime_2.Day)
        {
            return false;
        }

        return true;

    }


    /// <summary>
    /// 获取当前时间戳的一天开始时间
    /// </summary>
    /// <param name="Time"></param>
    /// <returns></returns>
    public static long GetTheUnixToTheStartDay(long Time)
    {
        DateTime dataTime = UnixToDataTime(Time);
        DateTime returndate = new DateTime(dataTime.Year, dataTime.Month, dataTime.Day, 0, 0, 0);
        return DateTimeToUnix(returndate);
    }

    /// <summary>
    /// unix时间戳转换成日期
    /// </summary>
    /// <param name="unixTimeStamp">时间戳（秒）</param>
    /// <returns></returns>
    public static DateTime UnixTimestampToDateTime(DateTimeKind Kind, long timestamp)
    {
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, Kind);
        return start.AddSeconds(timestamp);
    }

    /// <summary>
    /// 返回某年某月最后一天
    /// </summary>
    /// <param name="year">年份</param>
    /// <param name="month">月份</param>
    /// <returns>日</returns>
    public static int GetMonthLastDate(int year, int month)
    {
        DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
        int Day = lastDay.Day;
        return Day;
    }


    /// <summary>
    /// 获取格式化后的时间格式
    /// </summary>
    /// <param name="timeStamp">10位时间戳（不填默认当前时间戳）</param>
    public static string getFormatTime(long timeStamp = -1){
        DateTime dateTime = new DateTime();
        if(timeStamp == -1){
            // 当前时间(10wei)
           timeStamp = DateTool.GetNowTime();
           dateTime = UnixToDataTime(timeStamp); 
        }else{
            // 指定的时间
            dateTime = DateTool.UnixToDataTime(timeStamp);
        }
        return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// 获取格式化后的时间格式
    /// </summary>
    /// <param name="timeStamp">10位时间戳（不填默认当前时间戳）</param>
    public static string getFormatLeftTime(long startTime,long endTime){
        long leftTime = endTime - startTime;
        //  时
        int hour = (int) (leftTime / Hour) ;
        if(hour != 0 ){
            leftTime -= (hour*Hour);
        }
        //  分
        int minute = (int) (leftTime / Minute) ;
        if(minute != 0 ){
            leftTime -= (minute*Minute);
        }
        // 秒
        int second = (int) (leftTime / Second) ;
        return string.Format("{0}时{1}分{2}秒",hour,minute,second);
    }



    /// <summary>
    /// 格式化日期时间
    /// </summary>
    /// <param name="dateTime1">日期时间</param>
    /// <param name="dateMode">显示模式</param>
    /// <returns>0-9种模式的日期</returns>
    public static string FormatDate(DateTime dateTime1, string dateMode)
    {
        switch (dateMode)
        {
            case "0":
                return dateTime1.ToString("yyyy-MM-dd");
            case "1":
                return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
            case "2":
                return dateTime1.ToString("yyyy/MM/dd");
            case "3":
                return dateTime1.ToString("yyyy年MM月dd日");
            case "4":
                return dateTime1.ToString("MM-dd");
            case "5":
                return dateTime1.ToString("MM/dd");
            case "6":
                return dateTime1.ToString("MM月dd日");
            case "7":
                return dateTime1.ToString("yyyy-MM");
            case "8":
                return dateTime1.ToString("yyyy/MM");
            case "9":
                return dateTime1.ToString("yyyy年MM月");
            default:
                return dateTime1.ToString();
        }
    }

    //FIXME: to remove
    public static DateTime GetLeaveTime(float timeSpan)
    {
        return DateTime.Now.AddMinutes(timeSpan);
        //return DateTime.Now.AddHours(timeSpan);
    }

    public static int GetSecondsFrom1stTo2nd(DateTime first, DateTime second)
    {
        if (!IsFirstEarlier(first, second))
            return 0;
        TimeSpan t1 = new TimeSpan(first.Ticks);
        TimeSpan t2 = new TimeSpan(second.Ticks);
        TimeSpan ts = t2.Subtract(t1).Duration();
        return (int)ts.TotalSeconds;
    }

    /// <summary>
    /// 用于商店活动和家具抽奖限时活动的策划表
    /// </summary>
    /// <param name="DateFormat"></param>
    /// <returns></returns>
    public static int GetActivityLastDay_DateFormat(string startTime, string endTime)
    {
        string date1 = startTime.Split('_')[0];
        string date2 = endTime.Split('_')[0];

        DateTime dt1 = new DateTime(int.Parse(date1.Split('#')[0]), int.Parse(date1.Split('#')[1]), int.Parse(date1.Split('#')[2]));
        DateTime dt2 = new DateTime(int.Parse(date2.Split('#')[0]), int.Parse(date2.Split('#')[1]), int.Parse(date1.Split('#')[2]));

        TimeSpan a = dt2 - dt1;
        return (int)a.TotalDays;
    }

    /// <summary>
    /// 用于商店活动和家具抽奖限时活动的策划表
    /// </summary>
    /// <param name="WeekDayFormat"></param>
    /// <returns></returns>
    public static int GetActivityLastDay_WeekDayFormat(int startWD, int endWD)
    {
        if(endWD >= startWD){
            return endWD - startWD;
        }
        
        return startWD + (7 - endWD);
    }

}
