using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.UI;

public class UISubtitle : UIPanelBase
{
    public Text Text;
    public ButtonGroup ContinueButtonGroup;

    protected override void Awake()
    {
        base.Awake();
        Text = GetComponentInChildren<Text>();
        ContinueButtonGroup = Global.FindChild<ButtonGroup>(transform, "ContinueButtonGroup");
    }

    protected override void Start()
    {
        base.Start();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(ContinueButtonGroup.CanvasGroup, false);
        ContinueButtonGroup.Button.onClick.AddListener(CloseContinue);
    }

    private void CloseContinue()
    {
        //关闭button
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(ContinueButtonGroup.CanvasGroup, false);
        if (InputManager.Instance.OnClickContinue != null)
        {
            InputManager.Instance.OnClickContinue();
        }
    }

    public override void Reset()
    {
        base.Reset();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, false);
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(ContinueButtonGroup.CanvasGroup, false);
    }

    //public void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.KeypadEnter))
    //    {
    //        CloseContinue();
    //    }
    //}

    public void SetText(string text)
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(TheCanvasGroup, text != "");
        Text.text = text;
    }
}
