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
        UIManager.Instance.UiSubtitle.SetText(subtitle);
    }

    /// <summary>
    /// 步骤图标显示
    /// </summary>
    public void SetPressIcon()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(
            UIManager.Instance.UiSubtitle.ContinueButtonGroup.CanvasGroup, true);

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
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiMain.TheCanvasGroup, true);
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiYesNo.TheCanvasGroup, false);
    }

    /// <summary>
    /// 显示表
    /// </summary>
    public void ShowClock()
    {
        UIManager.Instance.UiClock.Rotate();
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiClock.TheCanvasGroup, true);
    }

    /// <summary>
    /// 设置加载是否成功ui
    /// </summary>
    public void SetDownLoadReady()
    {
        UIManager.Instance.UiDownLoadMask.SetMask(false);
    }

    public void SetAccess(string msg)
    {
        UIManager.Instance.UiDownLoadMask.TextLoadInfo.text = msg;
    }
}
