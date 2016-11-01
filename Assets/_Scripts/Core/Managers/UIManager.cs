using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIManager : MonoSingleton<UIManager>
{
    public UIMain UIMain;
    public UIYesNo UiYesNo;

    public void Awake()
    {
        UIMain = Global.FindChild<UIMain>(transform, "UIMain");
        UiYesNo = Global.FindChild<UIYesNo>(transform, "UIYesNo");
    }

    public void Start()
    {
        SetCanvasGroupVisibleAndClickable(UiYesNo.TheCanvasGroup,false);
    }

    public void SetCanvasGroupVisibleAndClickable(CanvasGroup canvasGroup, bool visibleAndClickable)
    {
        canvasGroup.alpha = visibleAndClickable ? 1 : 0;
        canvasGroup.blocksRaycasts = visibleAndClickable;
    }
}
