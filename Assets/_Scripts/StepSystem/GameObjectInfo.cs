using UnityEngine;
using System.Collections;
/// <summary>
/// 物体的信息
/// </summary>
[RequireComponent(typeof(UniqueID))]
public class GameObjectInfo : MonoBehaviour
{
    public int UniqueId;
    public Enum_GameObjectStatus Status = Enum_GameObjectStatus.Normal;
    /// <summary>
    /// 相机飞视角脚本
    /// </summary>
    public CameraLocator Locator;

    public void Awake()
    {
        if (Locator == null)
            Locator = GetComponent<CameraLocator>();
    }
}
