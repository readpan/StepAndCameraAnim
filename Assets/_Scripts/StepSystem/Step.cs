using System;
using UnityEngine;
using System.Collections;

public class Step : StepBase
{
    private int _targetUniqueId;
    private Enum_GameObjectStatus _targetStatus;
    private bool _autoCameraAnim;

    private GameObjectInfo _gameObjectInfo = null;
    /// <summary>
    /// 步骤配置
    /// </summary>
    /// <param name="targetUniqueId">操作目标Id</param>
    /// <param name="targetStatus">目标状态</param>
    /// <param name="autoCameraAnim">是否要有过场动画</param>
    public Step(int targetUniqueId, Enum_GameObjectStatus targetStatus, bool autoCameraAnim = true) : base()
    {
        _targetUniqueId = targetUniqueId;
        _targetStatus = targetStatus;
        _autoCameraAnim = autoCameraAnim;
        if (!GameObjectInfoManager.Instance.GameObjectInfosDic.TryGetValue(_targetUniqueId, out _gameObjectInfo))
        {
            Debug.LogError("Can't find Such gameObject whitch id = " + targetUniqueId);
        }
    }

    /// <summary>
    /// 步骤配置(带有音频)
    /// </summary>
    /// <param name="targetUniqueId">操作目标Id</param>
    /// <param name="targetStatus">目标状态</param>
    /// <param name="audioName">音频文件</param>
    /// <param name="autoCameraAnim">是否要有过场动画</param>
    public Step(int targetUniqueId, Enum_GameObjectStatus targetStatus, string audioName, bool autoCameraAnim = true) : this(targetUniqueId, targetStatus, autoCameraAnim)
    {
        StepStartAutoAction += () => { AudioManager.Instance.PlayAudio(audioName); };
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

    protected override void StartStep()
    {
        //添加高亮
        _gameObjectInfo.AddHightLight();

        //是否自动移动摄像机
        if (_autoCameraAnim)
        {
            _gameObjectInfo.Locator.DoLocator();
        }
        Debug.Log(_targetUniqueId + " has start");
    }

    public override void EndStep()
    {
        //取消高亮物体
        _gameObjectInfo.RemoveHighligh();
    }
}