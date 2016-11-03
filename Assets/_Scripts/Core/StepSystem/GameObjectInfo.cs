using System;
using UnityEngine;
using System.Collections;
using HighlightingSystem;

/// <summary>
/// 物体的信息
/// </summary>
[RequireComponent(typeof(UniqueID))]
public class GameObjectInfo : MonoBehaviour, IReset
{
    [Tooltip("是否是顶级物体(如一个设备的顶级)")]
    public bool IsParent;
    [Tooltip("物体的唯一标识")]
    public int UniqueId;

    [Tooltip("物体目前的状态")]
    [SerializeField]
    private Enum_GameObjectStatus status;

    public Enum_GameObjectStatus Status
    {
        get { return status; }
        set
        {
            status = value;
            if (OnStatusChangeAction != null)
            {
                OnStatusChangeAction();
            }
        }
    }

    [Tooltip("高亮物体")]
    public Transform[] HighlitTarget;
    [Tooltip("使用自身作为高亮显示物体")]
    public bool useSelfModelHighlight;
    [Tooltip("闪烁的颜色")]
    public Color HightColorFrom = Color.red;
    public Color HightColorTo = Color.white;
    //高亮物体
    private Highlighter[] _highlighters;
    //初始化的时候恢复到状态(目前是恢复到场景设置的Status的原始状态)
    private Enum_GameObjectStatus _statusToReset;
    /// <summary>
    /// 相机飞视角脚本
    /// </summary>
    [HideInInspector]
    public CameraLocator Locator;

    public Action OnStatusChangeAction;

    public void Awake()
    {
        if (Locator == null)
            Locator = GetComponent<CameraLocator>();
        if (useSelfModelHighlight)
        {
            HighlitTarget = new Transform[] { transform };
        }
    }

    public void Start()
    {
        //如果是顶级物体,就挪放到物体管理的下面
        if (IsParent)
        {
            transform.SetParent(GameObjectInfoManager.Instance.transform);
            GameObjectInfoManager.Instance.AddGameObjectInfoDictionary(this);
        }
        _statusToReset = Status;
        StudyManager.Instance.OnStartStudy += Reset;
    }

    /// <summary>
    /// 添加高亮
    /// </summary>
    public void AddHightLight()
    {
        _highlighters = new Highlighter[HighlitTarget.Length];
        for (int i = 0; i < HighlitTarget.Length; i++)
        {
            _highlighters[i] = HighlitTarget[i].gameObject.AddComponent<Highlighter>();
            _highlighters[i].FlashingOn(HightColorFrom, HightColorTo);
        }
    }

    /// <summary>
    /// 删除高亮
    /// </summary>
    public void RemoveHighligh()
    {
        for (int i = 0; i < _highlighters.Length; i++)
        {
            Destroy(_highlighters[i]);
        }
        _highlighters = null;
    }

    public void Reset()
    {
        //清除自身高亮
        Destroy(GetComponent<Highlighter>());
        //恢复初始状态
        Status = _statusToReset;
    }
}
