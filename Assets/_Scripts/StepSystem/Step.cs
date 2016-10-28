using System;
using UnityEngine;
using System.Collections;

public class Step : StepBase
{
    private int _targetUniqueId;
    private Enum_GameObjectStatus _targetStatus;
    private bool _autoCameraAnim;
    public Action StepAutoAction;
    private GameObjectInfo _gameObjectInfo = null;
    public Step(int targetUniqueId, Enum_GameObjectStatus targetStatus, bool autoCameraAnim = true)
    {
        _targetUniqueId = targetUniqueId;
        _targetStatus = targetStatus;
        _autoCameraAnim = autoCameraAnim;
        if (!GameObjectInfoManager.Instance.GameObjectInfosDic.TryGetValue(_targetUniqueId, out _gameObjectInfo))
        {
            Debug.LogError("Can't find Such gameObject whitch id = " + targetUniqueId);
        }
    }

    public override bool keepWaiting
    {
        get
        {
            if (_gameObjectInfo.Status == _targetStatus)
            {
                IsDone = true;
            }
            return !IsDone;
        }
    }

    public override void StartStep()
    {
        //是否自动移动摄像机
        if (_autoCameraAnim)
        {
            _gameObjectInfo.Locator.DoLocator();
        }
        Debug.Log(_targetUniqueId + " has start");
    }
}