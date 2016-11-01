using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public CanvasGroup TheCanvasGroup;
    public ButtonGroup Button_Startup;
    public ButtonGroup Button_Shutdown;

    public void Awake()
    {
        TheCanvasGroup = GetComponent<CanvasGroup>();
        Button_Startup = Global.FindChild<ButtonGroup>(transform, "Button_Startup");
        Button_Shutdown = Global.FindChild<ButtonGroup>(transform, "Button_Shutdown");
    }

    public void Start()
    {
        Button_Startup.Button.onClick.AddListener(OnClickStartup);
        Button_Shutdown.Button.onClick.AddListener(OnClickShutdown);
    }

    private void OnClickStartup()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
        MeditorManager.Instance.MeditorUi.OnChapterStart(101);
    }

    private void OnClickShutdown()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
        MeditorManager.Instance.MeditorUi.OnChapterStart(102);
    }

}
