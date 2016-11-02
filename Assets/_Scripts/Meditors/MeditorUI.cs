using UnityEngine;
using System.Collections;

public class MeditorUI : MonoBehaviour {

    public void OnChapterStart(int index)
    {
        StudyManager.Instance.StartChapter(index);
    }

    public void OnChapterOver()
    {
        UIManager.Instance.SetCanvasGroupVisibleAndClickable(UIManager.Instance.UiYesNo.TheCanvasGroup,true);
    }

    public void OnChapterOnceMore()
    {
        StudyManager.Instance.StartChapter(StudyManager.Instance.TheChapterStudy.CurrentChapterIndex);
    }

    public void SetSubtitle(string subtitle)
    {
        UIManager.Instance.UISubtitle.Text.text = subtitle;
    }
}
