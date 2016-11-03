using UnityEngine;
using System.Collections;
using DG.Tweening;
using Pan_Tools;

public class UIClock : UIPanelBase
{
    public Transform MinTransform, HourTransform;
    protected override void Awake()
    {
        base.Awake();
        HourTransform = Global.FindChild<Transform>(transform, "HourTf");
        MinTransform = Global.FindChild<Transform>(transform, "MinTf");
    }

    protected override void Start()
    {
        base.Start();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
    }

    public void Rotate()
    {
        MinTransform.DOLocalRotate(new Vector3(0, 0, -78.3f), 4).SetEase(Ease.Linear);
        HourTransform.DOLocalRotate(new Vector3(0, 0, -6f), 4).SetEase(Ease.Linear).OnComplete(() =>
        {
            UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup,false);
        });
    }
}
