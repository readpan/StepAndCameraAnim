using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ClickChangeStatus : StepActionBase
{
    public virtual void OnMouseUp()
    {
        GameObjectInfo.Status = TargetStatus;
    }
}
