using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体章节父类
/// </summary>
public class StudyBase : MonoBehaviour, IReset
{

    protected List<Step> steps;
    /// <summary>
    /// 步骤标记
    /// </summary>
    public int Index { get; set; }
    protected virtual void Start()
    {
        StudyManager.Instance.OnEndStudy += DoChapterOver;
        StudyManager.Instance.OnStartStudy += DoChapterStart;
    }
    /// <summary>
    /// 每一步开始的时候做的事情
    /// </summary>
    protected virtual void DoStepStart()
    {
        if (steps[Index].StepStartAutoAction != null)
        {
            steps[Index].StepStartAutoAction();
        }
        //标记当前正在进行的步骤
        StudyManager.Instance.CurrentStep = steps[Index];

        //播放音频
        if (steps[Index].PlayMode == PlayMode.Start)
        {
            AudioManager.Instance.PlayAudio(steps[Index].AudioName);
        }
        else if (steps[Index].PlayMode == PlayMode.Stop)
        {
            AudioManager.Instance.StopPlay();
        }
    }
    /// <summary>
    /// 每一步结束的时候做的事情
    /// </summary>
    protected virtual void DoStepEnd()
    {
        if (steps[Index].StepEndautoAction != null)
            steps[Index].StepEndautoAction();
        //索引自增
        Index++;
    }
    protected IEnumerator StartSteps()
    {
        Index = StudyManager.Instance.StartStep;
        while (true)
        {
            if (Index >= steps.Count)
            {
                //章节操作结束
                if (StudyManager.Instance.OnEndStudy != null)
                    StudyManager.Instance.OnEndStudy();
                if (GameObjectInfoManager.Instance.OnResetAction != null)
                    GameObjectInfoManager.Instance.OnResetAction();
                break;
            }
            DoStepStart();
            yield return new WaitWhile(() => steps[Index].keepWaiting);
            yield return new WaitForSeconds(steps[Index].StepFinishWaitTime);
            DoStepEnd();
        }
    }

    protected virtual void DoChapterOver()
    {
        Reset();
        MeditorManager.Instance.MeditorUi.OnChapterOver();
        Debug.Log("Chapter is over");
    }

    protected virtual void DoChapterStart()
    {
        Reset();
        Debug.Log("Chapter is start");
    }

    public void Reset()
    {
        StopAllCoroutines();
        Index = 0;
        steps = null;
    }
}
