using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;

public class Step : StepBase
{
    public int TargetUniqueId { get; set; }
    public string Subtitle { get; set; }
    private Enum_GameObjectStatus _targetStatus = Enum_GameObjectStatus.None;
    private bool _autoCameraAnim = true;

    private GameObjectInfo _gameObjectInfo = null;


    /// <summary>
    /// 步骤配置
    /// </summary>
    /// <param name="targetUniqueId">操作目标Id</param>
    /// <param name="targetStatus">目标状态</param>
    /// <param name="autoCameraAnim">是否要有过场动画</param>
    public Step(int targetUniqueId, Enum_GameObjectStatus targetStatus, bool autoCameraAnim = true) : base()
    {
        ConfigSubtitle("");
        TargetUniqueId = targetUniqueId;
        _targetStatus = targetStatus;
        _autoCameraAnim = autoCameraAnim;
        LinkGameInfo(targetUniqueId);
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
        ConfigSubtitle("");
        StepStartAutoAction += () => { AudioManager.Instance.PlayAudio(audioName); };
    }

    /// <summary>
    /// 带有字幕的步骤
    /// </summary>
    /// <param name="subtitle"></param>
    /// <param name="targetUniqueId"></param>
    /// <param name="targetStatus"></param>
    /// <param name="audioName"></param>
    /// <param name="autoCameraAnim"></param>
    public Step(string subtitle, int targetUniqueId, Enum_GameObjectStatus targetStatus, string audioName,
        bool autoCameraAnim = true) : this(targetUniqueId, targetStatus, audioName, autoCameraAnim)
    {
        ConfigSubtitle(subtitle);
    }

    /// <summary>
    /// 自动执行的步骤,X秒后跳过
    /// </summary>
    /// <param name="targetUniqueId"></param>
    /// <param name="WaitTime"></param>
    public Step(int targetUniqueId, float WaitTime, string audioName = "")
    {
        ConfigSubtitle("");
        TargetUniqueId = targetUniqueId;
        LinkGameInfo(targetUniqueId);
        //播放音频
        if (audioName != "")
            StepStartAutoAction += () => { AudioManager.Instance.PlayAudio(audioName); };
        //X秒后自动执行
        StepStartAutoAction += () =>
        {
            Global.Instance.StartIEnumerator(Global.DoSomethingInXSecond(() =>
            {
                IsDone = true;
            }, WaitTime));
        };
    }

    /// <summary>
    /// 自动执行的步骤,X秒后跳过(带有字幕)
    /// </summary>
    /// <param name="targetUniqueId"></param>
    /// <param name="WaitTime"></param>
    public Step(string subtitle,int targetUniqueId, float WaitTime, string audioName = ""):this(targetUniqueId,WaitTime,audioName)
    {
        
        ConfigSubtitle(subtitle);
    }

    private void ConfigSubtitle(string subtitle)
    {
        StepStartAutoAction += () =>
        {
            Subtitle = subtitle;
            MeditorManager.Instance.MeditorUi.SetSubtitle(subtitle);
        };
    }

    /// <summary>
    /// 连接相应物体
    /// </summary>
    private void LinkGameInfo(int targetUniqueId)
    {
        if (!GameObjectInfoManager.Instance.GameObjectInfosDic.TryGetValue(TargetUniqueId, out _gameObjectInfo))
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

    protected override void StartStep()
    {
        //添加高亮
        _gameObjectInfo.AddHightLight();

        //是否自动移动摄像机
        if (_autoCameraAnim)
        {
            _gameObjectInfo.Locator.DoLocator();
        }
        Debug.Log(TargetUniqueId + " has start");
    }

    public override void EndStep()
    {
        //取消高亮物体
        _gameObjectInfo.RemoveHighligh();
    }
}