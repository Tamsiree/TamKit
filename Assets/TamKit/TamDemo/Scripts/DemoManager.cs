/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 17:16:07
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoManager : TamSingletonMono<DemoManager>
{
    private TerminalView terminalView;

    private Transform scrollContent;

    private Button EnumDemoButton;
    private Button ToastDemoButton;
    private Button TamRecyclerViewDemoButton;
    private Button GridButton;
    private Button VerticalButton;
    private Button HorizontalButton;
    private Button Pano360DemoButton;
    private Button AutoRotateDemoButton;
    private Button DrawOutlineDemoButton;
    private Button TamNumParticleDemoButton;
    private Button TamTemperatureDemoButton;
    private Button TamExitDemoButton;


    private EnumDemo enumDemo;
    private ToastDemo toastDemo;
    private TamRecyclerViewDemo tamRecyclerViewDemo;
    private Pano360Demo pano360Demo;

    protected override void OnStart()
    {
        InitData();
        InitView();
    }


    protected override void OnUpdate()
    {

    }

    private void InitData()
    {

    }

    private void InitView()
    {
        terminalView = transform.Find("DemoCanvas/DemoPanel/TerminalView").GetComponent<TerminalView>();
        scrollContent = transform.Find("DemoCanvas/DemoPanel/DemoScrollView/Viewport/Content");

        EnumDemoButton = scrollContent.Find("EnumDemo").GetComponent<Button>();
        enumDemo = EnumDemoButton.GetComponent<EnumDemo>();

        ToastDemoButton = scrollContent.Find("ToastDemo").GetComponent<Button>();
        toastDemo = ToastDemoButton.GetComponent<ToastDemo>();


        TamRecyclerViewDemoButton = scrollContent.Find("TamRecyclerViewDemo").GetComponent<Button>();
        tamRecyclerViewDemo = TamRecyclerViewDemoButton.GetComponent<TamRecyclerViewDemo>();

        GridButton = TamRecyclerViewDemoButton.transform.Find("Layout/GridButton").GetComponent<Button>();
        VerticalButton = TamRecyclerViewDemoButton.transform.Find("Layout/VerticalButton").GetComponent<Button>();
        HorizontalButton = TamRecyclerViewDemoButton.transform.Find("Layout/HorizontalButton").GetComponent<Button>();

        Pano360DemoButton = scrollContent.Find("Pano360Demo").GetComponent<Button>();
        pano360Demo = Pano360DemoButton.GetComponent<Pano360Demo>();

        AutoRotateDemoButton = scrollContent.Find("AutoRotateDemo").GetComponent<Button>();

        DrawOutlineDemoButton = scrollContent.Find("DrawOutlineDemo").GetComponent<Button>();

        TamNumParticleDemoButton = scrollContent.Find("TamNumParticleDemo").GetComponent<Button>();

        TamTemperatureDemoButton = scrollContent.Find("TamTemperatureDemo").GetComponent<Button>();

        TamExitDemoButton = scrollContent.Find("TamExitDemo").GetComponent<Button>();

        GUIKit.InitButtonOnClick(EnumDemoButton, () =>
        {
            enumDemo.Test();
            tamRecyclerViewDemo.DismissRecyclerView();
        });

        GUIKit.InitButtonOnClick(ToastDemoButton, () =>
        {
            toastDemo.OnClickBtn();
            tamRecyclerViewDemo.DismissRecyclerView();
        });

        GUIKit.InitButtonOnClick(TamRecyclerViewDemoButton, () =>
        {
            tamRecyclerViewDemo.ShowRecyclerView();
        });
        GUIKit.InitButtonOnClick(GridButton, () =>
        {
            tamRecyclerViewDemo.SetRecyclerViewType(TamRecyclerView.RecyclerViewType.Grid);
            tamRecyclerViewDemo.ShowRecyclerView();
        });
        GUIKit.InitButtonOnClick(VerticalButton, () =>
        {
            tamRecyclerViewDemo.SetRecyclerViewType(TamRecyclerView.RecyclerViewType.Vertical);
            tamRecyclerViewDemo.ShowRecyclerView();
        });
        GUIKit.InitButtonOnClick(HorizontalButton, () =>
        {
            tamRecyclerViewDemo.SetRecyclerViewType(TamRecyclerView.RecyclerViewType.Horizontal);
            tamRecyclerViewDemo.ShowRecyclerView();
        });

        GUIKit.InitButtonOnClick(Pano360DemoButton, () =>
        {
            pano360Demo.OnClickEvent();
        });

        GUIKit.InitButtonOnClick(AutoRotateDemoButton, () =>
        {
            SceneManager.LoadScene("TamEffectScene");
        });

        GUIKit.InitButtonOnClick(DrawOutlineDemoButton, () =>
        {
            SceneManager.LoadScene("TamDrawOutline");
        });

        GUIKit.InitButtonOnClick(TamNumParticleDemoButton, () =>
        {
            SceneManager.LoadScene("TamNumParticleScene");
        });

        GUIKit.InitButtonOnClick(TamTemperatureDemoButton, () =>
        {
            SceneManager.LoadScene("TamTemperatureScene");
        });

        GUIKit.InitButtonOnClick(TamExitDemoButton, () =>
        {
            GameManager.Instance.ExitGame();
        });

    }

    public void SendTerminalMessage(string message)
    {
        terminalView.AddMessage(message);
    }
}
