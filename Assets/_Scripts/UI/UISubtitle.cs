using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.UI;

public class UISubtitle : UIPanelBase
{
    public Text Text;

    protected override void Awake()
    {
        base.Awake();
        Text = GetComponentInChildren<Text>();
    }

    public override void Reset()
    {
        base.Reset();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
    }
}
