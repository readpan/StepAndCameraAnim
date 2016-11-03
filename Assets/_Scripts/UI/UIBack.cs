using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIBack : UIPanelBase
{
    public ButtonGroup ButtonBack;

    protected override void Awake()
    {
        base.Awake();
        ButtonBack = Global.FindChild<ButtonGroup>(transform, "ButtonBack");
    }

    protected override void Start()
    {
        base.Start();
        ButtonBack.Button.onClick.AddListener(OnBtnBackClick);
    }

    private void OnBtnBackClick()
    {
        MeditorManager.Instance.MeditorUi.BackToWeb();
    }
}
