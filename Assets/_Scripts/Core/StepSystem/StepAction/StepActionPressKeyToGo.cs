using UnityEngine;
using System.Collections;

public class StepActionPressKeyToGo : StepActionBase
{
    protected override  void Start()
    {
        InputManager.Instance.OnClickContinue += DoPress;
    }

    private void DoPress()
    {
        GameObjectInfo.Status = TargetStatus;
    }
}
