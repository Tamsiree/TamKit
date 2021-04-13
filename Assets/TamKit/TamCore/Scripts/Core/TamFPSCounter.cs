/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2021年04月13日 23:42:38
* |     主要功能：显示当前的FPS
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamFPSCounter : MonoBehaviour
{
    private float fps;

    //累加器
    private float accum;

    //帧数
    private int frames;

    //剩余时间
    private float timeleft;

    public float Fps => fps;

    //更新间隔时间
    private const float updateInterval = 0.5F;

    public static void RenderFps(float fps, string s, Rect rc)
    {
        var text = string.Format("{0}: {1:F2}", s, fps);

        if (fps < 10)
        {
            GUI.color = Color.red;
        }
        else if (fps < 30)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.green;
        }

        GUI.Label(rc, text);
    }

    private void OnEnable()
    {
        accum = 0;
        frames = 0;
        timeleft = 0;
        fps = 0;
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;

        ++frames;

        if (timeleft <= 0.0)
        {
            fps = accum / frames;
            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }

    private void OnGUI()
    {
        RenderFps(fps, "FPS", new Rect(Screen.width - 80, 0, 80, 20));
    }
}
