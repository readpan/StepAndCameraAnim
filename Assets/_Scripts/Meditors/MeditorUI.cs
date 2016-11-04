using UnityEngine;
using System.Collections;

public class MeditorUI : MonoBehaviour
{

    /// <summary>
    /// 章节开始
    /// </summary>
    /// <param name="index"></param>
    public void OnChapterStart(int index)
    {
        StudyManager.Instance.StartChapter(index);
    }
    /// <summary>
    /// 章节结束
    /// </summary>
    public void OnChapterOver()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiYesNo.TheCanvasGroup, true);
    }

    /// <summary>
    /// 章节再来一次
    /// </summary>
    public void OnChapterOnceMore()
    {
        StudyManager.Instance.StartChapter(StudyManager.Instance.TheChapterStudy.CurrentChapterIndex);
    }
    /// <summary>
    /// 步骤字幕
    /// </summary>
    /// <param name="subtitle"></param>
    public void SetSubtitle(string subtitle)
    {
        UIManager.Instance.UISubtitle.SetText(subtitle);
    }

    /// <summary>
    /// 步骤图标显示
    /// </summary>
    public void SetPressIcon()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(
            UIManager.Instance.UISubtitle.ContinueButtonGroup.CanvasGroup, true);

    }

    /// <summary>
    /// 回到web
    /// </summary>
    public void BackToWeb()
    {
        //调用web方法，返回web
        Application.ExternalCall(ToWebFunctionStrings.BackToWeb);
        if (StudyManager.Instance.OnEndStudy != null)
            StudyManager.Instance.OnEndStudy();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UIMain.TheCanvasGroup, true);
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiYesNo.TheCanvasGroup, false);
    }

    public void ShowClock()
    {
        UIManager.Instance.UIClock.Rotate();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UIClock.TheCanvasGroup,true);
    }
}
