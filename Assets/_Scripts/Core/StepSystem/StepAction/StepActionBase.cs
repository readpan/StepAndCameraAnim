using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameObjectInfo))]
public class StepActionBase : MonoBehaviour,IReset
{

    [Tooltip("点击后想要改变的状态")]
    public Enum_GameObjectStatus TargetStatus;

    protected GameObjectInfo GameObjectInfo;

    public virtual void Awake()
    {
        GameObjectInfo = GetComponent<GameObjectInfo>();
    }

    protected virtual bool JudgeIfCanDo()
    {
        return GameObjectInfo.UniqueId == StudyManager.Instance.CurrentStep.TargetUniqueId;
    }

    public virtual void Reset()
    {
    }
}
