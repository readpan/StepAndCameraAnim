using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIManager : MonoSingleton<UIManager>, IReset
{
    public UIMain UIMain;
    public UIYesNo UiYesNo;
    public UISubtitle UISubtitle;
    public void Awake()
    {
        UIMain = Global.FindChild<UIMain>(transform, "UIMain");
        UiYesNo = Global.FindChild<UIYesNo>(transform, "UIYesNo");
        UISubtitle = Global.FindChild<UISubtitle>(transform, "UISubtitle");
    }

    public void Start()
    {
        SetCanvasGroupVisibleAndClickable(UiYesNo.TheCanvasGroup, false);
        SetCanvasGroupVisibleAndClickable(UISubtitle.TheCanvasGroup, false);
        StudyManager.Instance.OnStartStudy += () => { SetCanvasGroupVisibleAndClickable(UISubtitle.TheCanvasGroup, true); };
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
        UIMain.Reset();
        UiYesNo.Reset();
        UISubtitle.Reset();
    }
}
