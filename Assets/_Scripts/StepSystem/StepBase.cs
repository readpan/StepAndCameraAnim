using System.Collections;
using UnityEngine;

/// <summary>
/// 步骤基础类
/// </summary>
public class StepBase : CustomYieldInstruction
{
    public bool IsDone { get; set; }

    public override bool keepWaiting
    {
        get { return !IsDone; }
    }

    /// <summary>
    /// 开启这一步骤的操作
    /// </summary>
    public virtual void StartStep()
    {
        
    }
}
