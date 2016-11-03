using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;
/// <summary>
/// 章节学习管理
/// </summary>
public class StudyManager : MonoSingleton<StudyManager>, IReset
{
    /// <summary>
    /// 在开启一个章节学习的时候执行
    /// </summary>
    public Action OnStartStudy;

    /// <summary>
    /// 在每章节结束的时候执行
    /// </summary>
    public Action OnEndStudy;
    /// <summary>
    /// 目前的步骤
    /// </summary>
    public Step CurrentStep;
    public ChapterStudy TheChapterStudy;
    [Tooltip("测试用，从第几步开始执行")]
    public int StartStep = 0;
    public void Awake()
    {
        TheChapterStudy = GetComponentInChildren<ChapterStudy>();
    }

    public void Start()
    {
        OnStartStudy += Reset;
        //OnEndStudy += GameObjectInfoManager.Instance.OnResetAction;
    }

    public void StartChapter(int chapterIndex)
    {
        StartCoroutine(StartTheChapter(chapterIndex));
    }

    IEnumerator StartTheChapter(int chapterIndex)
    {
        AudioManager.Instance.ReloadAudioToDic("radar");
        yield return new WaitWhile(() => !AudioManager.Instance.LoadOverFlag);
        OnStartStudy();
        TheChapterStudy.StartChapter(chapterIndex);
    }

    public void Reset()
    {
        CurrentStep = null;
    }
}
