using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 步骤基础类
/// </summary>
public class StepBase : CustomYieldInstruction
{
    /// <summary>
    /// 步骤开始事件
    /// </summary>
    public Action StepStartAutoAction;
    /// <summary>
    /// 步骤结束事件
    /// </summary>
    public Action StepEndautoAction;

    public StepBase()
    {
        StepStartAutoAction += StartStep;
        StepEndautoAction += EndStep;
    }
    public bool IsDone { get; set; }

    public override bool keepWaiting
    {
        get { return !IsDone; }
    }

    /// <summary>
    /// 开启这一步骤的操作
    /// </summary>
    protected virtual void StartStep() { }
    /// <summary>
    /// 结束这一步的操作
    /// </summary>
    public virtual void EndStep() { }
}
