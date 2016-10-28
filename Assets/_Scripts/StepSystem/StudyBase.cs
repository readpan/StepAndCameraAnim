using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体章节父类
/// </summary>
public class StudyBase : MonoBehaviour
{

    protected List<Step> steps;
    public int Index { get; set; }
    public Action OnChapterOver;
    public void Start()
    {
        OnChapterOver += DoChapterOver;
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
        while (true)
        {
            DoStepStart();
            yield return new WaitWhile(() => steps[Index].keepWaiting);
            DoStepEnd();
            if (Index >= steps.Count)
            {
                //章节操作结束
                if (OnChapterOver != null)
                    OnChapterOver();
                break;
            }
        }
    }

    protected virtual void DoChapterOver()
    {
        Index = 0;
        Debug.Log("Chapter is over");
    }


}
