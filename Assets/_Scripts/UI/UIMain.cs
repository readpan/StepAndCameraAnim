using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMain : UIPanelBase
{
    public ButtonGroup Button_Startup;
    public ButtonGroup Button_Shutdown;
    public ButtonGroup Button_SuTiaoGuan;

    protected override void Awake()
    {
        base.Awake();
        TheCanvasGroup = GetComponent<CanvasGroup>();
        Button_Startup = Global.FindChild<ButtonGroup>(transform, "Button_Startup");
        Button_Shutdown = Global.FindChild<ButtonGroup>(transform, "Button_Shutdown");
        Button_SuTiaoGuan = Global.FindChild<ButtonGroup>(transform, "Button_SuTiaoGuan");
    }

    protected override void Start()
    {
        base.Start();
        Button_Startup.Button.onClick.AddListener(OnClickStartup);
        Button_Shutdown.Button.onClick.AddListener(OnClickShutdown);
        Button_SuTiaoGuan.Button.onClick.AddListener(OnClickSuTiaoGuan);
    }

    private void OnClickStartup()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
        MeditorManager.Instance.MeditorUi.OnChapterStart(101);
    }

    private void OnClickShutdown()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
        MeditorManager.Instance.MeditorUi.OnChapterStart(102);
    }

    private void OnClickSuTiaoGuan()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
        MeditorManager.Instance.MeditorUi.OnChapterStart(103);
    }

}
