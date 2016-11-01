using UnityEngine;
using System.Collections;
using Pan_Tools;

public class UIYesNo : MonoBehaviour
{
    public ButtonGroup ButtonYes, ButtonNo;
    public CanvasGroup TheCanvasGroup;

    public void Awake()
    {
        TheCanvasGroup = GetComponent<CanvasGroup>();
        ButtonYes = Global.FindChild<ButtonGroup>(transform, "ButtonYes");
        ButtonNo = Global.FindChild<ButtonGroup>(transform, "ButtonNo");
    }

    public void Start()
    {
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
}
