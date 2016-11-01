using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class StepActionClickToSwitch : StepActionBase
{
    private bool _onFlag;
    public Vector3 SwitchOnPos;
    public Vector3 SwitchOffPos;

    public void Start()
    {
        GameObjectInfoManager.Instance.OnResetAction += Reset;
    }

    public void OnMouseUp()
    {
        if (JudgeIfCanDo())
        {
            _onFlag = !_onFlag;
            SetRotation(_onFlag);
        }
        else
        {
            Debug.LogError("你操作了错误的物体.");
        }
    }

    public override void Reset()
    {
        base.Reset();
        _onFlag = false;
        SetRotation(_onFlag);
    }

    private void SetRotation(bool rotationFlag)
    {
        GameObjectInfo.Status = rotationFlag ? Enum_GameObjectStatus.SwitchOn : Enum_GameObjectStatus.SwitchOff;
        transform.localEulerAngles = _onFlag ? SwitchOnPos : SwitchOffPos;
    }
}
