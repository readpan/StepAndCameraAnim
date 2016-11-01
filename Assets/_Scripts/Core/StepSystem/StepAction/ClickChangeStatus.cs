using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ClickChangeStatus : StepActionBase
{
    public void OnMouseUp()
    {
        GameObjectInfo.Status = TargetStatus;
    }
}
