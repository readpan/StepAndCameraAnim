using UnityEngine;
using System.Collections;
using HighlightingSystem;

/// <summary>
/// 物体的信息
/// </summary>
[RequireComponent(typeof(UniqueID))]
public class GameObjectInfo : MonoBehaviour
{
    [Tooltip("物体的唯一标识")]
    public int UniqueId;
    [Tooltip("物体目前的状态")]
    public Enum_GameObjectStatus Status = Enum_GameObjectStatus.Normal;
    [Tooltip("高亮物体")]
    public Transform[] HighlitTarget;
    [Tooltip("闪烁的颜色")]
    public Color HightColorFrom = Color.red;
    public Color HightColorTo = Color.white;
    //高亮物体
    private Highlighter[] _highlighters;

    /// <summary>
    /// 相机飞视角脚本
    /// </summary>
    [HideInInspector]
    public CameraLocator Locator;

    public void Awake()
    {
        if (Locator == null)
            Locator = GetComponent<CameraLocator>();
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
}
