using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIManager : MonoSingleton<UIManager>, IReset
{
    public UIMain UiMain;
    public UIYesNo UiYesNo;
    public UISubtitle UiSubtitle;
    public UIClock UiClock;
    public UIDownLoadMask UiDownLoadMask;
    public void Awake()
    {
        UiMain = Global.FindChild<UIMain>(transform, "UIMain");
        UiYesNo = Global.FindChild<UIYesNo>(transform, "UIYesNo");
        UiSubtitle = Global.FindChild<UISubtitle>(transform, "UISubtitle");
        UiClock = Global.FindChild<UIClock>(transform, "UIClock");
        UiDownLoadMask = Global.FindChild<UIDownLoadMask>(transform, "UIDownLoadMask");
    }

    public void Start()
    {
        SetCanvasGroupVisibleAndClickable(UiYesNo.TheCanvasGroup, false);
        SetCanvasGroupVisibleAndClickable(UiSubtitle.TheCanvasGroup, false);
        StudyManager.Instance.OnStartStudy += () => { SetCanvasGroupVisibleAndClickable(UiSubtitle.TheCanvasGroup, true); };
        StudyManager.Instance.OnEndStudy +=
            () => { SetCanvasGroupVisibleAndClickable(UiSubtitle.TheCanvasGroup, false); };
    }

    /// <summary>
    /// 整体的显示隐藏设置
    /// </summary>
    /// <param name="canvasGroup"></param>
    /// <param name="visibleAndClickable"></param>
    public void SetCanvasGroupVisibleAndClickable(CanvasGroup canvasGroup, bool visibleAndClickable)
    {
        canvasGroup.alpha = visibleAndClickable ? 1 : 0;
        canvasGroup.blocksRaycasts = visibleAndClickable;
    }


    public void Reset()
    {
        UiMain.Reset();
        UiYesNo.Reset();
        UiSubtitle.Reset();
    }
}
