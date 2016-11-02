using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIYesNo : UIPanelBase
{
    public ButtonGroup ButtonYes, ButtonNo;

    protected override void Awake()
    {
        base.Awake();
        ButtonYes = Global.FindChild<ButtonGroup>(transform, "ButtonYes");
        ButtonNo = Global.FindChild<ButtonGroup>(transform, "ButtonNo");
    }

    protected override  void Start()
    {
        base.Start();
        ButtonYes.Button.onClick.AddListener(OnClickButtonYes);
        ButtonNo.Button.onClick.AddListener(OnClickButtonNo);
    }

    private void OnClickButtonYes()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
        MeditorManager.Instance.MeditorUi.OnChapterOnceMore();
    }

    private void OnClickButtonNo()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UIMain.TheCanvasGroup, true);

    }

    public override void Reset()
    {
        base.Reset();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
    }
}
